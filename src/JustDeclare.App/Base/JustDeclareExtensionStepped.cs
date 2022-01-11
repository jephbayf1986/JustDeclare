using JustDeclare.Models;

namespace JustDeclare
{
    public static class JustDeclareExentensionStep1
    {
        public static JustDeclareExentensionStep2<TRequest> Validate<TRequest>(this IValidator validator, TRequest request)
        { 
            return new JustDeclareExentensionStep2<TRequest>(validator, request);
        }
    }

    public class JustDeclareExentensionStep2<TRequest>
    {
        private readonly IValidator _Validator;
        private readonly TRequest _request;

        public JustDeclareExentensionStep2(IValidator validator, TRequest request)
        {
            _Validator = validator;
            _request = request;
        }

        public ValidationResult Using<TValidator>()
            where TValidator : ValidationRules<TRequest>, new()
        {
            return _Validator.ValidateRequest<TValidator, TRequest>(_request);
        }
    }
}
