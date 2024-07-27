using FluentValidation;
using ProductManager.Domain.Models.Entities;

namespace ProductManager.Domain.Services;

public class BaseService
{
    protected bool PerformValidation<TV, TE> (TV validation, TE entity) where TV : AbstractValidator<TE> where TE : Entity
    {
        var validator = validation.Validate(entity);

        if (validator.IsValid) return true;

        return false;
    }
}