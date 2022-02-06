namespace dotValidate.Models
{
    /// <summary>
    /// Validation Failure
    /// </summary>
    public class ValidationFailure
    {
        /// <summary>
        /// Name of the request property that has caused the failure<br/>
        /// </summary>
        public string PropertyName { get; set; }

        /// <summary>
        /// Description of why the validation failure occurred
        /// </summary>
        public string FailureDescription { get; set; }

        internal static ValidationFailure NullRequest(string requestName)
        {
            return new ValidationFailure
            {
                PropertyName = requestName,
                FailureDescription = $"A null reference was provided, an instance of {requestName} is required."
            };
        }
    }
}