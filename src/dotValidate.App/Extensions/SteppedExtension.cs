using dotValidate.Models;

namespace dotValidate
{
    /// <summary>
    /// Dot Validate Exentension Step 1
    /// </summary>
    public static class DotValidateExentensionStep1
    {
        /// <summary>
        /// Validate
        /// </summary>
        /// <typeparam name="TRequest">Type of Request to validate</typeparam>
        /// <param name="validator">IValidator interface</param>
        /// <param name="request">Request object to validate</param>
        /// <returns>Using class for declariing the set validation rules to use</returns>
        public static DotValidateExentensionStep2<TRequest> Validate<TRequest>(this IValidator validator, TRequest request)
        { 
            return new DotValidateExentensionStep2<TRequest>(validator, request);
        }
    }

    /// <summary>
    /// Dot Validate Exentension Step 2
    /// </summary>
    public class DotValidateExentensionStep2<TRequest>
    {
        private readonly IValidator _Validator;
        private readonly TRequest _request;

        internal DotValidateExentensionStep2(IValidator validator, TRequest request)
        {
            _Validator = validator;
            _request = request;
        }

        /// <summary>
        /// <b>Using</b><br/>
        /// Deckare the validation rules to use
        /// </summary>
        /// <typeparam name="TValidator">Validation Rules for Request</typeparam>
        /// <returns>Validation Result</returns>
        public ValidationResult Using<TValidator>()
            where TValidator : ValidationRules<TRequest>, new()
        {
            return _Validator.ValidateRequest<TValidator, TRequest>(_request);
        }
    }
}
