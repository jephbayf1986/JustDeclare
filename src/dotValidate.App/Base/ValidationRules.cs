using dotValidate.Main.Helpers;
using dotValidate.Main.Models;
using dotValidate.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace dotValidate
{
    /// <summary>
    /// <b>Validation Rules</b><br/>
    /// Inherit from this <i>dotValidate</i> class to declare the set of rules which a request must obey in order to pass validation
    /// </summary>
    /// <typeparam name="TRequest">Request Type</typeparam>
    public abstract class ValidationRules<TRequest>
    {
        private IEnumerable<ValidationTestContainer<TRequest>> _validationTestFuncs;

        /// <summary>
        /// <b>Declare Rules</b><br/>
        /// Call this from the constructor and pass a list of expressions to create the validation rules.
        /// <para>
        /// <i>Example:</i> <br />
        /// <code> 
        /// DeclareRules (
        /// x => x.Id.MustNotBeNull(),
        /// x => x.Name.MustNotBeBlank()
        /// )
        /// </code>
        /// </para>
        /// </summary>
        /// <param name="rules"></param>
        protected void DeclareRules(params Expression<Func<TRequest, ValidationCheck>>[] rules)
        {
            _validationTestFuncs = rules.CreateValidationTestFuncs();
        }

        /// <summary>
        /// <b>Validate</b><br/>
        /// Runs each validation rule against the request and returns a result based on the outcome.
        /// </summary>
        /// <param name="request">Request to be Validated</param>
        /// <returns>Validation Result</returns>
        public ValidationResult Validate(TRequest request)
        {
            return _validationTestFuncs.RunAllTestsFor(request);
        }
    }
}