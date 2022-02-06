using dotValidate.Conditions;
using dotValidate.Main.ValidationChecks;
using dotValidate.Models;
using System;
using System.Linq.Expressions;

namespace dotValidate
{
    /// <summary>
    /// Property Extensions for building Validation Rules with dotValidate
    /// </summary>
    public static partial class PropertyExtensions
    {
        /// <summary>
        /// Must Be Null
        /// </summary>
        /// <param name="value">Property subject to validation rule</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustBeNull(this object value)
            => new Null(value);

        /// <summary>
        /// Must Not Be Null
        /// </summary>
        /// <param name="value">Property subject to validation rule</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustNotBeNull(this object value)
            => value.MustBeNull()
                    .Inverted();

        /// <summary>
        /// Must Obey These Rules...
        /// </summary>
        /// <typeparam name="T">Type of property subject to validation rule</typeparam>
        /// <param name="entity">Property subject to validation rule</param>
        /// <param name="rules">Expressions with Validation Check output</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustObeyTheseRules<T>(this T entity, params Expression<Func<T, ValidationCheck>>[] rules)
        {
            return new NestedRules<T>(entity, rules);
        }

        /// <summary>
        /// Must Obey These Rules...
        /// </summary>
        /// <typeparam name="T">Type of property subject to validation rule</typeparam>
        /// <param name="conditional">Not Null Condition - Returned from WhenNotNull()</param>
        /// <param name="rules">Expressions with Validation Check output</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustObeyTheseRules<T>(this NotNullCondition<T> conditional, params Expression<Func<T, ValidationCheck>>[] rules)
        {
            return conditional.CreateValidationCheck(x => x.MustObeyTheseRules(rules));
        }
    }
}