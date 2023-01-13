using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Extensions;
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
        var createdUser = await _userService.CreateAsync(
            registrationInfo.Email,
            registrationInfo.Password
        );

        if (createdUser == null)
        {
            return BadRequest();
        }

        var userDetail = new UserDetailDto(createdUser);
        return CreatedAtAction(
            nameof(Detail),
            new { id = createdUser.Id.ToString() },
            userDetail
        );
    }

    [HttpGet("{id}", Name = nameof(Detail))]
    [Authorize]
    public async Task<IActionResult> Detail(string id)
    {
        var currentUserId = this.GetCurrentUserId();
        if (id != currentUserId)
        {
            return Forbid();
        }

        var user = await _userService.FindByIdAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        var userDetail = new UserDetailDto(user);
        return Ok(userDetail);
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> Delete(string id)
    {
        var currentUserId = this.GetCurrentUserId();
        if (id != currentUserId)
        {
            return Forbid();
        }

        var wasDeleted = await _userService.DeleteAsync(id);

        return wasDeleted switch
        {
            null => NotFound(),
            true => NoContent(),
            false => BadRequest(),
        };
    }
}