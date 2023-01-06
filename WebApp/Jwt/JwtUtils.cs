using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace WebApp.Jwt;

public class JwtUtils : IJwtUtils
{
    private readonly AppSettings _appSettings;

    public JwtUtils(IOptions<AppSettings> appSettings)
    {
        _appSettings = appSettings.Value;
    }

    public string Generate(Guid guid)
    {
        return Generate(new[] { new Claim("id", guid.ToString()) });
    }

    public string Generate(IEnumerable<Claim> claims)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var jwtSecret = Encoding.UTF8.GetBytes(_appSettings.JwtSecret);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(10),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(jwtSecret),
                SecurityAlgorithms.HmacSha256Signature
            ),
            Issuer = _appSettings.JwtIssuer,
            Audience = _appSettings.JwtAudience,
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }

    public Guid Validate(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var appPrivateKey = Encoding.ASCII.GetBytes(_appSettings.JwtSecret);

        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(appPrivateKey),
            ValidateIssuer = true,
            ValidateAudience = false,
            ClockSkew = TimeSpan.Zero,
        };

        try
        {
            tokenHandler.ValidateToken(
                token,
                tokenValidationParameters,
                out SecurityToken validatedToken
            );

            var jwtToken = (JwtSecurityToken)validatedToken;
            var idClaim = jwtToken.Claims.FirstOrDefault(x => x.Type == "id");

            if (idClaim == null)
            {
                return Guid.Empty;
            }

            var userId = new Guid(idClaim.Value);

            return userId;
        }
        catch
        {
            return Guid.Empty;
        }
    }
}