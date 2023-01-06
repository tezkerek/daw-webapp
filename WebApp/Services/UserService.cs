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

    public async Task<User?> FindByIdAsync(string id)
    {
        return await _userRepository.FindByIdAsync(id);
    }

    public async Task<User?> CreateAsync(string email, string password)
    {
        return await _userRepository.CreateAsync(email, password);
    }
}