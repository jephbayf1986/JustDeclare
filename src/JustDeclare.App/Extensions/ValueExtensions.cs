using JustDeclare.Enums;
using JustDeclare.Main.ValidationChecks;
using JustDeclare.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace JustDeclare
{
    public static class ValueExtensions
    {
        #region General

        public static ValidationCheck MustBeNull(this object value)
        {
            return new Null(value);
        }

        public static ValidationCheck MustNotBeNull(this object value)
        {
            return value.MustBeNull()
                        .Inverted();
        }

        #endregion

        #region Numeric Specific

        public static ValidationCheck MustEqual<T>(this T value, T target)
            where T : struct, IComparable
        {
            return new NumericEqual<T>(value, target);
        }
        
        public static ValidationCheck MustNotEqual<T>(this T value, T target)
            where T : struct, IComparable
        {
            return value.MustEqual(target)
                        .Inverted();
        }

        public static ValidationCheck MustBeZero<T>(this T value)
            where T : struct, IComparable
        {
            return new NumericEqual<T>(value, 0);
        }

        public static ValidationCheck MustNotBeZero<T>(this T value)
            where T : struct, IComparable
        {
            return value.MustBeZero()
                        .Inverted();
        }

        public static ValidationCheck MustBeNoMoreThan<T>(this T value, T maximum)
            where T : struct, IComparable
        {
            return new NumericMaximum<T>(value, maximum);
        }

        public static ValidationCheck MustBeNoLessThan<T>(this T value, T minimum)
            where T : struct, IComparable
        {
            return new NumericMinimum<T>(value, minimum);
        }

        public static ValidationCheck MustBeGreaterThan<T>(this T value, T target)
            where T : struct, IComparable
        {
            return value.MustBeNoMoreThan(target)
                        .Inverted();
        }

        public static ValidationCheck MustBeLessThan<T>(this T value, T target)
            where T : struct, IComparable
        {
            return value.MustBeNoLessThan(target)
                        .Inverted();
        }

        public static ValidationCheck MustBeGreaterThanOrEqualTo<T>(this T value, T minimum)
            where T : struct, IComparable
        {
            return value.MustBeNoLessThan(minimum);
        }

        public static ValidationCheck MustBeLessThanOrEqualTo<T>(this T value, T maximum)
            where T : struct, IComparable
        {
            return value.MustBeNoMoreThan(maximum);
        }

        public static ValidationCheck MustBeInRange<T>(this T value, T rangeStart, T rangeEnd)
            where T : struct, IComparable
        {
            return new NumericRange<T>(value, rangeStart, rangeEnd);
        }

        public static ValidationCheck MustNotBeInRange<T>(this T value, T rangeStart, T rangeEnd)
            where T : struct, IComparable
        {
            return value.MustBeInRange(rangeStart, rangeEnd)
                        .Inverted();
        }

        #endregion

        #region String Specific

        public static ValidationCheck MustBe(this string value, string target)
        {
            return new StringEqual(value, target);
        }

        public static ValidationCheck MustNotBe(this string value, string target)
        {
            return value.MustBe(target)
                        .Inverted();
        }

        public static ValidationCheck MustNotBeBlank(this string value)
        {
            return new StringBlank(value);
        }

        public static ValidationCheck MustBeBlank(this string value)
        {
            return value.MustNotBeBlank()
                        .Inverted();
        }

        public static ValidationCheck MustBeNoLongerThan(this string value, int maximumLength)
        {
            return new StringMaximumLength(value, maximumLength);
        }

        public static ValidationCheck MustBeNoShorterThan(this string value, int minimumLength)
        {
            return new StringMinimumLength(value, minimumLength);
        }

        public static ValidationCheck MustContain(this string value, string target)
        {
            return new StringContains(value, target);
        }

        public static ValidationCheck MustNotContain(this string value, string target)
        {
            return value.MustContain(target)
                        .Inverted();
        }

        public static ValidationCheck MustStartWith(this string value, string target)
        {
            return new StringStartsWith(value, target);
        }

        public static ValidationCheck MustNotStartWith(this string value, string target)
        {
            return value.MustStartWith(target)
                        .Inverted();
        }

        public static ValidationCheck MustEndWith(this string value, string target)
        {
            return new StringEndsWith(value, target);
        }

        public static ValidationCheck MustNotEndWith(this string value, string target)
        {
            return value.MustEndWith(target)
                        .Inverted();
        }

        public static ValidationCheck MustMatchPattern(this string value, string pattern)
        {
            return new StringRegexMatch(value, pattern);
        }

        public static ValidationCheck MustNotMatchPattern(this string value, string pattern)
        {
            return value.MustMatchPattern(pattern)
                        .Inverted();
        }

        public static ValidationCheck MustBeAnEmailAddress(this string value)
        {
            throw new NotImplementedException();
        }

        public static ValidationCheck MustBeAPhoneNumber(this string value)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region DateTime Specific

        public static ValidationCheck MustEqual(this DateTime value, DateTime target)
        {
            return new DateEqual(value, target);
        }

        public static ValidationCheck MustNotEqual(this DateTime value, DateTime target)
        {
            return value.MustEqual(target)
                        .Inverted();
        }

        public static ValidationCheck MustBeTheSameDateAs(this DateTime value, DateTime target)
        {
            return new DateEqualAnyTime(value, target);
        }

        public static ValidationCheck MustNotBeTheSameDateAs(this DateTime value, DateTime target)
        {
            return value.MustBeTheSameDateAs(target)
                        .Inverted();
        }

        public static ValidationCheck MustBeNoLaterThan(this DateTime value, DateTime maximumDate)
        {
            return new DateMaximum(value, maximumDate);
        }

        public static ValidationCheck MustBeNoEarlierThan(this DateTime value, DateTime minimumDate)
        {
            return new DateMinimum(value, minimumDate);
        }

        public static ValidationCheck MustBeNoYoungerThan(this DateTime value, int minimumYears)
        {
            var maximumDate = DateTime.Now.Date.AddYears(-minimumYears);

            return value.MustBeNoLaterThan(maximumDate);
        }

        public static ValidationCheck MustBeNoOlderThan(this DateTime value, int maximumYears)
        {
            var minimumDate = DateTime.Now.Date.AddYears(-maximumYears);

            return value.MustBeNoEarlierThan(minimumDate);
        }

        public static ValidationCheck MustBeInPast(this DateTime value)
        {
            return value.MustBeNoLaterThan(DateTime.Now);
        }

        public static ValidationCheck MustBeInFuture(this DateTime value)
        {
            return value.MustBeNoEarlierThan(DateTime.Now);
        }

        public static ValidationCheck MustBeInRange(this DateTime value, DateTime rangeStart, DateTime rangeEnd)
        {
            return new DateRange(value, rangeStart, rangeEnd);
        }

        public static ValidationCheck MustNotBeInRange(this DateTime value, DateTime rangeStart, DateTime rangeEnd)
        {
            return value.MustBeInRange(rangeStart, rangeEnd)
                        .Inverted();
        }

        public static ValidationCheck AgeMustBeInRange(this DateTime value, int rangeStartYears, int rangeEndYears)
        {
            var rangeStart = DateTime.Now.Date.AddYears(-rangeStartYears);
            var rangeEnd = DateTime.Now.Date.AddYears(-rangeEndYears);

            return new DateRange(value, rangeStart, rangeEnd);
        }

        public static ValidationCheck AgeMustNotBeInRange(this DateTime value, int rangeStartYears, int rangeEndYears)
        {
            return value.AgeMustBeInRange(rangeStartYears, rangeEndYears)
                        .Inverted();
        }

        public static ValidationCheck MustBeDayOfTheWeek(this DateTime value, DayOfWeek target)
        {
            return new DateDayOfWeek(value, target);
        }

        public static ValidationCheck MustNotBeDayOfTheWeek(this DateTime value, DayOfWeek target)
        {
            return value.MustBeDayOfTheWeek(target)
                        .Inverted();
        }

        public static ValidationCheck MustBeAWeekDay(this DateTime value)
        {
            return new DateWeekDay(value);
        }

        public static ValidationCheck MustBeAWeekendDay(this DateTime value)
        {
            return value.MustBeAWeekDay()
                        .Inverted();
        }

        public static ValidationCheck MustBeInYear(this DateTime value, int year)
        {
            return new DateYear(value, year);
        }

        public static ValidationCheck MustNotBeInYear(this DateTime value, int year)
        {
            return value.MustBeInYear(year)
                        .Inverted();
        }

        public static ValidationCheck YearMustBeInRange(this DateTime value, int startRange, int endRange)
        {
            return new DateYearRange(value, startRange, endRange);
        }

        public static ValidationCheck YearMustBeNotInRange(this DateTime value, int startRange, int endRange)
        {
            return value.YearMustBeInRange(startRange, endRange)
                        .Inverted();
        }

        public static ValidationCheck MustBeInMonth(this DateTime value, MonthOfYear month)
        {
            return new DateMonth(value, month);
        }

        public static ValidationCheck MustNotBeInMonth(this DateTime value, MonthOfYear month)
        {
            return value.MustBeInMonth(month)
                        .Inverted();
        }

        public static ValidationCheck MonthMustBeInRange(this DateTime value, MonthOfYear startRange, MonthOfYear endRange)
        {
            return new DateMonthRange(value, startRange, endRange);
        }

        public static ValidationCheck MonthMustBeNotInRange(this DateTime value, MonthOfYear startRange, MonthOfYear endRange)
        {
            return value.MonthMustBeInRange(startRange, endRange)
                        .Inverted();
        }

        #endregion

        #region Enumerable Specific

        public static ValidationCheck MustNotBeEmpty<T>(this IEnumerable<T> value)
        {
            return new EnumerableCountMinimum<T>(value, 1);
        }

        public static ValidationCheck CountMustBeAtLeast<T>(this IEnumerable<T> value, int minimum)
        {
            return new EnumerableCountMinimum<T>(value, minimum);
        }

        public static ValidationCheck CountMustNoMoreThan<T>(this IEnumerable<T> value, int maximum)
        {
            return new EnumerableCountMaximum<T>(value, maximum);
        }

        public static ValidationCheck CountMustBe<T>(this IEnumerable<T> value, int target)
        {
            return new EnumerableCountEqual<T>(value, target);
        }

        public static ValidationCheck CountMustNotBe<T>(this IEnumerable<T> value, int target)
        {
            return value.CountMustBe(target)
                        .Inverted();
        }

        public static ValidationCheck AllMustObeyTheseRules<T>(this IEnumerable<T> value, params Expression<Func<T, ValidationCheck>>[] rules)
        {
            return new EnumerableRules<T>(value, rules);
        }
        
        public static ValidationCheck SomeMustObeyTheseRules<T>(this IEnumerable<T> value, params Expression<Func<T, ValidationCheck>>[] rules)
        {
            return new EnumerableRules<T>(value, rules, allMustObey: false);
        }

        #endregion

        #region Nested Specific

        public static ValidationCheck MustObeyTheseRules<T>(this T entity, params Expression<Func<T, ValidationCheck>>[] rules)
        {
            return new NestedRules<T>(entity, rules);
        }

        #endregion
    }
}