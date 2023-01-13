using WebApp.Dtos;

namespace WebApp.Services;

public interface IAuthService
{
    public Task<AuthResponseDto?> Authenticate(AuthRequestDto authRequest);
}