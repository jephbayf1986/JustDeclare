using JustDeclare.Conditions;
using JustDeclare.Enums;
using JustDeclare.Models;
using System;

namespace JustDeclare
{
    public static partial class JustDeclareExtensions
    {
        public static ValidationCheck MustEqual(this NotNullCondition<DateTime?> conditional, DateTime target)
        {
            return conditional.CreateValidationCheck(x => x.MustEqual(target));
        }

        public static ValidationCheck MustNotEqual(this NotNullCondition<DateTime?> conditional, DateTime target)
        {
            return conditional.CreateValidationCheck(x => x.MustNotEqual(target));
        }

        public static ValidationCheck MustBeTheSameDateAs(this NotNullCondition<DateTime?> conditional, DateTime target)
        {
            return conditional.CreateValidationCheck(x => x.MustBeTheSameDateAs(target));
        }

        public static ValidationCheck MustNotBeTheSameDateAs(this NotNullCondition<DateTime?> conditional, DateTime target)
        {
            return conditional.CreateValidationCheck(x => x.MustNotBeTheSameDateAs(target));
        }

        public static ValidationCheck MustBeNoLaterThan(this NotNullCondition<DateTime?> conditional, DateTime maximumDate)
        {
            return conditional.CreateValidationCheck(x => x.MustBeNoLaterThan(maximumDate));
        }

        public static ValidationCheck MustBeNoEarlierThan(this NotNullCondition<DateTime?> conditional, DateTime minimumDate)
        {
            return conditional.CreateValidationCheck(x => x.MustBeNoLaterThan(minimumDate));
        }

        public static ValidationCheck MustBeNoYoungerThan(this NotNullCondition<DateTime?> conditional, int minimumYears)
        {
            return conditional.CreateValidationCheck(x => x.MustBeNoYoungerThan(minimumYears));
        }

        public static ValidationCheck MustBeNoOlderThan(this NotNullCondition<DateTime?> conditional, int maximumYears)
        {
            return conditional.CreateValidationCheck(x => x.MustBeNoOlderThan(maximumYears));
        }

        public static ValidationCheck MustBeInPast(this NotNullCondition<DateTime?> conditional)
        {
            return conditional.CreateValidationCheck(MustBeInPast);
        }

        public static ValidationCheck MustBeInFuture(this NotNullCondition<DateTime?> conditional)
        {
            return conditional.CreateValidationCheck(MustBeInFuture);
        }

        public static ValidationCheck MustBeInRange(this NotNullCondition<DateTime?> conditional, DateTime rangeStart, DateTime rangeEnd)
        {
            return conditional.CreateValidationCheck(x => x.MustBeInRange(rangeStart, rangeEnd));
        }

        public static ValidationCheck MustNotBeInRange(this NotNullCondition<DateTime?> conditional, DateTime rangeStart, DateTime rangeEnd)
        {
            return conditional.CreateValidationCheck(x => x.MustNotBeInRange(rangeStart, rangeEnd));
        }

        public static ValidationCheck AgeMustBeInRange(this NotNullCondition<DateTime?> conditional, int rangeStartYear, int rangeEndYear)
        {
            return conditional.CreateValidationCheck(x => x.AgeMustBeInRange(rangeStartYear, rangeEndYear));
        }

        public static ValidationCheck AgeMustNotBeInRange(this NotNullCondition<DateTime?> conditional, int rangeStartYear, int rangeEndYear)
        {
            return conditional.CreateValidationCheck(x => x.AgeMustNotBeInRange(rangeStartYear, rangeEndYear));
        }

        public static ValidationCheck MustFallOnA(this NotNullCondition<DateTime?> conditional, DayOfWeek target)
        {
            return conditional.CreateValidationCheck(x => x.MustFallOnA(target));
        }

        public static ValidationCheck MustNotFallOnA(this NotNullCondition<DateTime?> conditional, DayOfWeek target)
        {
            return conditional.CreateValidationCheck(x => x.MustNotFallOnA(target));
        }

        public static ValidationCheck MustBeAWeekDay(this NotNullCondition<DateTime?> conditional)
        {
            return conditional.CreateValidationCheck(MustBeAWeekDay);
        }

        public static ValidationCheck MustBeAWeekendDay(this NotNullCondition<DateTime?> conditional)
        {
            return conditional.CreateValidationCheck(MustBeAWeekendDay);
        }

        public static ValidationCheck MustBeInYear(this NotNullCondition<DateTime?> conditional, int year)
        {
            return conditional.CreateValidationCheck(x => x.MustBeInYear(year));
        }

        public static ValidationCheck MustNotBeInYear(this NotNullCondition<DateTime?> conditional, int year)
        {
            return conditional.CreateValidationCheck(x => x.MustNotBeInYear(year));
        }

        public static ValidationCheck YearMustBeInRange(this NotNullCondition<DateTime?> conditional, int startRange, int endRange)
        {
            return conditional.CreateValidationCheck(x => x.YearMustBeInRange(startRange, endRange));
        }

        public static ValidationCheck YearMustBeNotInRange(this NotNullCondition<DateTime?> conditional, int startRange, int endRange)
        {
            return conditional.CreateValidationCheck(x => x.YearMustBeNotInRange(startRange, endRange));
        }

        public static ValidationCheck MustBeInMonth(this NotNullCondition<DateTime?> conditional, MonthOfYear month)
        {
            return conditional.CreateValidationCheck(x => x.MustBeInMonth(month));
        }

        public static ValidationCheck MustNotBeInMonth(this NotNullCondition<DateTime?> conditional, MonthOfYear month)
        {
            return conditional.CreateValidationCheck(x => x.MustNotBeInMonth(month));
        }

        public static ValidationCheck MonthMustBeInRange(this NotNullCondition<DateTime?> conditional, MonthOfYear startRange, MonthOfYear endRange)
        {
            return conditional.CreateValidationCheck(x => x.MonthMustBeInRange(startRange, endRange));
        }
        
        public static ValidationCheck MonthMustBeNotInRange(this NotNullCondition<DateTime?> conditional, MonthOfYear startRange, MonthOfYear endRange)
        {
            return conditional.CreateValidationCheck(x => x.MonthMustBeNotInRange(startRange, endRange));
        }
    }
}
