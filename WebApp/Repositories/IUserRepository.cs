using WebApp.Models;
using WebApp.Repositories.GenericRepository;

namespace WebApp.Repositories;

public interface IUserRepository : IGenericRepository<User>
{
    public Task<User?> FindByEmailAsync(string email);

    public Task<User?> CreateAsync(string email, string password);
}