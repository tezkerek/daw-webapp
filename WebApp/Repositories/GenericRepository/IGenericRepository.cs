using WebApp.Models.Base;

namespace WebApp.Repositories.GenericRepository;

public interface IGenericRepository<TEntity> where TEntity : IBaseEntity
{
    public Task<ICollection<TEntity>> ListAsync();

    public Task<TEntity?> FindByIdAsync(Guid id);

    public Task<TEntity> CreateAsync(TEntity entity);

    public Task<TEntity> UpdateAsync(TEntity entity);

    public Task<bool?> DeleteAsync(Guid guid);
}