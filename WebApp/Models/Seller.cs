using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using WebApp.Models.Base;

namespace WebApp.Models;

[Index(nameof(Name), IsUnique = true)]
public class Seller : BaseEntity
{
    [Required]
    public required string Name { get; set; }

    [Required]
    public required string PhoneNumber { get; set; }

    [Required]
    public Guid UserId { get; set; }

    public User User { get; set; }

    public ICollection<Ad> Ads { get; set; }
}