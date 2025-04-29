using Odontoprev.Domain.Entities;

namespace Odontoprev.Domain.Interfaces.Repositories;

public interface IProcedimentoRepository
{
    Task<IEnumerable<ProcedimentoOp>> GetAllAsync();
    Task<ProcedimentoOp?> GetByIdAsync(int id);
    Task AddAsync(ProcedimentoOp entity);
    void Update(ProcedimentoOp entity);
    void Delete(ProcedimentoOp entity);
}