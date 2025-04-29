using AutoMapper;
using Odontoprev.Application.DTOs;
using Odontoprev.Domain.Entities;
using Odontoprev.Domain.Interfaces;
using Odontoprev.Domain.Interfaces.Repositories;

namespace Odontoprev.Application.Services;

public class PacienteService
{
    private readonly IPacienteRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PacienteService(IPacienteRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public PacienteService(IPacienteRepository repoMockObject, IMapper unitOfWork)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<PacienteDto>> GetAllAsync()
    {
        var entities = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<PacienteDto>>(entities);
    }

    public async Task<PacienteDto?> GetByIdAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        return _mapper.Map<PacienteDto?>(entity);
    }

    public async Task<PacienteDto> CreateAsync(PacienteDto dto)
    {
        var entity = _mapper.Map<PacienteOp>(dto);
        await _repository.AddAsync(entity);
        await _unitOfWork.CommitAsync();
        return _mapper.Map<PacienteDto>(entity);
    }

    public async Task UpdateAsync(PacienteDto dto)
    {
        var entity = _mapper.Map<PacienteOp>(dto);
        _repository.Update(entity);
        await _unitOfWork.CommitAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null) return;
        _repository.Delete(entity);
        await _unitOfWork.CommitAsync();
    }

    public Task AddAsync(PacienteDto dto)
    {
        throw new NotImplementedException();
    }
}