using JustDeclare.Main.ValidationChecks;
using JustDeclare.Models;
using System;

namespace JustDeclare
{
    public static partial class JustDeclareExtensions
    {
        public static ValidationCheck MustEqual<T>(this T? value, T target)
            where T : struct, IComparable, IFormattable
        {
            return new NumericEqual<T>(value, target);
        }

        public static ValidationCheck MustNotEqual<T>(this T? value, T target)
            where T : struct, IComparable, IFormattable
        {
            return value.MustEqual(target)
                        .Inverted();
        }

        public static ValidationCheck MustBeZero<T>(this T? value)
            where T : struct, IComparable, IConvertible, IFormattable
        {
            return new NumericZero<T>(value);
        }

        public static ValidationCheck MustNotBeZero<T>(this T? value)
            where T : struct, IComparable, IConvertible, IFormattable
        {
            return value.MustBeZero()
                        .Inverted();
        }

        public static ValidationCheck MustBeNoMoreThan<T>(this T? value, T maximum)
            where T : struct, IComparable, IFormattable
        {
            return new NumericMaximum<T>(value, maximum);
        }

        public static ValidationCheck MustBeNoLessThan<T>(this T? value, T minimum)
            where T : struct, IComparable, IFormattable
        {
            return new NumericMinimum<T>(value, minimum);
        }

        public static ValidationCheck MustBeGreaterThan<T>(this T? value, T target)
            where T : struct, IComparable, IFormattable
        {
            return value.MustBeNoMoreThan(target)
                        .Inverted();
        }

        public static ValidationCheck MustBeLessThan<T>(this T? value, T target)
            where T : struct, IComparable, IFormattable
        {
            return value.MustBeNoLessThan(target)
                        .Inverted();
        }

        public static ValidationCheck MustBeGreaterThanOrEqualTo<T>(this T? value, T minimum)
            where T : struct, IComparable, IFormattable
        {
            return value.MustBeNoLessThan(minimum);
        }

        public static ValidationCheck MustBeLessThanOrEqualTo<T>(this T? value, T maximum)
            where T : struct, IComparable, IFormattable
        {
            return value.MustBeNoMoreThan(maximum);
        }

        public static ValidationCheck MustBeInRange<T>(this T? value, T rangeStart, T rangeEnd)
            where T : struct, IComparable, IFormattable
        {
            return new NumericRange<T>(value, rangeStart, rangeEnd);
        }

        public static ValidationCheck MustNotBeInRange<T>(this T? value, T rangeStart, T rangeEnd)
            where T : struct, IComparable, IFormattable
        {
            return value.MustBeInRange(rangeStart, rangeEnd)
                        .Inverted();
        }
    }
}