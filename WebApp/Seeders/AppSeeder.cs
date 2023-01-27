using Microsoft.AspNetCore.Identity;
using WebApp.Models;

namespace WebApp.Seeders;

public class AppSeeder
{
    private readonly AppDbContext _dbContext;
    private readonly UserManager<User> _userManager;

    public AppSeeder(AppDbContext dbContext, UserManager<User> userManager)
    {
        _dbContext = dbContext;
        _userManager = userManager;
    }

    public async Task Seed()
    {
        if (_userManager.Users.Any()) return;

        var user1 = new User { Email = "u1@example.com" };
        await _userManager.CreateAsync(user1, "Password1!");

        var seller1 = new Seller
        {
            Name = "LeSeller1",
            PhoneNumber = "0730",
            User = user1,
        };
        await _dbContext.Sellers.AddAsync(seller1);

        for (var i = 1; i <= 5; i++)
        {
            await _dbContext.Ads.AddAsync(
                new Ad
                {
                    Title = $"Ad {i}",
                    Description = $"I'm selling product {i}",
                    Price = i * 120,
                    IsActive = true,
                    Seller = seller1,
                }
            );
        }

        await _dbContext.SaveChangesAsync();
    }
}