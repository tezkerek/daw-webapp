using Microsoft.EntityFrameworkCore;
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
}