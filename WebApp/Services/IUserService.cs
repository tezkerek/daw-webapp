using WebApp.Models;

namespace WebApp.Services;

public interface IUserService
{
    public Task<User?> FindByEmailAsync(string email);

    public Task<User?> FindByIdAsync(string id);

    public Task<User?> CreateAsync(string email, string password);
}