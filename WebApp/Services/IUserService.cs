using WebApp.Models;

namespace WebApp.Services;

public interface IUserService
{
    public Task<User?> FindByEmailAsync(string email);
}