using dotValidate.Conditions;
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
        public static ValidationCheck MustObeyTheseRules<TSubEntity>(this NotNullCondition<TSubEntity> conditional, params Expression<Func<TSubEntity, ValidationCheck>>[] rules)
        {
            return conditional.CreateValidationCheck(x => x.MustObeyTheseRules(rules));
        }
    }
}