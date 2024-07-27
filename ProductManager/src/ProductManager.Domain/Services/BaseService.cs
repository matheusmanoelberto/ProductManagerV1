using FluentValidation;
using FluentValidation.Results;
using ProductManager.Domain.Interfaces;
using ProductManager.Domain.Models.Entities;
using ProductManager.Domain.Notifications;

namespace ProductManager.Domain.Services;

public class BaseService
{
    private readonly INotifier _notifier;
    public BaseService(INotifier notifier)
    {
        _notifier = notifier;
    }
    protected void Notify(ValidationResult validationResult)
    {
        foreach (var item in validationResult.Errors)
        {
            Notify(item.ErrorMessage);
        }
    }
    protected void Notify(string message)
    {
        _notifier.Handle(new Notification(message));
    }

    protected bool PerformValidation<TV, TE> (TV validation, TE entity) where TV : AbstractValidator<TE> where TE : Entity
    {
        var validator = validation.Validate(entity);

        if (validator.IsValid) return true;

        Notify(validator);

        return false;
    }
}