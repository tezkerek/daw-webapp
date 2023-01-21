using WebApp.Models.Base;

namespace WebApp.Repositories.GenericRepository;

public interface IGenericRepository<TEntity> where TEntity : IBaseEntity
{
    public Task<TEntity> CreateAsync(TEntity entity);

    public Task<bool?> DeleteAsync(Guid guid);
}