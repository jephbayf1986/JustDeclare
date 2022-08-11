using dotValidate.Models;

namespace dotValidate.Testing.Models
{
    internal class ValidationResultOverride : ValidationResult
    {
        private string _failureMessage;

        private ValidationResultOverride(string requestName = null, string failureMessage = null)
            : base(requestName ?? UnknownRequestName)
        {
            _failureMessage = failureMessage;
        }

        public override string FailureSummary() => _failureMessage ?? base.FailureSummary();

        public static ValidationResultOverride Pass(string requestName = null)
        {
            return new ValidationResultOverride(requestName);
        }

        public static ValidationResultOverride Fail(string requestName = null, string customFailureMessage = null)
        {
            var result = new ValidationResultOverride(requestName, customFailureMessage);

            result.AddFailure(new ValidationFailure { PropertyName = UnknownColumn, FailureDescription = TestFailMessage });

            return result;
        }

        public static ValidationResultOverride MultipleFail(int numberOfFailures, string requestName = null, string customFailureMessage = null)
        {
            var result = new ValidationResultOverride(requestName, customFailureMessage);

            for(var i = 0; i < numberOfFailures; i++)
            {
                result.AddFailure(new ValidationFailure { PropertyName = UnknownColumn, FailureDescription = TestFailMessage });
            }

            return result;
        }

        private const string UnknownRequestName = "Any Request";
        private const string UnknownColumn = "Any Column";
        private const string TestFailMessage = "The Mock Validator was instructed to fail this test";
    }
}