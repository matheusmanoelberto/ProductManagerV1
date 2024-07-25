using FluentValidation;
using ProductManager.Domain.Models.Entities;
using ProductManager.Domain.Models.Validations.Documents;

namespace ProductManager.Domain.Models.Validations;

public class SupplierValidation : AbstractValidator<Supplier>
{
    public SupplierValidation()
    {
        RuleFor(s => s.Name).NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
               .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

        When(s => s.TypeSupplier == Enums.TypeSupplier.PersonFhysical, () =>
        {
            RuleFor(s => s.Document.Length).Equal(CpfValidacao.TamanhoCpf)
                    .WithMessage("O campo Documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");

            RuleFor(s => CpfValidacao.Validar(s.Document)).Equal(true)
                .WithMessage("O documento fornecido é inválido.");
        });

        When(s => s.TypeSupplier == Enums.TypeSupplier.PersonLegal, () =>
        {
            RuleFor(s => s.Document.Length).Equal(CnpjValidacao.TamanhoCnpj)
                    .WithMessage("O campo Documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");

            RuleFor(s => CnpjValidacao.Validar(s.Document)).Equal(true)
                .WithMessage("O documento fornecido é inválido.");
        });

    }
}
