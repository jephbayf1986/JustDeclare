using dotValidate.Models;
using System.Text;

namespace dotValidate.Testing.Models
{
    internal class ValidationResultOverride : ValidationResult
    {
        private int _numberOfFailures = 0;
        private string _failureMessage;
        private string _overrideRequestName;

        private ValidationResultOverride(string requestName, string failureMessage = null, int numberOfFailures = 0)
            : base(requestName)
        {
            _overrideRequestName = requestName;
            _failureMessage = failureMessage;
            _numberOfFailures = numberOfFailures;
        }

        public override int NumberOfFailures => _numberOfFailures;

        public override string FailureSummary() => _failureMessage ?? ErrorFailureSummary();

        public static ValidationResultOverride Pass(string requestName = null)
        {
            return new ValidationResultOverride(requestName ?? "TestRequest");
        }

        public static ValidationResultOverride Fail(string requestName = null, string customFailureMessage = null)
        {
            return new ValidationResultOverride(requestName ?? "TestRequest", customFailureMessage, 1);
        }

        public static ValidationResultOverride MultipleFail(int numberOfFailures, string requestName = null, string customFailureMessage = null)
        {
            return new ValidationResultOverride(requestName ?? "TestRequest", customFailureMessage, numberOfFailures);
        }

        private string ErrorFailureSummary()
        {
            if (_numberOfFailures == 0)
                return string.Empty;

            if (_numberOfFailures == 1)
                return $"The following validation error occurred while handling the request '{_overrideRequestName}': {TestFailMessage}";

            var summaryBuilder = new StringBuilder($"The following validation error occurred while handling the request '{_overrideRequestName}': ");

            for (var i = 0; i < Failures.Count; i++)
            {
                summaryBuilder.Append($" ({i + 1}) {TestFailMessage}");
            }

            return summaryBuilder.ToString();
        }

        private const string TestFailMessage = "The Mock Validator was instructed to fail this test";
    }
}