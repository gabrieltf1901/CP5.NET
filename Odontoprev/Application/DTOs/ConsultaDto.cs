namespace Odontoprev.Application.DTOs;

public class ConsultaDto
{
    public int Id { get; set; }
    public DateTime Data { get; set; }

    public int PacienteId { get; set; }
    public int ProfissionalId { get; set; }

    public string Observacoes { get; set; } = string.Empty;
    
    public string? NomePaciente { get; set; }
    public string? NomeProfissional { get; set; }
}