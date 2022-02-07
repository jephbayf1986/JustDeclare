using dotValidate.Models;

namespace dotValidate
{
    /// <summary>
    /// <b>Validator</b><br/>
    /// Implementation of <b>IValidator</b> for validating requests using <i>dotValidate</i>. 
    /// </summary>
    public class Validator : IValidator
    {
        /// <summary>
        /// <b>Validate Request</b><br/>
        /// Runs each validation rule against the request and returns a result based on the outcome.
        /// </summary>
        /// <typeparam name="TValidator">Validation Rules for Request</typeparam>
        /// <typeparam name="TRequest">Request to be Validated</typeparam>
        /// <param name="request">Request to be Validated</param>
        /// <returns>Validation Result</returns>
        public ValidationResult ValidateRequest<TValidator, TRequest>(TRequest request) 
            where TValidator : ValidationRules<TRequest>, new()
        {
            var validator = new TValidator();

            return validator.Validate(request);
        }
    }
}