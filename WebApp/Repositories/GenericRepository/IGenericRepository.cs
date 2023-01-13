using WebApp.Models.Base;

namespace WebApp.Repositories.GenericRepository;

public interface IGenericRepository<TEntity> where TEntity : IBaseEntity
{
}