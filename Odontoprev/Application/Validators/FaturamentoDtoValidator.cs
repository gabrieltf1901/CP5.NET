using FluentValidation;
using Odontoprev.Application.DTOs;

namespace Odontoprev.Application.Validators;

public class FaturamentoDtoValidator : AbstractValidator<FaturamentoDto>
{
    public FaturamentoDtoValidator()
    {
        RuleFor(x => x.ConsultaId)
            .GreaterThan(0).WithMessage("ConsultaId inválido.");

        RuleFor(x => x.DataFaturamento)
            .NotEmpty().WithMessage("Data de faturamento é obrigatória.");

        RuleFor(x => x.ValorTotal)
            .GreaterThan(0).WithMessage("Valor total deve ser maior que zero.");
    }
}