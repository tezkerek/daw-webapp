using Microsoft.EntityFrameworkCore;
using WebApp.Models;
using WebApp.Repositories.GenericRepository;

namespace WebApp.Repositories;

public class SellerRepository : GenericRepository<Seller>, ISellerRepository
{
    private readonly AppDbContext _dbContext;

    public SellerRepository(AppDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Seller?> FindByNameAsync(string name, bool includeAds = false)
    {
        var query = _dbContext.Sellers.AsQueryable();
        if (includeAds)
        {
            query = query.Include(seller => seller.Ads.OrderByDescending(ad => ad.DateCreated));
        }

        return await query.FirstOrDefaultAsync(seller => seller.Name == name);
    }
}