using JustDeclare.Conditions;
using JustDeclare.Main.ValidationChecks;
using JustDeclare.Models;
using System;
using System.Linq.Expressions;
using Value = JustDeclare.ValueExtensions;

namespace JustDeclare
{
    public static class NotNullConditionExtensions
    {
        public static ValidationCheck MustNotBeBlank(this NotNullCondition<string> conditional)
        {
            return conditional.CreateValidationCheck(Value.MustNotBeBlank);
        }

        public static ValidationCheck MustBeBlank(this NotNullCondition<string> conditional)
        {
            return conditional.CreateValidationCheck(Value.MustBeBlank);
        }

        public static ValidationCheck MustBeZero<T>(this NotNullCondition<T?> conditional)
            where T : struct, IComparable
        {
            return conditional.CreateValidationCheck(x => new NumericEqual<T>(x, 0));
        }

        public static ValidationCheck MustBeNoMoreThan<T>(this NotNullCondition<T?> conditional, IComparable maximum)
            where T : struct, IComparable
        {
            return conditional.CreateValidationCheck(x => new NumericMaximum<T>(x, maximum));
        }

        public static ValidationCheck MustBeNoLessThan<T>(this NotNullCondition<T?> conditional, IComparable minimum)
            where T : struct, IComparable
        {
            return conditional.CreateValidationCheck(x => new NumericMinimum<T>(x, minimum));
        }

        public static ValidationCheck MustBeNoLongerThan(this NotNullCondition<string> conditional, int maximumLength)
        {
            return conditional.CreateValidationCheck(x => x.MustBeNoLongerThan(maximumLength));
        }

        public static ValidationCheck MustBeNoShorterThan(this NotNullCondition<string> conditional, int minimumLength)
        {
            return conditional.CreateValidationCheck(x => x.MustBeNoShorterThan(minimumLength));
        }

        public static ValidationCheck MustMatchPattern(this NotNullCondition<string> conditional, string pattern)
        {
            return conditional.CreateValidationCheck(x => x.MustMatchPattern(pattern));
        }

        public static ValidationCheck MustObeyTheseRules<TSubEntity>(this NotNullCondition<TSubEntity> conditional, params Expression<Func<TSubEntity, ValidationCheck>>[] rules)
        {
            return conditional.CreateValidationCheck(x => x.MustObeyTheseRules(rules));
        }
    }
}