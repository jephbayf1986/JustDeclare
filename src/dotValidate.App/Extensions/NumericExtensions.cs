using dotValidate.Main.ValidationChecks;
using dotValidate.Models;
using System;

namespace dotValidate
{
    /// <summary>
    /// Property Extensions for building Validation Rules with dotValidate
    /// </summary>
    public static partial class PropertyExtensions
    {
        /// <summary>
        /// Must Equal...
        /// </summary>
        /// <typeparam name="T">Type of property subject to validation rule</typeparam>
        /// <typeparam name="TTarget">The type of value to compare to</typeparam>
        /// <param name="value">Property subject to validation rule</param>
        /// <param name="target"></param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustEqual<T, TTarget>(this T value, TTarget target)
            where T : struct, IComparable, IFormattable
            where TTarget : struct, IComparable, IConvertible, IFormattable
        {
            return new NumericEqual<T, TTarget>(value, target);
        }

        /// <summary>
        /// Must Equal...
        /// </summary>
        /// <typeparam name="T">Type of property subject to validation rule</typeparam>
        /// <typeparam name="TTarget">The type of value to compare to</typeparam>
        /// <param name="value">Property subject to validation rule</param>
        /// <param name="target"></param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustEqual<T, TTarget>(this T? value, TTarget target)
            where T : struct, IComparable, IFormattable
            where TTarget : struct, IComparable, IConvertible, IFormattable
        {
            return new NumericEqual<T, TTarget>(value, target);
        }

        /// <summary>
        /// Must Not Equal...
        /// </summary>
        /// <typeparam name="T">Type of property subject to validation rule</typeparam>
        /// <typeparam name="TTarget">The type of value to compare to</typeparam>
        /// <param name="value">Property subject to validation rule</param>
        /// <param name="target"></param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustNotEqual<T, TTarget>(this T value, TTarget target)
            where T : struct, IComparable, IFormattable
            where TTarget : struct, IComparable, IConvertible, IFormattable
        {
            return value.MustEqual(target)
                        .Inverted();
        }

        /// <summary>
        /// Must Not Equal...
        /// </summary>
        /// <typeparam name="T">Type of property subject to validation rule</typeparam>
        /// <typeparam name="TTarget">The type of value to compare to</typeparam>
        /// <param name="value">Property subject to validation rule</param>
        /// <param name="target"></param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustNotEqual<T, TTarget>(this T? value, TTarget target)
            where T : struct, IComparable, IFormattable
            where TTarget : struct, IComparable, IConvertible, IFormattable
        {
            return value.MustEqual(target)
                        .Inverted();
        }

        /// <summary>
        /// Must Be Zero
        /// </summary>
        /// <typeparam name="T">Type of property subject to validation rule</typeparam>
        /// <param name="value">Property subject to validation rule</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustBeZero<T>(this T value)
            where T : struct, IComparable, IConvertible, IFormattable
        {
            return new NumericZero<T>(value);
        }

        /// <summary>
        /// Must Be Zero
        /// </summary>
        /// <typeparam name="T">Type of property subject to validation rule</typeparam>
        /// <param name="value">Property subject to validation rule</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustBeZero<T>(this T? value)
            where T : struct, IComparable, IConvertible, IFormattable
        {
            return new NumericZero<T>(value);
        }

        /// <summary>
        /// Must Not Be Zero
        /// </summary>
        /// <typeparam name="T">Type of property subject to validation rule</typeparam>
        /// <param name="value">Property subject to validation rule</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustNotBeZero<T>(this T value)
            where T : struct, IComparable, IConvertible, IFormattable
        {
            return value.MustBeZero()
                        .Inverted();
        }

        /// <summary>
        /// Must Not Be Zero
        /// </summary>
        /// <typeparam name="T">Type of property subject to validation rule</typeparam>
        /// <param name="value">Property subject to validation rule</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustNotBeZero<T>(this T? value)
            where T : struct, IComparable, IConvertible, IFormattable
        {
            return value.MustBeZero()
                        .Inverted();
        }

        /// <summary>
        /// Must Be No More Than...
        /// </summary>
        /// <typeparam name="T">Type of property subject to validation rule</typeparam>
        /// <typeparam name="TTarget">The type of value to compare to</typeparam>
        /// <param name="value">Property subject to validation rule</param>
        /// <param name="maximum"></param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustBeNoMoreThan<T, TTarget>(this T value, TTarget maximum)
            where T : struct, IComparable, IFormattable
            where TTarget : struct, IComparable, IConvertible, IFormattable
        {
            return new NumericMaximum<T, TTarget>(value, maximum);
        }

        /// <summary>
        /// Must Be No More Than...
        /// </summary>
        /// <typeparam name="T">Type of property subject to validation rule</typeparam>
        /// <typeparam name="TTarget">The type of value to compare to</typeparam>
        /// <param name="value">Property subject to validation rule</param>
        /// <param name="maximum"></param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustBeNoMoreThan<T, TTarget>(this T? value, TTarget maximum)
            where T : struct, IComparable, IFormattable
            where TTarget : struct, IComparable, IConvertible, IFormattable
        {
            return new NumericMaximum<T, TTarget>(value, maximum);
        }

        /// <summary>
        /// Must Be No Less Than...
        /// </summary>
        /// <typeparam name="T">Type of property subject to validation rule</typeparam>
        /// <typeparam name="TTarget">The type of value to compare to</typeparam>
        /// <param name="value">Property subject to validation rule</param>
        /// <param name="minimum"></param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustBeNoLessThan<T, TTarget>(this T value, TTarget minimum)
            where T : struct, IComparable, IFormattable
            where TTarget : struct, IComparable, IConvertible, IFormattable
        {
            return new NumericMinimum<T, TTarget>(value, minimum);
        }

        /// <summary>
        /// Must Be No Less Than...
        /// </summary>
        /// <typeparam name="T">Type of property subject to validation rule</typeparam>
        /// <typeparam name="TTarget">The type of value to compare to</typeparam>
        /// <param name="value">Property subject to validation rule</param>
        /// <param name="minimum"></param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustBeNoLessThan<T, TTarget>(this T? value, TTarget minimum)
            where T : struct, IComparable, IFormattable
            where TTarget : struct, IComparable, IConvertible, IFormattable
        {
            return new NumericMinimum<T, TTarget>(value, minimum);
        }

        /// <summary>
        /// Must Be Greater Than...
        /// </summary>
        /// <typeparam name="T">Type of property subject to validation rule</typeparam>
        /// <typeparam name="TTarget">The type of value to compare to</typeparam>
        /// <param name="value">Property subject to validation rule</param>
        /// <param name="target"></param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustBeGreaterThan<T, TTarget>(this T value, TTarget target)
            where T : struct, IComparable, IFormattable
            where TTarget : struct, IComparable, IConvertible, IFormattable
        {
            return value.MustBeNoMoreThan(target)
                        .Inverted();
        }

        /// <summary>
        /// Must Be Greater Than...
        /// </summary>
        /// <typeparam name="T">Type of property subject to validation rule</typeparam>
        /// <typeparam name="TTarget">The type of value to compare to</typeparam>
        /// <param name="value">Property subject to validation rule</param>
        /// <param name="target"></param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustBeGreaterThan<T, TTarget>(this T? value, TTarget target)
            where T : struct, IComparable, IFormattable
            where TTarget : struct, IComparable, IConvertible, IFormattable
        {
            return value.MustBeNoMoreThan(target)
                        .Inverted();
        }

        /// <summary>
        /// Must Be Less Than...
        /// </summary>
        /// <typeparam name="T">Type of property subject to validation rule</typeparam>
        /// <typeparam name="TTarget">The type of value to compare to</typeparam>
        /// <param name="value">Property subject to validation rule</param>
        /// <param name="target"></param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustBeLessThan<T, TTarget>(this T value, TTarget target)
            where T : struct, IComparable, IFormattable
            where TTarget : struct, IComparable, IConvertible, IFormattable
        {
            return value.MustBeNoLessThan(target)
                        .Inverted();
        }

        /// <summary>
        /// Must Be Less Than...
        /// </summary>
        /// <typeparam name="T">Type of property subject to validation rule</typeparam>
        /// <typeparam name="TTarget">The type of value to compare to</typeparam>
        /// <param name="value">Property subject to validation rule</param>
        /// <param name="target"></param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustBeLessThan<T, TTarget>(this T? value, TTarget target)
            where T : struct, IComparable, IFormattable
            where TTarget : struct, IComparable, IConvertible, IFormattable
        {
            return value.MustBeNoLessThan(target)
                        .Inverted();
        }

        /// <summary>
        /// Must Be Greater Than Or Equal To...
        /// </summary>
        /// <typeparam name="T">Type of property subject to validation rule</typeparam>
        /// <typeparam name="TTarget">The type of value to compare to</typeparam>
        /// <param name="value">Property subject to validation rule</param>
        /// <param name="minimum"></param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustBeGreaterThanOrEqualTo<T, TTarget>(this T value, TTarget minimum)
            where T : struct, IComparable, IFormattable
            where TTarget : struct, IComparable, IConvertible, IFormattable
        {
            return value.MustBeNoLessThan(minimum);
        }

        /// <summary>
        /// Must Be Greater Than Or Equal To...
        /// </summary>
        /// <typeparam name="T">Type of property subject to validation rule</typeparam>
        /// <typeparam name="TTarget">The type of value to compare to</typeparam>
        /// <param name="value">Property subject to validation rule</param>
        /// <param name="minimum"></param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustBeGreaterThanOrEqualTo<T, TTarget>(this T? value, TTarget minimum)
            where T : struct, IComparable, IFormattable
            where TTarget : struct, IComparable, IConvertible, IFormattable
        {
            return value.MustBeNoLessThan(minimum);
        }

        /// <summary>
        /// Must Be Less Than Or Equal To...
        /// </summary>
        /// <typeparam name="T">Type of property subject to validation rule</typeparam>
        /// <typeparam name="TTarget">The type of value to compare to</typeparam>
        /// <param name="value">Property subject to validation rule</param>
        /// <param name="maximum"></param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustBeLessThanOrEqualTo<T, TTarget>(this T value, TTarget maximum)
            where T : struct, IComparable, IFormattable
            where TTarget : struct, IComparable, IConvertible, IFormattable
        {
            return value.MustBeNoMoreThan(maximum);
        }

        /// <summary>
        /// Must Be Less Than Or Equal To...
        /// </summary>
        /// <typeparam name="T">Type of property subject to validation rule</typeparam>
        /// <typeparam name="TTarget">The type of value to compare to</typeparam>
        /// <param name="value">Property subject to validation rule</param>
        /// <param name="maximum"></param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustBeLessThanOrEqualTo<T, TTarget>(this T? value, TTarget maximum)
            where T : struct, IComparable, IFormattable
            where TTarget : struct, IComparable, IConvertible, IFormattable
        {
            return value.MustBeNoMoreThan(maximum);
        }

        /// <summary>
        /// Must Be In Range...
        /// </summary>
        /// <typeparam name="T">Type of property subject to validation rule</typeparam>
        /// <typeparam name="TRangeStart"></typeparam>
        /// <typeparam name="TRangeEnd"></typeparam>
        /// <param name="value">Property subject to validation rule</param>
        /// <param name="rangeStart"></param>
        /// <param name="rangeEnd"></param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustBeInRange<T, TRangeStart, TRangeEnd>(this T value, TRangeStart rangeStart, TRangeEnd rangeEnd)
            where T : struct, IComparable, IFormattable
            where TRangeStart : struct, IComparable, IConvertible, IFormattable
            where TRangeEnd : struct, IComparable, IConvertible, IFormattable
        {
            return new NumericRange<T, TRangeStart, TRangeEnd>(value, rangeStart, rangeEnd);
        }

        /// <summary>
        /// Must Be In Range...
        /// </summary>
        /// <typeparam name="T">Type of property subject to validation rule</typeparam>
        /// <typeparam name="TRangeStart"></typeparam>
        /// <typeparam name="TRangeEnd"></typeparam>
        /// <param name="value">Property subject to validation rule</param>
        /// <param name="rangeStart"></param>
        /// <param name="rangeEnd"></param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustBeInRange<T, TRangeStart, TRangeEnd>(this T? value, TRangeStart rangeStart, TRangeEnd rangeEnd)
            where T : struct, IComparable, IFormattable
            where TRangeStart : struct, IComparable, IConvertible, IFormattable
            where TRangeEnd : struct, IComparable, IConvertible, IFormattable
        {
            return new NumericRange<T, TRangeStart, TRangeEnd>(value, rangeStart, rangeEnd);
        }

        /// <summary>
        /// Must Not Be In Range...
        /// </summary>
        /// <typeparam name="T">Type of property subject to validation rule</typeparam>
        /// <typeparam name="TRangeStart"></typeparam>
        /// <typeparam name="TRangeEnd"></typeparam>
        /// <param name="value">Property subject to validation rule</param>
        /// <param name="rangeStart"></param>
        /// <param name="rangeEnd"></param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustNotBeInRange<T, TRangeStart, TRangeEnd>(this T value, TRangeStart rangeStart, TRangeEnd rangeEnd)
            where T : struct, IComparable, IFormattable
            where TRangeStart : struct, IComparable, IConvertible, IFormattable
            where TRangeEnd : struct, IComparable, IConvertible, IFormattable
        {
            return value.MustBeInRange(rangeStart, rangeEnd)
                        .Inverted();
        }

        /// <summary>
        /// Must Not Be In Range...
        /// </summary>
        /// <typeparam name="T">Type of property subject to validation rule</typeparam>
        /// <typeparam name="TRangeStart"></typeparam>
        /// <typeparam name="TRangeEnd"></typeparam>
        /// <param name="value">Property subject to validation rule</param>
        /// <param name="rangeStart"></param>
        /// <param name="rangeEnd"></param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
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