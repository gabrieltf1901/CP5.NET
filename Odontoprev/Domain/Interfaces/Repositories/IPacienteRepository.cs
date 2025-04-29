using Odontoprev.Domain.Entities;

namespace Odontoprev.Domain.Interfaces.Repositories;

public interface IPacienteRepository
{
    Task<IEnumerable<PacienteOp>> GetAllAsync();
    Task<PacienteOp?> GetByIdAsync(int id);
    Task AddAsync(PacienteOp entity);
    void Update(PacienteOp entity);
    void Delete(PacienteOp entity);
}