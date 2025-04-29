using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Odontoprev.Presentation.Controllers;
using Odontoprev.Application.Services;
using Odontoprev.Application.DTOs;

public class PacienteControllerTests
{
    private readonly Mock<PacienteService> _serviceMock = new();
    private readonly PacienteController _controller;

    public PacienteControllerTests()
    {
        _controller = new PacienteController(_serviceMock.Object);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public async Task GetById_ShouldReturnOk(int id)
    {
        _serviceMock.Setup(s => s.GetByIdAsync(id)).ReturnsAsync(new PacienteDto { Id = id });

        var result = await _controller.GetById(id);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var dto = Assert.IsType<PacienteDto>(okResult.Value);
        Assert.Equal(id, dto.Id);
    }

    [Fact]
    public async Task Create_ShouldReturnCreatedAtAction()
    {
        var dto = new PacienteDto { Id = 10, Nome = "Novo" };

        var result = await _controller.Create(dto);

        var created = Assert.IsType<CreatedAtActionResult>(result);
        var value = Assert.IsType<PacienteDto>(created.Value);
        Assert.Equal(dto.Id, value.Id);
    }
}