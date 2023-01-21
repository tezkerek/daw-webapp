using WebApp.Models;
using WebApp.Repositories;

namespace WebApp.Services;

public class SellerService : ISellerService
{
    private readonly ISellerRepository _sellerRepository;

    public SellerService(ISellerRepository sellerRepository)
    {
        _sellerRepository = sellerRepository;
    }

    public async Task<Seller?> FindByNameAsync(string name)
    {
        return await _sellerRepository.FindByNameAsync(name);
    }

    public async Task<Seller?> CreateAsync(Seller seller)
    {
        return await _sellerRepository.CreateAsync(seller);
    }

    public async Task<bool?> DeleteAsync(Guid guid)
    {
        return await _sellerRepository.DeleteAsync(guid);
    }
}