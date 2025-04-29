using Odontoprev.Domain.Entities;

namespace Odontoprev.Domain.Interfaces.Repositories;

public interface IProfissionalRepository
{
    Task<IEnumerable<ProfissionalOp>> GetAllAsync();
    Task<ProfissionalOp?> GetByIdAsync(int id);
    Task AddAsync(ProfissionalOp entity);
    void Update(ProfissionalOp entity);
    void Delete(ProfissionalOp entity);
}