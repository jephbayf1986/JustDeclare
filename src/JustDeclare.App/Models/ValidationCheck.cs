namespace JustDeclare.Models
{
    public abstract class ValidationCheck<T> : ValidationCheck
    {
        public ValidationCheck(T value)
        {
            ValueProvided = value;
        }

        protected T ValueProvided;
    }

    public abstract class ValidationCheck
    {
        public ValidationCheck()
        {
        }

        internal void SetPropertyName(string propertyName)
        {
            PropertyName = propertyName;
        }

        internal void SetCustomMessage(string customMessage)
        {
            _customMessage = customMessage;
            _useCustomMessage = true;
        }

        internal void StopValidatingOnFailure()
        {
            _stopOnFailure = true;
        }

        protected abstract string DefaultRuleBreakDescription { get; }

        public bool Passed
        {
            get
            {
                return _ignoreThisTest || GetTestResult();
            }
        }

        public ValidationFailure Failure
        {
            get
            {
                if (Passed)
                    return null;

                return GetFailureDetails();
            }
        }

        public bool EndValidationOnFailure
        {
            get
            {
                return _stopOnFailure;
            }
        }

        private bool _useCustomMessage = false;
        private string _customMessage;
        private bool _stopOnFailure = false;
        private bool _ignoreThisTest = false;

        protected string PropertyName;

        private ValidationFailure GetFailureDetails()
        {
            return new ValidationFailure
            {
                PropertyName = PropertyName,
                FailureDescription = _useCustomMessage ? _customMessage : DefaultRuleBreakDescription
            };
        }

        protected abstract bool GetTestResult();
    }
}