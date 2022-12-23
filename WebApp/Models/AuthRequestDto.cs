using System.ComponentModel.DataAnnotations;

namespace WebApp.Models;

public class AuthRequestDto
{
    [Required(ErrorMessage = "Email is required")]
    public required string Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    public required string Password { get; set; }
}