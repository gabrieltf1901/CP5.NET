using FluentValidation;
using Odontoprev.Application.DTOs;

namespace Odontoprev.Application.Validators;

public class ProfissionalDtoValidator : AbstractValidator<ProfissionalDto>
{
    public ProfissionalDtoValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty().WithMessage("Nome é obrigatório.")
            .MaximumLength(100);

        RuleFor(x => x.Crm)
            .NotEmpty().WithMessage("CRM é obrigatório.")
            .MaximumLength(20);

        RuleFor(x => x.Especialidade)
            .NotEmpty().WithMessage("Especialidade é obrigatória.");
    }
}