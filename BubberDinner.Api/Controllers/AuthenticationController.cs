using Microsoft.AspNetCore.Mvc;
using BubberDinner.Contracts.Authentication;
using BubberDinner.Application.Services.Authentication;
using BubberDinner.Api.Filters;

namespace BubberDinner.Api.Controller;


[ApiController]
[Route("auth")]
[ErrorHandlingFilter]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController (IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("register")]
    public IActionResult Register (RegisterRequest request)
    {
        var result = _authenticationService.Register(request.FirstName, 
        request.LastName, 
        request.Email, 
        request.Password);

        var response = new AuthenticationResponse(
            result.user.Id,
            result.user.FirstName,
            result.user.LastName,
            result.user.Email,
            result.Token
        );

        return Ok(response);
    }

    [HttpPost("login")]
    public IActionResult Login (LoginRequest request)
    {
        var result = _authenticationService.Login(
        request.Email, 
        request.Password);

        var response = new AuthenticationResponse(
            result.user.Id,
            result.user.FirstName,
            result.user.LastName,
            result.user.Email,
            result.Token
        );

        return Ok(response);
    }
}