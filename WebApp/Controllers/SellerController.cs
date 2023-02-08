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
        var seller = await _sellerService.FindByNameAsync(name, includeAds: true);

        if (seller == null) return NotFound();
        return Ok(new SellerDetailDto(seller));
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

        return Ok(new SellerDetailDto(createdSeller));
    }

    [HttpPatch("{id}")]
    [Authorize]
    public async Task<IActionResult> Update(Guid id, [FromBody] SellerUpdateRequestDto sellerInfo)
    {
        var currentUserId = this.GetCurrentUserId();
        if (currentUserId is null) return Unauthorized();

        var seller = await _sellerService.FindByIdAsync(id);
        
        if (seller is null) return NotFound();
        if (seller.UserId != currentUserId) return Forbid();

        var updatedSeller = _sellerService.PatchAsync(seller, sellerInfo);
        return Ok(updatedSeller);
    }
}