namespace Odontoprev.Application.DTOs;

public class PacienteDto
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public DateTime DataNascimento { get; set; }
    public string Documento { get; set; } = string.Empty;
}