using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Helpers.Services;
using WebAPI.Interface.Repositories;
using WebAPI.Interface.Services;
using WebAPI.Models.Dtos;
using WebAPI.Models.Identity;
using WebAPI.Models.Schemas;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;
    private readonly IAccountService _accountService;
    private readonly UserManager<AppUser> _userManager;

    public OrdersController(IOrderService orderService, IAccountService accountService, UserManager<AppUser> userManager)
    {
        _orderService = orderService;
        _accountService = accountService;
        _userManager = userManager;
    }

    [HttpPost]
    public async Task<IActionResult> PlaceCustomerOrder(OrderCustomerCreateSchema schema)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _orderService.AllProductItemsValidAsync(schema.Products))
                return BadRequest("One or more of the products requested could not be found in the database.");

            var orderDto = await _orderService.PlaceCustomerOrderAsync(schema);

            // Return created status code
            return StatusCode(201, orderDto);
        }
        catch
        {
            return StatusCode(502, "Something went wrong when processing the order. Please try again.");
        }
    }

    [Authorize]
    [HttpPost("User")]
    public async Task<IActionResult> PlaceUserOrder(OrderUserCreateSchema schema)
    {
        try
        {
            var jwtString = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var id = _accountService.GetIdFromToken(jwtString!);

            if (id == null)
                return StatusCode(403, "Jwt token did not contain user id.");

            // It is not possible to enter this if statement unless the account has been deleted and therefore the token is invalid.
            if (await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id) == null)
                return BadRequest("The token you tried to use is no longer valid.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _orderService.AllProductItemsValidAsync(schema.Products))
                return BadRequest("One or more of the products requested could not be found in the database.");


            var orderDto = await _orderService.PlaceUserOrderAsync(schema, id);

            // Return created status code
            return StatusCode(201, orderDto);
        }
        catch
        {
            return StatusCode(502, "Something went wrong when processing the order. Please try again.");
        }
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetUserOrders()
    {
        try
        {
            var jwtString = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var id = _accountService.GetIdFromToken(jwtString!);

            if (id == null)
                return StatusCode(403, "Jwt token did not contain user id.");

            if (await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id) == null)
                return BadRequest("The token you tried to use is no longer valid.");

            var orders = await _orderService.GetAllUserOrders(id);

            return Ok(orders);
        }
        catch
        {
            return StatusCode(502, "Something went wrong fetching the account information. Please try again.");
        }
    }
}
