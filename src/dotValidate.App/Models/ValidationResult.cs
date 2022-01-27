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
            if (!HasFailures)
                return string.Empty;

            if (Failures.Count == 1)
                return $"The following validation error when handling the request '{_requestName}': {Failures.First().FailureDescription}";

            var summaryBuilder = new StringBuilder($"There were {Failures.Count} validation errors while handling the request '{_requestName}': ");

            for (var i = 0; i < Failures.Count; i++)
            {
                summaryBuilder.Append($"({i + 1}) {Failures[i].FailureDescription}");
            }

            return summaryBuilder.ToString();
        }
    }
}