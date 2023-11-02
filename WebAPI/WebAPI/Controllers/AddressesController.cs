using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Interface.Services;
using WebAPI.Models.Identity;
using WebAPI.Models.Schemas;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AddressesController : ControllerBase
{
    private readonly IAccountService _accountService;
    private readonly IAddressService _addressService;

    public AddressesController(IConfiguration configuration, IAccountService accountService, IAddressService addressService)
    {
        _accountService = accountService;
        _addressService = addressService;
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateUserAddress(AddressCreateSchema schema)
    {
        try
        {
            var jwtString = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = _accountService.GetIdFromToken(jwtString!);

            var status = await _accountService.IsValidUserId(userId);

            if (status.StatusCode != 200)
                return StatusCode(status.StatusCode, status.StatusMessage);

            var result = await _addressService.CreateUserAddressAsync(schema, userId!);

            return Created("", result);
        }
        catch
        {
            return StatusCode(502, "Something went wrong when creating the address. Please try again.");
        }
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetUserAddresses()
    {
        try
        {
            var jwtString = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = _accountService.GetIdFromToken(jwtString!);

            var status = await _accountService.IsValidUserId(userId);

            if (status.StatusCode != 200)
                return StatusCode(status.StatusCode, status.StatusMessage);

            var addresses = await _addressService.GetAllAsync(x => x.UserId == userId!);

            return Ok(addresses);
        }
        catch
        {
            return StatusCode(502, "Something went wrong when fetching the address. Please try again.");
        }
    }

    [Authorize]
    [HttpPut]
    public async Task<IActionResult> UpdateUserAddress(AddressUpdateSchema schema)
    {
        try
        {
            var jwtString = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = _accountService.GetIdFromToken(jwtString!);

            var status = await _accountService.IsValidUserId(userId);

            if (status.StatusCode != 200)
                return StatusCode(status.StatusCode, status.StatusMessage);

            if (!(await _addressService.IsAddressOwnedByUserAsync(schema.Id, userId!)))
                return StatusCode(403, "You do not have permission to update this address.");


            var address = await _addressService.UpdateUserAddressAsync(schema, userId!);

            return Ok(address);
        }
        catch
        {
            return StatusCode(502, "Something went wrong when updating the address. Please try again.");
        }
    }

    [Authorize]
    [HttpDelete]
    public async Task<IActionResult> DeleteUserAddresss(int addressId)
    {
        try
        {
            var jwtString = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = _accountService.GetIdFromToken(jwtString!);

            var status = await _accountService.IsValidUserId(userId);

            if (status.StatusCode != 200)
                return StatusCode(status.StatusCode, status.StatusMessage);

            if (!(await _addressService.IsAddressOwnedByUserAsync(addressId, userId!)))
                return StatusCode(403, "You do not have permission to update this address.");

            if (await _addressService.DeleteAsync(addressId))
                return NoContent();

            return StatusCode(502, "Something went wrong when deleting. Make sure all the information is valid and try again.");
        }
        catch
        {
            return StatusCode(502, "Something went wrong when deleting the address. Please try again.");
        }
    }
}
