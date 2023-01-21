using Microsoft.AspNetCore.Mvc;
using WebApp.Dtos;
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
    public async Task<IActionResult> Create([FromBody] SellerCreateRequestDto sellerInfo)
    {
        var seller = new Seller
        {
            Name = sellerInfo.Name,
            PhoneNumber = sellerInfo.PhoneNumber,
        };
        if (sellerInfo.UserId is { } guid)
        {
            seller.UserId = guid;
        }

        var createdSeller = await _sellerService.CreateAsync(seller);

        return Ok(createdSeller);
    }
}