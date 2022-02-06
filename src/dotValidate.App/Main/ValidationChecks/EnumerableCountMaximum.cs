using System;
using System.Collections.Generic;

namespace dotValidate.Main.ValidationChecks
{
    internal class EnumerableCountMaximum<T> : ValidationCheck<IEnumerable<T>>
    {
        public EnumerableCountMaximum(IEnumerable<T> value, int maxCount) 
            : base(value)
        {
            _maxCount = maxCount;
        }

        private readonly int _maxCount;

        protected internal override string DefaultRuleBreakDescription => throw new NotImplementedException();

        protected internal override bool GetTestResult()
        {
            throw new NotImplementedException();
        }
    }
}
