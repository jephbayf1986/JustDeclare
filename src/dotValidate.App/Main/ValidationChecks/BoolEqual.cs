using System;

namespace dotValidate.Main.ValidationChecks
{
    internal class BoolEqual : ValidationCheck<bool?>
    {
        public BoolEqual(bool? value, bool targetValue)
            : base(value)
        {
            _targetValue = targetValue;
        }

        private readonly bool _targetValue;

        protected internal override string DefaultRuleBreakDescription
            => $"The Value provided for {PropertyName} {Should} be {_targetValue} but {(ValueProvided == null ? "was null" : "wasn't")}.";

        protected internal override bool GetTestResult()
            => _targetValue == ValueProvided;
    }
}
