using Microsoft.AspNetCore.Mvc;
using WebApp.Dtos;
using WebApp.Services;

namespace WebApp.Controllers;

[Route("ads")]
public class AdController : ControllerBase
{
    private readonly IAdService _adService;

    public AdController(IAdService adService)
    {
        _adService = adService;
    }

    [HttpGet]
    public async Task<IActionResult> List()
    {
        var ads = await _adService.ListActive();

        return Ok(ads.Select(ad => new AdDetailDto(ad)));
    }
}