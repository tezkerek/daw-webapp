using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers;

[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost]
    [Route("auth")]
    public async Task<IActionResult> Authenticate(AuthRequestDto authRequestInfo)
    {
        var result = await _authService.Authenticate(authRequestInfo);

        if (result == null)
        {
            return Forbid();
        }

        return Ok(result);
    }
}