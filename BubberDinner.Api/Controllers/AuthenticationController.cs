using Microsoft.AspNetCore.Mvc;
using BubberDinner.Contracts.Authentication;

namespace BubberDinner.Api.Controller;


[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
    [HttpPost("register")]
    public IActionResult Register (RegisterRequest request)
    {
        return Ok(request);
    }

    [HttpPost("login")]
    public IActionResult Login (LoginRequest request)
    {
        return Ok(request);
    }
}