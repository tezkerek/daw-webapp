using WebApp.Dtos;
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

    public async Task<Seller?> FindByNameAsync(string name, bool includeAds = false)
    {
        return await _sellerRepository.FindByNameAsync(name, includeAds);
    }

    public async Task<Seller?> FindByIdAsync(Guid id)
    {
        return await _sellerRepository.FindByIdAsync(id);
    }

    public async Task<Seller> CreateAsync(Seller seller)
    {
        return await _sellerRepository.CreateAsync(seller);
    }

    public async Task<Seller> PatchAsync(Seller seller, SellerUpdateRequestDto sellerInfo)
    {
        seller.Name = sellerInfo.Name ?? seller.Name;
        seller.PhoneNumber = sellerInfo.PhoneNumber ?? seller.PhoneNumber;

        return await _sellerRepository.UpdateAsync(seller);
    }

    public async Task<bool?> DeleteAsync(Guid guid)
    {
        return await _sellerRepository.DeleteAsync(guid);
    }
}