using System.Diagnostics.CodeAnalysis;
using WebApp.Models;

namespace WebApp.Dtos;

public class AdDetailDto
{
    public AdDetailDto()
    {
    }

    [SetsRequiredMembers]
    public AdDetailDto(Ad ad) : this()
    {
        Id = ad.Id;
        Title = ad.Title;
        Description = ad.Description;
        Price = ad.Price;
        SellerName = ad.Seller.Name;
        DateCreated = ad.DateCreated;
    }

    public required Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required decimal Price { get; set; }
    public required string SellerName { get; set; }
    public required DateTime DateCreated { get; set; }
}