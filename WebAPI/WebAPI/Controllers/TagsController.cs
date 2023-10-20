using Microsoft.AspNetCore.Mvc;
using WebAPI.Helpers.Services;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TagsController : ControllerBase
{
    private readonly TagService _tagService;

    public TagsController(TagService tagService)
    {
        _tagService = tagService;
    }

    [HttpGet]
    public async Task<ActionResult> GetTags()
    {
        try
        {
            var tags = await _tagService.GetAllAsync();

            if (tags == null || !tags.Any())
                return NotFound("Could not find any categories.");

            return Ok(tags);
        }
        catch
        {
            return StatusCode(502, "Something went wrong when fetching the data from the database. Please try again.");
        }
    }
}
