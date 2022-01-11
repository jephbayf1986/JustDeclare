using JustDeclare.Models;

namespace JustDeclare
{
    public interface IValidator
    {
        ValidationResult ValidateRequest<TValidator, TRequest>(TRequest request)
            where TValidator : ValidationRules<TRequest>, new();
    }
}
