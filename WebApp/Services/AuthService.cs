using Microsoft.AspNetCore.Identity;
using WebApp.Jwt;
using WebApp.Models;

namespace WebApp.Services;

class AuthService : IAuthService
{
    private readonly IJwtUtils _jwtUtils;
    private readonly IUserService _userService;
    private readonly UserManager<User> _userManager;

    public AuthService(IJwtUtils jwtUtils, IUserService userService, UserManager<User> userManager)
    {
        _jwtUtils = jwtUtils;
        _userService = userService;
        _userManager = userManager;
    }

    public async Task<AuthResponseDto?> Authenticate(AuthRequestDto authRequest)
    {
        var user = await _userService.FindByEmailAsync(authRequest.Email);

        if (user == null)
        {
            return null;
        }

        var verificationResult =
            _userManager.PasswordHasher.VerifyHashedPassword(
                user,
                user.PasswordHash,
                authRequest.Password
            );
        if (verificationResult == PasswordVerificationResult.Success)
        {
            var token = _jwtUtils.Generate(user.Id);
            var response = new AuthResponseDto { Token = token };
            return response;
        }

        return null;
    }
}