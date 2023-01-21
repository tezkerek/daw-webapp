using WebApp.Models;
using WebApp.Repositories.GenericRepository;

namespace WebApp.Repositories;

public interface ISellerRepository : IGenericRepository<Seller>
{
    public Task<Seller?> FindByNameAsync(string name);
}