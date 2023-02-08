using Microsoft.EntityFrameworkCore;
using WebApp.Models.Base;

namespace WebApp.Repositories.GenericRepository;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
{
    private readonly AppDbContext _dbContext;
    private readonly DbSet<TEntity> _entitySet;

    public GenericRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        _entitySet = _dbContext.Set<TEntity>();
    }

    public async Task<ICollection<TEntity>> ListAsync()
    {
        var rows = from row in _entitySet select row;
        return await rows.ToListAsync();
    }

    public async Task<TEntity?> FindByIdAsync(Guid id)
    {
        return await _entitySet.FirstOrDefaultAsync(entity => entity.Id == id);
    }

    public async Task<TEntity> CreateAsync(TEntity entity)
    {
        var result = _entitySet.Add(entity);
        await _dbContext.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        var newEntity = _dbContext.Update(entity);
        await _dbContext.SaveChangesAsync();

        return newEntity.Entity;
    }

    public async Task DeleteAsync(TEntity entity)
    {
        _entitySet.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool?> DeleteAsync(Guid guid)
    {
        var entity = await _entitySet.FindAsync(guid);
        if (entity == null) return null;

        await DeleteAsync(entity);
        return true;
    }
}