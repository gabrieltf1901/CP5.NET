using Microsoft.EntityFrameworkCore;
using Odontoprev.Infrastructure.Data;

namespace Odontoprev.Infrastructure.Repositories;

public class BaseRepository<TEntity> where TEntity : class
{
    protected readonly OracleDbContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    public BaseRepository(OracleDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        => await _dbSet.ToListAsync();

    public virtual async Task<TEntity?> GetByIdAsync(int id)
        => await _dbSet.FindAsync(id);

    public virtual async Task AddAsync(TEntity entity)
        => await _dbSet.AddAsync(entity);

    public virtual void Update(TEntity entity)
        => _dbSet.Update(entity);

    public virtual void Delete(TEntity entity)
        => _dbSet.Remove(entity);
}