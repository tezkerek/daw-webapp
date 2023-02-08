using WebApp.Models;
using WebApp.Repositories;

namespace WebApp.Services;

public class AdService : IAdService
{
    private readonly IAdRepository _adRepository;

    public AdService(IAdRepository adRepository)
    {
        _adRepository = adRepository;
    }

    public async Task<ICollection<Ad>> ListActive()
    {
        return await _adRepository.ListActive();
    }
}