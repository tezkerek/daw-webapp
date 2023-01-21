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

    public async Task<Seller?> FindByNameAsync(string name)
    {
        return await _dbContext.Sellers.FirstOrDefaultAsync(seller => seller.Name == name);
    }
}