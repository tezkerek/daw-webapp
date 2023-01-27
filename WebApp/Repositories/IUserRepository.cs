using WebApp.Models;

namespace WebApp.Repositories;

public interface IUserRepository
{
    public Task<User?> FindByEmailAsync(string email);

    Task<User?> FindByIdAsync(Guid id);

    public Task<User?> CreateAsync(string email, string password);

    public Task<bool?> DeleteAsync(Guid id);
}