using WebApp.Models;
using WebApp.Repositories.GenericRepository;

namespace WebApp.Repositories;

public interface IAdRepository : IGenericRepository<Ad>
{
    public Task<ICollection<Ad>> ListActive();
}