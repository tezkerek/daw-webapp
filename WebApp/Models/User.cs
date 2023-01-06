using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using WebApp.Models.Base;

namespace WebApp.Models;

public class User : IdentityUser<Guid>, IBaseEntity
{
    [ProtectedPersonalData]
    [Required]
    public override required string Email { get; set; }

    [ProtectedPersonalData]
    [Required]
    public override required string PasswordHash { get; set; }

    [Required]
    public DateTime DateCreated { get; set; } = DateTime.Now.ToUniversalTime();

    [Required]
    public DateTime DateModified { get; set; } = DateTime.Now.ToUniversalTime();
}