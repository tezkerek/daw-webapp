using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Repositories;

internal class UserRepository : IUserRepository
{
    private readonly AppDbContext _dbContext;
    private readonly UserManager<User> _userManager;

    public UserRepository(AppDbContext dbContext, UserManager<User> userManager)
    {
        _dbContext = dbContext;
        _userManager = userManager;
    }

    public async Task<User?> FindByEmailAsync(string email)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<User?> FindByIdAsync(Guid id)
    {
        return await _userManager.FindByIdAsync(id.ToString());
    }

    public async Task<User?> CreateAsync(string email, string password)
    {
        var user = new User
        {
            UserName = email,
            Email = email,
            PasswordHash = string.Empty,
        };

        var result = await _userManager.CreateAsync(user, password);

        if (result.Succeeded)
            return user;
        // TODO: How to return errors?
        return null;
    }

    public async Task<bool?> DeleteAsync(Guid id)
    {
        var user = await FindByIdAsync(id);
        if (user == null) return false;
        var result = await _userManager.DeleteAsync(user);
        return result.Succeeded;
    }
}