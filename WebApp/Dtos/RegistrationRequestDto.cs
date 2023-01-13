using System.ComponentModel.DataAnnotations;

namespace WebApp.Dtos;

public class RegistrationRequestDto
{
    [Required(ErrorMessage = "Email is required")]
    public required string Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    public required string Password { get; set; }
}