using dotValidate.Models;

namespace dotValidate.Main
{
    internal class Validator : IValidator
    {
        public ValidationResult ValidateRequest<TValidator, TRequest>(TRequest request) 
            where TValidator : ValidationRules<TRequest>, new()
        {
            var validator = new TValidator();

            return validator.Validate(request);
        }
    }
}