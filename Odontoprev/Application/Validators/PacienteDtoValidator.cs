using FluentValidation;
using Odontoprev.Application.DTOs;

namespace Odontoprev.Application.Validators;

public class PacienteDtoValidator : AbstractValidator<PacienteDto>
{
    public PacienteDtoValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty().WithMessage("Nome é obrigatório.")
            .MaximumLength(100);

        RuleFor(x => x.Documento)
            .NotEmpty().WithMessage("Documento é obrigatório.")
            .Length(11).WithMessage("Documento deve ter 11 caracteres.");

        RuleFor(x => x.DataNascimento)
            .LessThan(DateTime.Today).WithMessage("Data de nascimento deve ser no passado.");
    }
}