using AutoMapper;
using Odontoprev.Application.DTOs;
using Odontoprev.Domain.Entities;
using Odontoprev.Domain.Interfaces;
using Odontoprev.Domain.Interfaces.Repositories;

namespace Odontoprev.Application.Services;

public class ConsultaService
{
    private readonly IConsultaRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ConsultaService(IConsultaRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ConsultaDto>> GetAllAsync()
    {
        var entities = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<ConsultaDto>>(entities);
    }

    public async Task<ConsultaDto?> GetByIdAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        return _mapper.Map<ConsultaDto?>(entity);
    }

    public async Task<ConsultaDto> CreateAsync(ConsultaDto dto)
    {
        var entity = _mapper.Map<ConsultaOp>(dto);
        await _repository.AddAsync(entity);
        await _unitOfWork.CommitAsync();
        return _mapper.Map<ConsultaDto>(entity);
    }

    public async Task UpdateAsync(ConsultaDto dto)
    {
        var entity = _mapper.Map<ConsultaOp>(dto);
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

    public Task AddAsync(ConsultaDto dto)
    {
        throw new NotImplementedException();
    }
}