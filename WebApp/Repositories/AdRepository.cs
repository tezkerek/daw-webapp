using Microsoft.EntityFrameworkCore;
using WebApp.Dtos;
using WebApp.Models;
using WebApp.Repositories.GenericRepository;
using WebApp.Services;

namespace WebApp.Repositories;

public class AdRepository : GenericRepository<Ad>, IAdRepository
{
    private readonly AppDbContext _dbContext;
    private readonly DbSet<Ad> _adSet;

    public AdRepository(AppDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
        _adSet = _dbContext.Ads;
    }

    public async Task<ICollection<Ad>> ListActive()
    {
        var queryable = from ad in _dbContext.Ads.Include(ad => ad.Seller)
            where ad.IsActive
            select ad;
        return await queryable.ToListAsync();
    }

    public async Task<ICollection<Tuple<string, decimal>>> MaxPriceBySeller()
    {
        var maxPricesBySellerId =
            from ad in _adSet
            group ad.Price by ad.SellerId
            into grouped
            select new { Id = grouped.Key, MaxPrice = grouped.Max() };

        var maxPricesBySellerName =
            from p in maxPricesBySellerId
            join seller in _dbContext.Sellers
                on p.Id equals seller.Id
            select new Tuple<string, decimal>(seller.Name, p.MaxPrice);

        return await maxPricesBySellerName.ToListAsync();
    }
}