using Microsoft.AspNetCore.Mvc;
using WebAPI.Interface.Repositories;
using WebAPI.Interface.Services;
using WebAPI.Models.Dtos;
using WebAPI.Models.QueryParameters;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly IProductRepo _productRepo;

    public ProductsController(IProductService productService, IProductRepo productRepo)
    {
        _productService = productService;
        _productRepo = productRepo;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct(int id)
    {
        var product = await _productService.GetByIdAsync(id);

        if (product == null)
            return NotFound($"Could not find product with id: {id}.");

        return Ok(product);
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts([FromQuery] GetProductsQueryParameters queryParameters)
    {
        var products = await _productService.GetAllAsync(queryParameters);

        return Ok(products);
    }

    [HttpGet("Count")]
    public async Task<IActionResult> GetProductCount([FromQuery] string? tag, [FromQuery] string? category)
    {
        var productCount = await _productRepo.GetProductCount(tag, category);
        return Ok(productCount);
    }
}
