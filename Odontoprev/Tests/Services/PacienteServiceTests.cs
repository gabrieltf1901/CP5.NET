using Xunit;
using Moq;
using Odontoprev.Application.Services;
using Odontoprev.Application.DTOs;
using AutoMapper;
using Odontoprev.Domain.Entities;
using Odontoprev.Domain.Interfaces.Repositories;

public class PacienteServiceTests
{
    private readonly PacienteService _service;
    private readonly Mock<IPacienteRepository> _repoMock = new();
    private readonly IMapper _mapper;

    public PacienteServiceTests()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<PacienteOp, PacienteDto>().ReverseMap();
        });
        _mapper = config.CreateMapper();
        _service = new PacienteService(_repoMock.Object, _mapper);
    }

    [Theory]
    [InlineData(31, "João")]
    [InlineData(32, "Maria")]
    public async Task AddAsync_ShouldAddPaciente(int id, string nome)
    {
        var dto = new PacienteDto { Id = id, Nome = nome };

        await _service.AddAsync(dto);

        _repoMock.Verify(r => r.AddAsync(It.Is<PacienteOp>(p => p.Id == id && p.Nome == nome)), Times.Once);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnAll()
    {
        _repoMock.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<PacienteOp> {
            new() { Id = 1, Nome = "Teste" }
        });

        var result = await _service.GetAllAsync();

        Assert.Single(result);
    }
}