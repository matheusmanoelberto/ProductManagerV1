﻿using FluentValidation;
using ProductManager.Domain.Models.Entities;

namespace ProductManager.Domain.Models.Validations;

public class ProductValidation : AbstractValidator<Product>
{
    public ProductValidation()
    {
        RuleFor( p => p.Name)
            .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
            .Length(2,200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        
        RuleFor(p => p.Description)
            .NotEmpty().WithMessage("Ocampo {PropertyName} Precisa ser fornecido")
            .Length(2,1000).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

        RuleFor(p => p.Value)
            .GreaterThan(0).WithMessage("{O campo {PropertyName} precisa ser maior que {ComparisonValue}");

    }
}
