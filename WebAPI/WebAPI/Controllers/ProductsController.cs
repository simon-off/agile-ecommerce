using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using WebAPI.Helpers.Services;
using WebAPI.Interface.Services;
using WebAPI.Models.Entities;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct(int id)
    {
        try
        {
            var product = await _productService.GetById(id);

            if (product == null)
                return NotFound($"Could not find product with id: {id}.");

            return Ok(product);
        }
        catch
        {
            return StatusCode(502, "Something went wrong when fetching the data from the database. Please try again.");
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts([FromQuery] string? tagName, [FromQuery] string? categoryName)
    {
        try
        {
            List<Expression<Func<ProductEntity, bool>>> filters = new();

            // Adds filtering based on tags if query isn't empty
            if (!string.IsNullOrWhiteSpace(tagName))
                filters.Add(x =>
                    x.Tags.Any(tag => tag.Name.ToLower() == tagName.ToLower()));

            // Adds filtering based on categories if query isn't empty
            if (!string.IsNullOrWhiteSpace(categoryName))
                filters.Add(x =>
                    x.Category.Name.ToLower() == categoryName.ToLower());

            var products = await _productService.GetAllFilteredAsync(filters);

            if (products == null || !products.Any())
                return NotFound("Could not find any products.");

            return Ok(products);
        }
        catch
        {
            return StatusCode(502, "Something went wrong when fetching the data from the database. Please try again.");
        }
    }
}
