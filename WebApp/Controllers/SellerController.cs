using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Dtos;
using WebApp.Extensions;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers;

[Route("sellers")]
public class SellerController : ControllerBase
{
    private readonly ISellerService _sellerService;

    public SellerController(ISellerService sellerService)
    {
        _sellerService = sellerService;
    }

    [HttpGet("{name}")]
    public async Task<IActionResult> Detail(string name)
    {
        var seller = await _sellerService.FindByNameAsync(name);

        if (seller == null) return NotFound();
        return Ok(seller);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create([FromBody] SellerCreateRequestDto sellerInfo)
    {
        var currentUserId = this.GetCurrentUserId();
        if (currentUserId is null) return Unauthorized();

        var seller = new Seller
        {
            Name = sellerInfo.Name,
            PhoneNumber = sellerInfo.PhoneNumber,
            // TODO: Allow admin to create seller for any user
            UserId = currentUserId.Value,
        };

        var createdSeller = await _sellerService.CreateAsync(seller);

        return Ok(createdSeller);
    }
}