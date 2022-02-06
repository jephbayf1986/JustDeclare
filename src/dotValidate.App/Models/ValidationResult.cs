using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dotValidate.Models
{
    public class ValidationResult
    {
        private readonly string _requestName;

        public bool HasFailures { get { return NumberOfFailures > 0; } }

        public int NumberOfFailures { get { return Failures.Count; } }

        public List<ValidationFailure> Failures { get; private set; }

        public ValidationResult(string requestName)
        {
            _requestName = requestName;

            Failures = new List<ValidationFailure>();
        }

        public void AddFailure(ValidationFailure failure)
        {
            Failures.Add(failure);
        }

        internal static ValidationResult NullRequest(string requestName)
        {
            var result = new ValidationResult(requestName);

            result.AddFailure(ValidationFailure.NullRequest(requestName));

            return result;
        }

        public string FailureSummary()
        {
            return GetFailureSummary(
                        $"The following validation error occurred while handling the request '{_requestName}'",
                        $"There were {Failures.Count} validation errors while handling the request '{_requestName}'"
                    );
        }
        
        internal string NestedFailureSummary(string propertyName)
        {
            return GetFailureSummary(
                        $"The data provided for {propertyName} had the following validation error",
                        $"The data provided for {propertyName} had the following {Failures.Count} validation errors"
                    );
        }

        private string GetFailureSummary(string singleLineStart, string multiLineStart)
        {
            if (!HasFailures)
                return string.Empty;

            if (Failures.Count == 1)
                return $"{singleLineStart}: {Failures.First().FailureDescription}";

            var summaryBuilder = new StringBuilder($"{multiLineStart}:");

            for (var i = 0; i < Failures.Count; i++)
            {
                summaryBuilder.Append($" ({i + 1}) {Failures[i].FailureDescription}");
            }

            return summaryBuilder.ToString();
        }
    }
}