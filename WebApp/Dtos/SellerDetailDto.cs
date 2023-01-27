using System.Diagnostics.CodeAnalysis;
using WebApp.Models;

namespace WebApp.Dtos;

public class SellerDetailDto
{
    public SellerDetailDto()
    {
    }

    [SetsRequiredMembers]
    public SellerDetailDto(Seller seller) : this()
    {
        Id = seller.Id;
        Name = seller.Name;
        PhoneNumber = seller.PhoneNumber;
        DateCreated = seller.DateCreated;
        Ads = seller.Ads.Select(ad => new AdDetailDto(ad)).ToList();
    }

    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string PhoneNumber { get; set; }
    public required DateTime DateCreated { get; set; }

    public ICollection<AdDetailDto>? Ads { get; set; }
}