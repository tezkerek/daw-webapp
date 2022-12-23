using WebApp.Models;
using WebApp.Repositories;

namespace WebApp.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User?> FindByEmailAsync(string email)
    {
        return await _userRepository.FindByEmailAsync(email);
    }
}