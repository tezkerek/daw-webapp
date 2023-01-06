using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers;

[ApiController]
[Route("/users")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegistrationRequestDto registrationInfo)
    {
        var result = await _userService.CreateAsync(registrationInfo.Email, registrationInfo.Password);

        if (result == null)
        {
            return BadRequest();
        }

        return Ok(result);
    }
}