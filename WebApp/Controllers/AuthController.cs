using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class AuthController : ControllerBase
{
    public async Task<IActionResult> Authenticate(AuthRequestDto authRequestInfo)
    {
        return Ok();
    }
}