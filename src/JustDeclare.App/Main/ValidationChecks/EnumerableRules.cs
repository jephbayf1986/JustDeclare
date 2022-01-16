using JustDeclare.Main.Helpers;
using JustDeclare.Main.Models;
using JustDeclare.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace JustDeclare.Main.ValidationChecks
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

        protected override string DefaultRuleBreakDescription
            => _generatedRuleBreakDescription;

        private string _generatedRuleBreakDescription;

        protected override bool GetTestResult()
        {
            throw new NotImplementedException();
        }
    }
}