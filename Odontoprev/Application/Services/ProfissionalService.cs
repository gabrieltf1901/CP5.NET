using AutoMapper;
using Odontoprev.Application.DTOs;
using Odontoprev.Domain.Entities;
using Odontoprev.Domain.Interfaces;
using Odontoprev.Domain.Interfaces.Repositories;

namespace Odontoprev.Application.Services;

public class ProfissionalService
{
    private readonly IProfissionalRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ProfissionalService(IProfissionalRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProfissionalDto>> GetAllAsync()
    {
        var entities = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<ProfissionalDto>>(entities);
    }

    public async Task<ProfissionalDto?> GetByIdAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        return _mapper.Map<ProfissionalDto?>(entity);
    }

    public async Task<ProfissionalDto> CreateAsync(ProfissionalDto dto)
    {
        var entity = _mapper.Map<ProfissionalOp>(dto);
        await _repository.AddAsync(entity);
        await _unitOfWork.CommitAsync();
        return _mapper.Map<ProfissionalDto>(entity);
    }

    public async Task UpdateAsync(ProfissionalDto dto)
    {
        var entity = _mapper.Map<ProfissionalOp>(dto);
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

    public Task AddAsync(ProfissionalDto dto)
    {
        throw new NotImplementedException();
    }
}