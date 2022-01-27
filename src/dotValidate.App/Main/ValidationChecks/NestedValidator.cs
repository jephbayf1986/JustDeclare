using System;

namespace dotValidate.Main.ValidationChecks
{
    internal class NestedValidator<TSubEntity> : ValidationCheck<TSubEntity>
    {
        public NestedValidator(TSubEntity value, ValidationRules<TSubEntity> rules)
            : base(value)
        {
            this.rules = rules;
        }

        private readonly ValidationRules<TSubEntity> rules;

        protected override string DefaultRuleBreakDescription 
            => throw new NotImplementedException();

        protected override bool GetTestResult()
        {
            throw new NotImplementedException();
        }
    }
}
