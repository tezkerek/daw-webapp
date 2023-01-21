using System.ComponentModel.DataAnnotations;

namespace WebApp.Dtos;

public class SellerCreateRequestDto
{
    [Required]
    public required string Name { get; set; }

    [Required]
    public required string PhoneNumber { get; set; }
    
    public Guid? UserId { get; set; }
}