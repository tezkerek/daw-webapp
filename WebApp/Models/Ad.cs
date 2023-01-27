using System.ComponentModel.DataAnnotations;
using WebApp.Models.Base;

namespace WebApp.Models;

public class Ad : BaseEntity
{
    [Required]
    public required string Title { get; set; }

    [Required]
    public required string Description { get; set; }

    [Required]
    public required decimal Price { get; set; }

    [Required]
    public required bool IsActive { get; set; }

    [Required]
    public Guid SellerId { get; set; }

    public Seller Seller { get; set; } = null!;

    public ICollection<User> WatchingUsers { get; set; } = null!;
}