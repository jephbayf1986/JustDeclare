using System;
using System.Collections.Generic;

namespace dotValidate.Main.ValidationChecks
{
    internal class EnumerableCountEqual<T> : ValidationCheck<IEnumerable<T>>
    {
        public EnumerableCountEqual(IEnumerable<T> value, int target)
            : base(value)
        {
            _target = target;
        }

        private readonly int _target;

        protected override string DefaultRuleBreakDescription => throw new NotImplementedException();

        protected override bool GetTestResult()
        {
            throw new NotImplementedException();
        }
    }
}