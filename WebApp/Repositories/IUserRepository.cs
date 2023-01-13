using WebApp.Models;
using WebApp.Repositories.GenericRepository;

namespace WebApp.Repositories;

public interface IUserRepository : IGenericRepository<User>
{
    public Task<User?> FindByEmailAsync(string email);

    Task<User?> FindByIdAsync(string id);

    public Task<User?> CreateAsync(string email, string password);
    
    public Task<bool?> DeleteAsync(string id);
}