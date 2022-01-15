using System;
using System.Collections.Generic;

namespace JustDeclare.Main.ValidationChecks
{
    internal class EnumerableCountMaximum<T> : ValidationCheck<IEnumerable<T>>
    {
        public EnumerableCountMaximum(IEnumerable<T> value, int maxCount) 
            : base(value)
        {
            _maxCount = maxCount;
        }

        private readonly IComparable _maxCount;

        protected override string DefaultRuleBreakDescription => throw new NotImplementedException();

        protected override bool GetTestResult()
        {
            throw new NotImplementedException();
        }
    }
}
