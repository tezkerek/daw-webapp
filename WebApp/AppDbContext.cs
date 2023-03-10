using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp;

public class AppDbContext : IdentityDbContext<User, UserRole, Guid>
{
    public required DbSet<Seller> Sellers { get; set; }
    public required DbSet<Ad> Ads { get; set; }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}