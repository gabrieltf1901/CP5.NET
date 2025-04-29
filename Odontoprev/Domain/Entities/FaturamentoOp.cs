namespace Odontoprev.Domain.Entities;

public class FaturamentoOp
{
    public int Id { get; set; }
    public int ConsultaId { get; set; }
    public decimal ValorTotal { get; set; }
    public DateTime DataFaturamento { get; set; }

    public ConsultaOp? Consulta { get; set; }
}