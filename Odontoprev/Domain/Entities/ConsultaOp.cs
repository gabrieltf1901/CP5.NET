namespace Odontoprev.Domain.Entities;

public class ConsultaOp
{
    public int Id { get; set; }
    public int PacienteId { get; set; }
    public int ProfissionalId { get; set; }
    public DateTime DataConsulta { get; set; }

    public PacienteOp? Paciente { get; set; }
    public ProfissionalOp? Profissional { get; set; }
}