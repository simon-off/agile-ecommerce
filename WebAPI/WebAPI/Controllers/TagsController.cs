using Microsoft.AspNetCore.Mvc;
using WebAPI.Interface.Services;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TagsController : ControllerBase
{
    private readonly ITagService _tagService;

    public TagsController(ITagService tagService)
    {
        _tagService = tagService;
    }

    [HttpGet]
    public async Task<ActionResult> GetTags()
    {
        try
        {
            var tags = await _tagService.GetAllAsync();

            return Ok(tags);
        }
        catch
        {
            return StatusCode(502, "Something went wrong when fetching the data from the database. Please try again.");
        }
    }
}
