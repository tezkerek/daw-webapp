using WebApp.Models;

namespace WebApp.Services;

public interface IUserService
{
    public Task<User?> FindByEmailAsync(string email);

    public Task<User?> FindByIdAsync(Guid id);

    public Task<User?> CreateAsync(string email, string password);

    public Task<bool?> DeleteAsync(Guid id);
}