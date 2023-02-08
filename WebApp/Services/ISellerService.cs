using WebApp.Dtos;
using WebApp.Models;

namespace WebApp.Services;

public interface ISellerService
{
    public Task<Seller?> FindByNameAsync(string name, bool includeAds = false);
    
    public Task<Seller?> FindByIdAsync(Guid id);

    public Task<Seller> CreateAsync(Seller seller);

    public Task<Seller> PatchAsync(Seller seller, SellerUpdateRequestDto sellerInfo);

    public Task<bool?> DeleteAsync(Guid guid);
}