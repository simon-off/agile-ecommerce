using Microsoft.AspNetCore.Mvc;
using WebAPI.Helpers.Services;
using WebAPI.Interface.Repositories;
using WebAPI.Interface.Services;
using WebAPI.Models.Schemas;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;
    private readonly IProductRepo _productRepo;
    private readonly ISizeRepo _sizeRepo;

    public OrdersController(IOrderService orderService, ProductService productService, ISizeRepo sizeRepo, IProductRepo productRepo)
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

            // Return created status code
            return StatusCode(201, orderDto);
        }
        catch
        {
            return StatusCode(502, "Something went wrong when processing the order. Please try again.");
        }
    }
}
