using WebApp.Models;

namespace WebApp.Services;

public interface ISellerService
{
    public Task<Seller?> FindByNameAsync(string name);

    public Task<Seller> CreateAsync(Seller seller);

    public Task<bool?> DeleteAsync(Guid guid);
}