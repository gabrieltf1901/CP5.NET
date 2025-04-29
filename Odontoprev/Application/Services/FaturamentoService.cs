using AutoMapper;
using Odontoprev.Application.DTOs;
using Odontoprev.Domain.Entities;
using Odontoprev.Domain.Interfaces;
using Odontoprev.Domain.Interfaces.Repositories;

namespace Odontoprev.Application.Services;

public class FaturamentoService
{
    private readonly IFaturamentoRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public FaturamentoService(IFaturamentoRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<FaturamentoDto>> GetAllAsync()
    {
        var entities = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<FaturamentoDto>>(entities);
    }

    public async Task<FaturamentoDto?> GetByIdAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        return _mapper.Map<FaturamentoDto?>(entity);
    }

    public async Task<FaturamentoDto> CreateAsync(FaturamentoDto dto)
    {
        var entity = _mapper.Map<FaturamentoOp>(dto);
        await _repository.AddAsync(entity);
        await _unitOfWork.CommitAsync();
        return _mapper.Map<FaturamentoDto>(entity);
    }

    public async Task UpdateAsync(FaturamentoDto dto)
    {
        var entity = _mapper.Map<FaturamentoOp>(dto);
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

    public Task AddAsync(FaturamentoDto dto)
    {
        throw new NotImplementedException();
    }
}