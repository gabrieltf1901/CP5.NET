using FluentValidation;
using Odontoprev.Application.DTOs;

namespace Odontoprev.Application.Validators;

public class ProcedimentoDtoValidator : AbstractValidator<ProcedimentoDto>
{
    public ProcedimentoDtoValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty().WithMessage("Nome do procedimento é obrigatório.");

        RuleFor(x => x.Codigo)
            .NotEmpty().WithMessage("Código é obrigatório.")
            .Length(5, 10);

        RuleFor(x => x.Valor)
            .GreaterThan(0).WithMessage("Valor deve ser maior que zero.");
    }
}