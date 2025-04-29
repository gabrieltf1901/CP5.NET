using Microsoft.AspNetCore.Mvc;
using Odontoprev.Application.DTOs;
using Odontoprev.Application.Services;

namespace Odontoprev.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProcedimentoController : ControllerBase
{
    private readonly ProcedimentoService _service;

    public ProcedimentoController(ProcedimentoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id) => Ok(await _service.GetByIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ProcedimentoDto dto)
    {
        await _service.AddAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] ProcedimentoDto dto)
    {
        if (id != dto.Id) return BadRequest("ID mismatch");
        await _service.UpdateAsync(dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}