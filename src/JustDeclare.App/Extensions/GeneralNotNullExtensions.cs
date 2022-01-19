using JustDeclare.Conditions;
using JustDeclare.Models;
using System;
using System.Linq.Expressions;

namespace JustDeclare
{
    public static partial class JustDeclareExtensions
    {
        public static ValidationCheck MustObeyTheseRules<TSubEntity>(this NotNullCondition<TSubEntity> conditional, params Expression<Func<TSubEntity, ValidationCheck>>[] rules)
        {
            return conditional.CreateValidationCheck(x => x.MustObeyTheseRules(rules));
        }
    }
}