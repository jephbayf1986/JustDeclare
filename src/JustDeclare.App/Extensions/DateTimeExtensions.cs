using JustDeclare.Enums;
using JustDeclare.Main.ValidationChecks;
using JustDeclare.Models;
using System;

namespace JustDeclare.Extensions
{
    public static partial class JustDeclareExtensions
    {
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
    }
}