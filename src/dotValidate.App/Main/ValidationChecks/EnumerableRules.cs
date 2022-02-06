using dotValidate.Main.Helpers;
using dotValidate.Main.Models;
using dotValidate.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace dotValidate.Main.ValidationChecks
{
    internal class EnumerableRules<TSubEntity> : ValidationCheck<IEnumerable<TSubEntity>>
    {
        public EnumerableRules(IEnumerable<TSubEntity> value, IEnumerable<Expression<Func<TSubEntity, ValidationCheck>>> nestedRules, bool allMustObey = true)
            : base(value)
        {
            _nestedTestFuncs = nestedRules.CreateValidationTestFuncs();
            _allMustObey = allMustObey;
        }

        private bool _allMustObey;
        private IEnumerable<ValidationTestContainer<TSubEntity>> _nestedTestFuncs;

        protected internal override string DefaultRuleBreakDescription
            => _generatedRuleBreakDescription;

        private string _generatedRuleBreakDescription;

        protected internal override bool GetTestResult()
        {
            throw new NotImplementedException();
        }
    }
}