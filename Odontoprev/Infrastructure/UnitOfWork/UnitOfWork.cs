using Odontoprev.Domain.Interfaces;
using Odontoprev.Infrastructure.Data;

namespace Odontoprev.Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly OracleDbContext _context;

    public UnitOfWork(OracleDbContext context)
    {
        _context = context;
    }

    public async Task<int> CommitAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}