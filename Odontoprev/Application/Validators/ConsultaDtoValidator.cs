using FluentValidation;
using Odontoprev.Application.DTOs;

namespace Odontoprev.Application.Validators;

public class ConsultaDtoValidator : AbstractValidator<ConsultaDto>
{
    public ConsultaDtoValidator()
    {
        RuleFor(x => x.Data)
            .NotEmpty().WithMessage("Data da consulta é obrigatória.")
            .GreaterThan(DateTime.MinValue);

        RuleFor(x => x.PacienteId)
            .GreaterThan(0).WithMessage("PacienteId inválido.");

        RuleFor(x => x.ProfissionalId)
            .GreaterThan(0).WithMessage("ProfissionalId inválido.");
    }
}