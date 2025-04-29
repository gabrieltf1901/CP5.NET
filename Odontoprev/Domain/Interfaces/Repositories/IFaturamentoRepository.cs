using Odontoprev.Domain.Entities;

namespace Odontoprev.Domain.Interfaces.Repositories;

public interface IFaturamentoRepository
{
    Task<IEnumerable<FaturamentoOp>> GetAllAsync();
    Task<FaturamentoOp?> GetByIdAsync(int id);
    Task AddAsync(FaturamentoOp entity);
    void Update(FaturamentoOp entity);
    void Delete(FaturamentoOp entity);
}