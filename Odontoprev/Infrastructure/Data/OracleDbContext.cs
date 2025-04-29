using Microsoft.EntityFrameworkCore;
using Odontoprev.Domain.Entities;

namespace Odontoprev.Infrastructure.Data;

public class OracleDbContext : DbContext
{
    public OracleDbContext(DbContextOptions<OracleDbContext> options) : base(options) {}

    public DbSet<PacienteOp> Pacientes => Set<PacienteOp>();
    public DbSet<ProfissionalOp> Profissionais => Set<ProfissionalOp>();
    public DbSet<ConsultaOp> Consultas => Set<ConsultaOp>();
    public DbSet<ProcedimentoOp> Procedimentos => Set<ProcedimentoOp>();
    public DbSet<FaturamentoOp> Faturamentos => Set<FaturamentoOp>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ConsultaOp>()
            .HasOne(c => c.Paciente)
            .WithMany()
            .HasForeignKey(c => c.PacienteId);

        modelBuilder.Entity<ConsultaOp>()
            .HasOne(c => c.Profissional)
            .WithMany()
            .HasForeignKey(c => c.ProfissionalId);

        modelBuilder.Entity<FaturamentoOp>()
            .HasOne(f => f.Consulta)
            .WithMany()
            .HasForeignKey(f => f.ConsultaId);

        // Precision Oracle (exemplo para decimal)
        modelBuilder.Entity<ProcedimentoOp>()
            .Property(p => p.Valor)
            .HasPrecision(10, 2);

        modelBuilder.Entity<FaturamentoOp>()
            .Property(f => f.ValorTotal)
            .HasPrecision(10, 2);
    }
}