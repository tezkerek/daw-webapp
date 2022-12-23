using System.Security.Claims;

namespace WebApp.Jwt;

public interface IJwtUtils
{
    string Generate(Guid guid);
    public string Generate(IEnumerable<Claim> claims);
    public Guid Validate(string token);
}