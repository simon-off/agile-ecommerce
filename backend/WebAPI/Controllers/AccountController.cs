using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Helpers.Extensions;
using WebAPI.Helpers.Services;
using WebAPI.Interface.Services;
using WebAPI.Models.Dtos;
using WebAPI.Models.Identity;
using WebAPI.Models.Schemas;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly IAccountService _accountService;

    public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IConfiguration configuration, IAccountService accountService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _accountService = accountService;
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAccountDetails()
    {
        var jwtString = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        var id = _accountService.GetIdFromToken(jwtString!);

        if (id == null)
            return StatusCode(403, "Jwt token did not contain user id.");

        var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);

        // It is not possible to enter this if statement unless the account has been deleted and therefore the token is invalid.
        if (user == null)
            return BadRequest("The token you tried to use is no longer valid.");

        return Ok((UserDto)user);
    }

    [Authorize]
    [HttpPut("update")]
    public async Task<IActionResult> UpdateAccount(UserUpdateSchema schema)
    {
        var jwtString = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        var id = _accountService.GetIdFromToken(jwtString!);

        if (id == null)
            return StatusCode(403, "Jwt token did not contain user id.");

        var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);

        // It is not possible to enter this if statement unless the account has been deleted and therefore the token is invalid.
        if (user == null)
            return BadRequest("The token you tried to use is no longer valid.");

        user.FirstName = schema.FirstName;
        user.LastName = schema.LastName;
        user.Email = schema.Email;
        user.UserName = schema.Email;
        user.PhoneNumber = schema.PhoneNumber;

        if ((await _userManager.UpdateAsync(user)).Succeeded)
            return Ok((UserDto)user);

        return StatusCode(502, "Something went wrong when updating the account. Make sure all of the provided information was correct and try again.");
    }

    [HttpPost("SignUp")]
    public async Task<IActionResult> SignUp(SignUpSchema schema)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await _userManager.Users.AnyAsync(x => x.Email == schema.Email))
                return Conflict("An account with that email already exists");

            if ((await _userManager.CreateAsync(schema, schema.Password)).Succeeded)
            {
                var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == schema.Email);
                return Created("", (UserDto)user!);
            }

            return StatusCode(502, "Something went wrong when signing up. Make sure all of the provided information was correct and try again.");
        }
        catch
        {
            return StatusCode(502, "Something went wrong when signing up. Please try again.");
        }
    }

    [HttpPost("SignIn")]
    public async Task<IActionResult> SignIn(SignInSchema schema)
    {
        try
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if ((await _signInManager.PasswordSignInAsync(schema.Email, schema.Password, false, false)).Succeeded)
            {
                var tokenString = _accountService.CreateJwtToken(schema.Email);

                return Ok(new { Token = tokenString });
            }

            return Unauthorized("Invalid login credentials, please try again.");
        }
        catch
        {
            return StatusCode(502, "Something went wrong when signing in. Please try again.");
        }
    }

    [Authorize]
    [HttpPut("ChangePassword")]
    public async Task<IActionResult> PlaceUserOrder(UpdatePasswordSchema schema)
    {
        var userId = _accountService.GetIdFromToken(Request.GetAuthString()!);

        if (userId == null)
            return StatusCode(403, "Jwt token did not contain user id.");

        var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == userId);
        // It is not possible to enter this if statement unless the account has been deleted and therefore the token is invalid.
        if (user == null)
            return BadRequest("The token you tried to use is no longer valid.");

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (!(await _userManager.ChangePasswordAsync(user, schema.OldPassword, schema.NewPassword)).Succeeded)
            return BadRequest("Old password is invalid. Please try again");

        return Ok((UserDto)user);
    }
}
