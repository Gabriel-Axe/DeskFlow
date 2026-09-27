using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DeskFlow.Controllers;

[ApiController]
[Route("[controller]")]
public class PingController : ControllerBase
{
  [HttpGet]
  public IActionResult Ping()
  {
    return Ok("Pong");
  }
}
