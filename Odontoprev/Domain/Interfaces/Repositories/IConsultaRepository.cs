using Odontoprev.Domain.Entities;

namespace Odontoprev.Domain.Interfaces.Repositories;

public interface IConsultaRepository
{
    Task<IEnumerable<ConsultaOp>> GetAllAsync();
    Task<ConsultaOp?> GetByIdAsync(int id);
    Task AddAsync(ConsultaOp entity);
    void Update(ConsultaOp entity);
    void Delete(ConsultaOp entity);
}