using JustDeclare.Main.Helpers;
using JustDeclare.Main.Models;
using JustDeclare.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace JustDeclare
{
    public abstract class ValidationRules<TRequest>
    {
        private IEnumerable<ValidationTestContainer<TRequest>> _validationTestFuncs;

        protected void DeclareRules(params Expression<Func<TRequest, ValidationCheck>>[] rules)
        {
            _validationTestFuncs = rules.CreateValidationTestFuncs();
        }

        public ValidationResult Validate(TRequest request)
        {
            return _validationTestFuncs.RunAllTestsFor(request);
        }
    }
}