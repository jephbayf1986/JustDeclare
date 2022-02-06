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

        protected internal override string DefaultRuleBreakDescription 
            => throw new NotImplementedException();

        protected internal override bool GetTestResult()
        {
            throw new NotImplementedException();
        }
    }
}
