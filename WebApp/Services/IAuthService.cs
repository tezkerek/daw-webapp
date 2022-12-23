using WebApp.Models;

namespace WebApp.Services;

public interface IAuthService
{
    public Task<AuthResponseDto?> Authenticate(AuthRequestDto authRequest);
}