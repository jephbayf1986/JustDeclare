using JustDeclare.Enums;
using JustDeclare.Main.ValidationChecks;
using JustDeclare.Models;
using System;

namespace JustDeclare
{
    public static partial class JustDeclareExtensions
    {
        private static ValidationCheck MustEqual(this DateTime? value, DateTime target)
        {
            return new DateEqual(value, target);
        }

        private static ValidationCheck MustNotEqual(this DateTime? value, DateTime target)
        {
            return value.MustEqual(target)
                        .Inverted();
        }

        private static ValidationCheck MustBeTheSameDateAs(this DateTime? value, DateTime target)
        {
            return new DateEqualAnyTime(value, target);
        }

        private static ValidationCheck MustNotBeTheSameDateAs(this DateTime? value, DateTime target)
        {
            return value.MustBeTheSameDateAs(target)
                        .Inverted();
        }

        private static ValidationCheck MustBeNoLaterThan(this DateTime? value, DateTime maximumDate)
        {
            return new DateMaximum(value, maximumDate);
        }

        private static ValidationCheck MustBeNoEarlierThan(this DateTime? value, DateTime minimumDate)
        {
            return new DateMinimum(value, minimumDate);
        }

        private static ValidationCheck MustBeNoYoungerThan(this DateTime? value, int minimumYears)
        {
            var maximumDate = DateTime.Now.Date.AddYears(-minimumYears);

            return value.MustBeNoLaterThan(maximumDate);
        }

        private static ValidationCheck MustBeNoOlderThan(this DateTime? value, int maximumYears)
        {
            var minimumDate = DateTime.Now.Date.AddYears(-maximumYears);

            return value.MustBeNoEarlierThan(minimumDate);
        }

        private static ValidationCheck MustBeInPast(this DateTime? value)
        {
            return value.MustBeNoLaterThan(DateTime.Now);
        }

        private static ValidationCheck MustBeInFuture(this DateTime? value)
        {
            return value.MustBeNoEarlierThan(DateTime.Now);
        }

        private static ValidationCheck MustBeInRange(this DateTime? value, DateTime rangeStart, DateTime rangeEnd)
        {
            return new DateRange(value, rangeStart, rangeEnd);
        }

        private static ValidationCheck MustNotBeInRange(this DateTime? value, DateTime rangeStart, DateTime rangeEnd)
        {
            return value.MustBeInRange(rangeStart, rangeEnd)
                        .Inverted();
        }

        private static ValidationCheck AgeMustBeInRange(this DateTime? value, int rangeStartYears, int rangeEndYears)
        {
            var rangeStart = DateTime.Now.Date.AddYears(-rangeStartYears);
            var rangeEnd = DateTime.Now.Date.AddYears(-rangeEndYears);

            return new DateRange(value, rangeStart, rangeEnd);
        }

        private static ValidationCheck AgeMustNotBeInRange(this DateTime? value, int rangeStartYears, int rangeEndYears)
        {
            return value.AgeMustBeInRange(rangeStartYears, rangeEndYears)
                        .Inverted();
        }

        private static ValidationCheck MustFallOnA(this DateTime? value, DayOfWeek target)
        {
            return new DateDayOfWeek(value, target);
        }

        private static ValidationCheck MustNotFallOnA(this DateTime? value, DayOfWeek target)
        {
            return value.MustFallOnA(target)
                        .Inverted();
        }

        private static ValidationCheck MustBeAWeekDay(this DateTime? value)
        {
            return new DateWeekDay(value);
        }

        private static ValidationCheck MustBeAWeekendDay(this DateTime? value)
        {
            return value.MustBeAWeekDay()
                        .Inverted();
        }

        private static ValidationCheck MustBeInYear(this DateTime? value, int year)
        {
            return new DateYear(value, year);
        }

        private static ValidationCheck MustNotBeInYear(this DateTime? value, int year)
        {
            return value.MustBeInYear(year)
                        .Inverted();
        }

        private static ValidationCheck YearMustBeInRange(this DateTime? value, int startRange, int endRange)
        {
            return new DateYearRange(value, startRange, endRange);
        }

        private static ValidationCheck YearMustBeNotInRange(this DateTime? value, int startRange, int endRange)
        {
            return value.YearMustBeInRange(startRange, endRange)
                        .Inverted();
        }

        private static ValidationCheck MustBeInMonth(this DateTime? value, MonthOfYear month)
        {
            return new DateMonth(value, month);
        }

        private static ValidationCheck MustNotBeInMonth(this DateTime? value, MonthOfYear month)
        {
            return value.MustBeInMonth(month)
                        .Inverted();
        }

        private static ValidationCheck MonthMustBeInRange(this DateTime? value, MonthOfYear startRange, MonthOfYear endRange)
        {
            return new DateMonthRange(value, startRange, endRange);
        }

        private static ValidationCheck MonthMustBeNotInRange(this DateTime? value, MonthOfYear startRange, MonthOfYear endRange)
        {
            return value.MonthMustBeInRange(startRange, endRange)
                        .Inverted();
        }
    }
}