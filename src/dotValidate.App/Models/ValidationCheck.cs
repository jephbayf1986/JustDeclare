namespace dotValidate.Models
{
    /// <summary>
    /// Validation Check<br/>
    /// Used for storing validation rule information
    /// </summary>
    public abstract class ValidationCheck
    {
        internal void SetPropertyName(string propertyName)
        {
            PropertyName = propertyName;
        }

        internal void InvertResult()
        {
            Invert = true;
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

        /// <summary>
        /// Default Rule Break Description
        /// </summary>
        protected internal abstract string DefaultRuleBreakDescription { get; }

        internal bool Passed
        {
            get
            {
                if (Invert)
                    return !GetTestResult();

                return GetTestResult();
            }
        }

        internal ValidationFailure Failure
        {
            get
            {
                if (Passed)
                    return null;

                return GetFailureDetails();
            }
        }

        internal bool EndValidationOnFailure
        {
            get
            {
                return _stopOnFailure;
            }
        }

        private bool _useCustomMessage = false;
        private string _customMessage;
        private bool _stopOnFailure = false;

        /// <summary>
        /// Invert
        /// </summary>
        protected internal bool Invert = false;

        /// <summary>
        /// Property Name
        /// </summary>
        protected internal string PropertyName;

        private ValidationFailure GetFailureDetails()
        {
            return new ValidationFailure
            {
                PropertyName = PropertyName,
                FailureDescription = _useCustomMessage ? _customMessage : DefaultRuleBreakDescription
            };
        }

        /// <summary>
        /// Get Test Result
        /// </summary>
        protected internal abstract bool GetTestResult();
    }
}