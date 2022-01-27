using System;
using System.Collections.Generic;
using System.Text;

namespace dotValidate.Main.ValidationChecks
{
    internal class EnumerableValidator<TSubEntity> : ValidationCheck<IEnumerable<TSubEntity>>
    {
        public EnumerableValidator(IEnumerable<TSubEntity> value, ValidationRules<TSubEntity> rules)
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
