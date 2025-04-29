namespace Odontoprev.Application.DTOs;

public class FaturamentoDto
{
    public int Id { get; set; }
    public int ConsultaId { get; set; }
    public DateTime DataFaturamento { get; set; }
    public decimal ValorTotal { get; set; }


    public string? NomePaciente { get; set; }
    public string? NomeProfissional { get; set; }
}