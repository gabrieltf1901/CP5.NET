using AutoMapper;
using Odontoprev.Application.DTOs;
using Odontoprev.Domain.Entities;
using Odontoprev.Domain.Interfaces;
using Odontoprev.Domain.Interfaces.Repositories;

namespace Odontoprev.Application.Services;

public class ProcedimentoService
{
    private readonly IProcedimentoRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ProcedimentoService(IProcedimentoRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProcedimentoDto>> GetAllAsync()
    {
        var entities = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<ProcedimentoDto>>(entities);
    }

    public async Task<ProcedimentoDto?> GetByIdAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        return _mapper.Map<ProcedimentoDto?>(entity);
    }

    public async Task<ProcedimentoDto> CreateAsync(ProcedimentoDto dto)
    {
        var entity = _mapper.Map<ProcedimentoOp>(dto);
        await _repository.AddAsync(entity);
        await _unitOfWork.CommitAsync();
        return _mapper.Map<ProcedimentoDto>(entity);
    }

    public async Task UpdateAsync(ProcedimentoDto dto)
    {
        var entity = _mapper.Map<ProcedimentoOp>(dto);
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

    public Task AddAsync(ProcedimentoDto dto)
    {
        throw new NotImplementedException();
    }
}