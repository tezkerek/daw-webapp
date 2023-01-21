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
    public required Guid SellerId { get; set; }

    public required Seller Seller { get; set; }
    
    public required ICollection<User> WatchingUsers { get; set; }
}