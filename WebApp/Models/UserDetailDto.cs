using System.Diagnostics.CodeAnalysis;

namespace WebApp.Models;

public class UserDetailDto
{
    public UserDetailDto()
    {
    }
    
    [SetsRequiredMembers]
    public UserDetailDto(User user) : this()
    {
        Id = user.Id;
        Email = user.Email;
        DateCreated = user.DateCreated;
        DateModified = user.DateModified;
    }

    public required Guid Id { get; set; }
    public required string Email { get; set; }
    public required DateTime DateCreated { get; set; }
    public required DateTime DateModified { get; set; }
}