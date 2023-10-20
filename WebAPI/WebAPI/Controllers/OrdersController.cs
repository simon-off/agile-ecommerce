using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using WebAPI.Helpers.Repositories;
using WebAPI.Helpers.Services;
using WebAPI.Models.Entities;
using WebAPI.Models.Schemas;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly OrderService _orderService;
    private readonly ProductRepo _productRepo;
    private readonly SizeRepo _sizeRepo;

    public OrdersController(OrderService orderService, ProductService productService, SizeRepo sizeRepo, ProductRepo productRepo)
    {
        _orderService = orderService;
        _sizeRepo = sizeRepo;
        _productRepo = productRepo;
    }

    [HttpPost]
    public async Task<IActionResult> PlaceCustomerOrder(OrderCustomerCreateSchema schema)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            foreach (var item in schema.Products)
            {
                var product = await _productRepo.GetAsync(x => x.Id == item.ProductId);
                var size = await _sizeRepo.GetAsync(x => x.Id == item.SizeId);

                if (product == null || size == null)
                    return NotFound("One of the products requested could not be found in the database.");
            }

            var orderDto = await _orderService.PlaceCustomerOrderAsync(schema);

            return Ok(orderDto);
        }
        catch
        {
            return StatusCode(502, "Something went wrong when processing the order. Please try again.");
        }
    }
}
