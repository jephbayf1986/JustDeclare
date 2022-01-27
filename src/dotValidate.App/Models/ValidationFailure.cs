namespace dotValidate.Models
{
    public class ValidationFailure
    {
        public string PropertyName { get; set; }

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