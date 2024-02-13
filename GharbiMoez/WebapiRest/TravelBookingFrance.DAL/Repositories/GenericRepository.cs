using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TravelBookingFrance.DAL.DataContext;
using TravelBookingFrance.DAL.Repositories.IRepositories;

namespace TravelBookingFrance.DAL.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, new()
{
    private readonly DataAppContext _DbContext;
    public GenericRepository(DataAppContext DbContext)
    {
        _DbContext = DbContext;
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        await _DbContext.AddAsync(entity);
        await _DbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<List<TEntity>> AddRangeAsync(List<TEntity> entity)
    {
        await _DbContext.AddRangeAsync(entity);
        await _DbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<int> DeleteAsync(TEntity entity)
    {
        _ = _DbContext.Remove(entity);
        return await _DbContext.SaveChangesAsync();
    }

    public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter = null, CancellationToken cancellationToken = default)
    {
        return await _DbContext.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(filter, cancellationToken);
    }

    public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null, CancellationToken cancellationToken = default)
    {
        return await (filter == null ? _DbContext.Set<TEntity>().ToListAsync(cancellationToken) : _DbContext.Set<TEntity>().Where(filter).ToListAsync(cancellationToken));
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        _ = _DbContext.Update(entity);
        await _DbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<List<TEntity>> UpdateRangeAsync(List<TEntity> entity)
    {
        _DbContext.UpdateRange(entity);
        await _DbContext.SaveChangesAsync();
        return entity;
    }
}
