using dotValidate;
using dotValidate.Models;

namespace dotValidate
{
    public interface IValidator
    {
        ValidationResult ValidateRequest<TValidator, TRequest>(TRequest request)
            where TValidator : ValidationRules<TRequest>, new();
    }
}
