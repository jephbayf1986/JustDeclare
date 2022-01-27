using dotValidate.Conditions;
using dotValidate.Models;
using System;
using System.Linq.Expressions;

namespace dotValidate
{
    public static partial class JustDeclareExtensions
    {
        public static ValidationCheck MustObeyTheseRules<TSubEntity>(this NotNullCondition<TSubEntity> conditional, params Expression<Func<TSubEntity, ValidationCheck>>[] rules)
        {
            return conditional.CreateValidationCheck(x => x.MustObeyTheseRules(rules));
        }
    }
}