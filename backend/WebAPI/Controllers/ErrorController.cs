using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ErrorController : ControllerBase
{
    [HttpGet]
    public ActionResult Error()
    {
        return Problem("Something went wrong. Please try again.");
    }
}