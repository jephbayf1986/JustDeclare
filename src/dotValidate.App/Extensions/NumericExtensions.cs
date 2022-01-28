using dotValidate.Main.ValidationChecks;
using dotValidate.Models;
using System;

namespace dotValidate
{
    public static partial class JustDeclareExtensions
    {
        public static ValidationCheck MustEqual<T, TTarget>(this T value, TTarget target)
            where T : struct, IComparable, IFormattable
            where TTarget : struct, IComparable, IConvertible, IFormattable
        {
            return new NumericEqual<T, TTarget>(value, target);
        }

        public static ValidationCheck MustEqual<T, TTarget>(this T? value, TTarget target)
            where T : struct, IComparable, IFormattable
            where TTarget : struct, IComparable, IConvertible, IFormattable
        {
            return new NumericEqual<T, TTarget>(value, target);
        }

        public static ValidationCheck MustNotEqual<T, TTarget>(this T value, TTarget target)
            where T : struct, IComparable, IFormattable
            where TTarget : struct, IComparable, IConvertible, IFormattable
        {
            return value.MustEqual(target)
                        .Inverted();
        }

        public static ValidationCheck MustNotEqual<T, TTarget>(this T? value, TTarget target)
            where T : struct, IComparable, IFormattable
            where TTarget : struct, IComparable, IConvertible, IFormattable
        {
            return value.MustEqual(target)
                        .Inverted();
        }

        public static ValidationCheck MustBeZero<T>(this T value)
            where T : struct, IComparable, IConvertible, IFormattable
        {
            return new NumericZero<T>(value);
        }

        public static ValidationCheck MustBeZero<T>(this T? value)
            where T : struct, IComparable, IConvertible, IFormattable
        {
            return new NumericZero<T>(value);
        }

        public static ValidationCheck MustNotBeZero<T>(this T value)
            where T : struct, IComparable, IConvertible, IFormattable
        {
            return value.MustBeZero()
                        .Inverted();
        }

        public static ValidationCheck MustNotBeZero<T>(this T? value)
            where T : struct, IComparable, IConvertible, IFormattable
        {
            return value.MustBeZero()
                        .Inverted();
        }

        public static ValidationCheck MustBeNoMoreThan<T, TMaximum>(this T value, TMaximum maximum)
            where T : struct, IComparable, IFormattable
            where TMaximum : struct, IComparable, IConvertible, IFormattable
        {
            return new NumericMaximum<T, TMaximum>(value, maximum);
        }

        public static ValidationCheck MustBeNoMoreThan<T, TMaximum>(this T? value, TMaximum maximum)
            where T : struct, IComparable, IFormattable
            where TMaximum : struct, IComparable, IConvertible, IFormattable
        {
            return new NumericMaximum<T, TMaximum>(value, maximum);
        }

        public static ValidationCheck MustBeNoLessThan<T, TMinimum>(this T value, TMinimum minimum)
            where T : struct, IComparable, IFormattable
            where TMinimum : struct, IComparable, IConvertible, IFormattable
        {
            return new NumericMinimum<T, TMinimum>(value, minimum);
        }

        public static ValidationCheck MustBeNoLessThan<T, TMinimum>(this T? value, TMinimum minimum)
            where T : struct, IComparable, IFormattable
            where TMinimum : struct, IComparable, IConvertible, IFormattable
        {
            return new NumericMinimum<T, TMinimum>(value, minimum);
        }

        public static ValidationCheck MustBeGreaterThan<T, TTarget>(this T value, TTarget target)
            where T : struct, IComparable, IFormattable
            where TTarget : struct, IComparable, IConvertible, IFormattable
        {
            return value.MustBeNoMoreThan(target)
                        .Inverted();
        }

        public static ValidationCheck MustBeGreaterThan<T, TTarget>(this T? value, TTarget target)
            where T : struct, IComparable, IFormattable
            where TTarget : struct, IComparable, IConvertible, IFormattable
        {
            return value.MustBeNoMoreThan(target)
                        .Inverted();
        }

        public static ValidationCheck MustBeLessThan<T, TTarget>(this T value, TTarget target)
            where T : struct, IComparable, IFormattable
            where TTarget : struct, IComparable, IConvertible, IFormattable
        {
            return value.MustBeNoLessThan(target)
                        .Inverted();
        }

        public static ValidationCheck MustBeLessThan<T, TTarget>(this T? value, TTarget target)
            where T : struct, IComparable, IFormattable
            where TTarget : struct, IComparable, IConvertible, IFormattable
        {
            return value.MustBeNoLessThan(target)
                        .Inverted();
        }

        public static ValidationCheck MustBeGreaterThanOrEqualTo<T, TMinimum>(this T value, TMinimum minimum)
            where T : struct, IComparable, IFormattable
            where TMinimum : struct, IComparable, IConvertible, IFormattable
        {
            return value.MustBeNoLessThan(minimum);
        }

        public static ValidationCheck MustBeGreaterThanOrEqualTo<T, TMinimum>(this T? value, TMinimum minimum)
            where T : struct, IComparable, IFormattable
            where TMinimum : struct, IComparable, IConvertible, IFormattable
        {
            return value.MustBeNoLessThan(minimum);
        }

        public static ValidationCheck MustBeLessThanOrEqualTo<T, TMaximum>(this T value, TMaximum maximum)
            where T : struct, IComparable, IFormattable
            where TMaximum : struct, IComparable, IConvertible, IFormattable
        {
            return value.MustBeNoMoreThan(maximum);
        }

        public static ValidationCheck MustBeLessThanOrEqualTo<T, TMaximum>(this T? value, TMaximum maximum)
            where T : struct, IComparable, IFormattable
            where TMaximum : struct, IComparable, IConvertible, IFormattable
        {
            return value.MustBeNoMoreThan(maximum);
        }

        public static ValidationCheck MustBeInRange<T, TRangeStart, TRangeEnd>(this T value, TRangeStart rangeStart, TRangeEnd rangeEnd)
            where T : struct, IComparable, IFormattable
            where TRangeStart : struct, IComparable, IConvertible, IFormattable
            where TRangeEnd : struct, IComparable, IConvertible, IFormattable
        {
            return new NumericRange<T, TRangeStart, TRangeEnd>(value, rangeStart, rangeEnd);
        }

        public static ValidationCheck MustBeInRange<T, TRangeStart, TRangeEnd>(this T? value, TRangeStart rangeStart, TRangeEnd rangeEnd)
            where T : struct, IComparable, IFormattable
            where TRangeStart : struct, IComparable, IConvertible, IFormattable
            where TRangeEnd : struct, IComparable, IConvertible, IFormattable
        {
            return new NumericRange<T, TRangeStart, TRangeEnd>(value, rangeStart, rangeEnd);
        }

        public static ValidationCheck MustNotBeInRange<T, TRangeStart, TRangeEnd>(this T value, TRangeStart rangeStart, TRangeEnd rangeEnd)
            where T : struct, IComparable, IFormattable
            where TRangeStart : struct, IComparable, IConvertible, IFormattable
            where TRangeEnd : struct, IComparable, IConvertible, IFormattable
        {
            return value.MustBeInRange(rangeStart, rangeEnd)
                        .Inverted();
        }

        public static ValidationCheck MustNotBeInRange<T, TRangeStart, TRangeEnd>(this T? value, TRangeStart rangeStart, TRangeEnd rangeEnd)
            where T : struct, IComparable, IFormattable
            where TRangeStart : struct, IComparable, IConvertible, IFormattable
            where TRangeEnd : struct, IComparable, IConvertible, IFormattable
        {
            return value.MustBeInRange(rangeStart, rangeEnd)
                        .Inverted();
        }
    }
}