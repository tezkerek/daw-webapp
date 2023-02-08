using WebApp.Models;

namespace WebApp.Services;

public interface IAdService
{
    public Task<ICollection<Ad>> ListActive();
}