using Microsoft.AspNetCore.Mvc;
using WebAPI.Interface.Services;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<ActionResult> GetCategories()
    {
        try
        {
            var categories = await _categoryService.GetAllAsync();

            if (categories == null || !categories.Any()) 
                return NotFound("Could not find any categories.");

            return Ok(categories);
        }
        catch
        {
            return StatusCode(502, "Something went wrong when fetching the data from the database. Please try again.");
        }
    }
}
