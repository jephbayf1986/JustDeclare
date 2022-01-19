using JustDeclare.Conditions;
using JustDeclare.Models;
using System;

namespace JustDeclare
{
    public static partial class JustDeclareExtensions
    {
        public static ValidationCheck MustEqual<T>(this NotNullCondition<T?> conditional, T target)
            where T : struct, IComparable, IFormattable
        {
            return conditional.CreateValidationCheck(x => x.MustEqual(target));
        }

        public static ValidationCheck MustNotEqual<T>(this NotNullCondition<T?> conditional, T target)
            where T : struct, IComparable, IFormattable
        {
            return conditional.CreateValidationCheck(x => x.MustNotEqual(target));
        }

        public static ValidationCheck MustBeZero<T>(this NotNullCondition<T?> conditional)
            where T : struct, IComparable, IFormattable
        {
            return conditional.CreateValidationCheck(MustBeZero);
        }

        public static ValidationCheck MustNotBeZero<T>(this NotNullCondition<T?> conditional)
            where T : struct, IComparable, IFormattable
        {
            return conditional.CreateValidationCheck(MustNotBeZero);
        }

        public static ValidationCheck MustBeNoMoreThan<T>(this NotNullCondition<T?> conditional, T maximum)
            where T : struct, IComparable, IFormattable
        {
            return conditional.CreateValidationCheck(x => x.MustBeNoMoreThan(maximum));
        }

        public static ValidationCheck MustBeNoLessThan<T>(this NotNullCondition<T?> conditional, T minimum)
            where T : struct, IComparable, IFormattable
        {
            return conditional.CreateValidationCheck(x => x.MustBeNoLessThan(minimum));
        }

        public static ValidationCheck MustBeGreaterThan<T>(this NotNullCondition<T?> conditional, T target)
            where T : struct, IComparable, IFormattable
        {
            return conditional.CreateValidationCheck(x => x.MustBeGreaterThan(target));
        }

        public static ValidationCheck MustBeLessThan<T>(this NotNullCondition<T?> conditional, T target)
            where T : struct, IComparable, IFormattable
        {
            return conditional.CreateValidationCheck(x => x.MustBeLessThan(target));
        }

        public static ValidationCheck MustBeGreaterThanOrEqualTo<T>(this NotNullCondition<T?> conditional, T minimum)
            where T : struct, IComparable, IFormattable
        {
            return conditional.CreateValidationCheck(x => x.MustBeGreaterThanOrEqualTo(minimum));
        }

        public static ValidationCheck MustBeLessThanOrEqualTo<T>(this NotNullCondition<T?> conditional, T maximum)
            where T : struct, IComparable, IFormattable
        {
            return conditional.CreateValidationCheck(x => x.MustBeLessThanOrEqualTo(maximum));
        }

        public static ValidationCheck MustBeInRange<T>(this NotNullCondition<T?> conditional, T rangeStart, T rangeEnd)
            where T : struct, IComparable, IFormattable
        {
            return conditional.CreateValidationCheck(x => x.MustBeInRange(rangeStart, rangeEnd));
        }

        public static ValidationCheck MustNotBeInRange<T>(this NotNullCondition<T?> conditional, T rangeStart, T rangeEnd)
            where T : struct, IComparable, IFormattable
        {
            return conditional.CreateValidationCheck(x => x.MustNotBeInRange(rangeStart, rangeEnd));
        }
    }
}
