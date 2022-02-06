using dotValidate.Conditions;
using dotValidate.Models;
using System;

namespace dotValidate
{
    /// <summary>
    /// Property Extensions for building Validation Rules with dotValidate
    /// </summary>
    public static partial class PropertyExtensions
    {
        public static ValidationCheck MustEqual<T, TTarget>(this NotNullCondition<T?> conditional, TTarget target)
            where T : struct, IComparable, IFormattable
            where TTarget : struct, IComparable, IConvertible, IFormattable
        {
            return conditional.CreateValidationCheck(x => x.MustEqual(target));
        }

        public static ValidationCheck MustNotEqual<T, TTarget>(this NotNullCondition<T?> conditional, TTarget target)
            where T : struct, IComparable, IFormattable
            where TTarget : struct, IComparable, IConvertible, IFormattable
        {
            return conditional.CreateValidationCheck(x => x.MustNotEqual(target));
        }

        public static ValidationCheck MustBeZero<T>(this NotNullCondition<T?> conditional)
            where T : struct, IComparable, IConvertible, IFormattable
        {
            return conditional.CreateValidationCheck(MustBeZero);
        }

        public static ValidationCheck MustNotBeZero<T>(this NotNullCondition<T?> conditional)
            where T : struct, IComparable, IConvertible, IFormattable
        {
            return conditional.CreateValidationCheck(MustNotBeZero);
        }

        public static ValidationCheck MustBeNoMoreThan<T, TMaximum>(this NotNullCondition<T?> conditional, TMaximum maximum)
            where T : struct, IComparable, IFormattable
            where TMaximum : struct, IComparable, IConvertible, IFormattable
        {
            return conditional.CreateValidationCheck(x => x.MustBeNoMoreThan(maximum));
        }

        public static ValidationCheck MustBeNoLessThan<T, TMinimum>(this NotNullCondition<T?> conditional, TMinimum minimum)
            where T : struct, IComparable, IFormattable
            where TMinimum : struct, IComparable, IConvertible, IFormattable
        {
            return conditional.CreateValidationCheck(x => x.MustBeNoLessThan(minimum));
        }

        public static ValidationCheck MustBeGreaterThan<T, TTarget>(this NotNullCondition<T?> conditional, TTarget target)
            where T : struct, IComparable, IFormattable
            where TTarget : struct, IComparable, IConvertible, IFormattable
        {
            return conditional.CreateValidationCheck(x => x.MustBeGreaterThan(target));
        }

        public static ValidationCheck MustBeLessThan<T, TTarget>(this NotNullCondition<T?> conditional, TTarget target)
            where T : struct, IComparable, IFormattable
            where TTarget : struct, IComparable, IConvertible, IFormattable
        {
            return conditional.CreateValidationCheck(x => x.MustBeLessThan(target));
        }

        public static ValidationCheck MustBeGreaterThanOrEqualTo<T, TMinimum>(this NotNullCondition<T?> conditional, TMinimum minimum)
            where T : struct, IComparable, IFormattable
            where TMinimum : struct, IComparable, IConvertible, IFormattable
        {
            return conditional.CreateValidationCheck(x => x.MustBeGreaterThanOrEqualTo(minimum));
        }

        public static ValidationCheck MustBeLessThanOrEqualTo<T, TMaximum>(this NotNullCondition<T?> conditional, TMaximum maximum)
            where T : struct, IComparable, IFormattable
            where TMaximum : struct, IComparable, IConvertible, IFormattable
        {
            return conditional.CreateValidationCheck(x => x.MustBeLessThanOrEqualTo(maximum));
        }

        public static ValidationCheck MustBeInRange<T, TRangeStart, TRangeEnd>(this NotNullCondition<T?> conditional, TRangeStart rangeStart, TRangeEnd rangeEnd)
            where T : struct, IComparable, IFormattable
            where TRangeStart : struct, IComparable, IConvertible, IFormattable
            where TRangeEnd : struct, IComparable, IConvertible, IFormattable
        {
            return conditional.CreateValidationCheck(x => x.MustBeInRange(rangeStart, rangeEnd));
        }

        public static ValidationCheck MustNotBeInRange<T, TRangeStart, TRangeEnd>(this NotNullCondition<T?> conditional, TRangeStart rangeStart, TRangeEnd rangeEnd)
            where T : struct, IComparable, IFormattable
            where TRangeStart : struct, IComparable, IConvertible, IFormattable
            where TRangeEnd : struct, IComparable, IConvertible, IFormattable
        {
            return conditional.CreateValidationCheck(x => x.MustNotBeInRange(rangeStart, rangeEnd));
        }
    }
}