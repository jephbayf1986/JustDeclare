using dotValidate.Conditions;
using dotValidate.Enums;
using dotValidate.Models;
using System;

namespace dotValidate
{
    public static partial class JustDeclareExtensions
    {
        private static ValidationCheck MustEqual(this NotNullCondition<DateTime?> conditional, DateTime target)
        {
            return conditional.CreateValidationCheck(x => x.MustEqual(target));
        }

        private static ValidationCheck MustNotEqual(this NotNullCondition<DateTime?> conditional, DateTime target)
        {
            return conditional.CreateValidationCheck(x => x.MustNotEqual(target));
        }

        private static ValidationCheck MustBeTheSameDateAs(this NotNullCondition<DateTime?> conditional, DateTime target)
        {
            return conditional.CreateValidationCheck(x => x.MustBeTheSameDateAs(target));
        }

        private static ValidationCheck MustNotBeTheSameDateAs(this NotNullCondition<DateTime?> conditional, DateTime target)
        {
            return conditional.CreateValidationCheck(x => x.MustNotBeTheSameDateAs(target));
        }

        private static ValidationCheck MustBeNoLaterThan(this NotNullCondition<DateTime?> conditional, DateTime maximumDate)
        {
            return conditional.CreateValidationCheck(x => x.MustBeNoLaterThan(maximumDate));
        }

        private static ValidationCheck MustBeNoEarlierThan(this NotNullCondition<DateTime?> conditional, DateTime minimumDate)
        {
            return conditional.CreateValidationCheck(x => x.MustBeNoLaterThan(minimumDate));
        }

        private static ValidationCheck MustBeNoYoungerThan(this NotNullCondition<DateTime?> conditional, int minimumYears)
        {
            return conditional.CreateValidationCheck(x => x.MustBeNoYoungerThan(minimumYears));
        }

        private static ValidationCheck MustBeNoOlderThan(this NotNullCondition<DateTime?> conditional, int maximumYears)
        {
            return conditional.CreateValidationCheck(x => x.MustBeNoOlderThan(maximumYears));
        }

        private static ValidationCheck MustBeInPast(this NotNullCondition<DateTime?> conditional)
        {
            return conditional.CreateValidationCheck(MustBeInPast);
        }

        private static ValidationCheck MustBeInFuture(this NotNullCondition<DateTime?> conditional)
        {
            return conditional.CreateValidationCheck(MustBeInFuture);
        }

        private static ValidationCheck MustBeInRange(this NotNullCondition<DateTime?> conditional, DateTime rangeStart, DateTime rangeEnd)
        {
            return conditional.CreateValidationCheck(x => x.MustBeInRange(rangeStart, rangeEnd));
        }

        private static ValidationCheck MustNotBeInRange(this NotNullCondition<DateTime?> conditional, DateTime rangeStart, DateTime rangeEnd)
        {
            return conditional.CreateValidationCheck(x => x.MustNotBeInRange(rangeStart, rangeEnd));
        }

        private static ValidationCheck AgeMustBeInRange(this NotNullCondition<DateTime?> conditional, int rangeStartYear, int rangeEndYear)
        {
            return conditional.CreateValidationCheck(x => x.AgeMustBeInRange(rangeStartYear, rangeEndYear));
        }

        private static ValidationCheck AgeMustNotBeInRange(this NotNullCondition<DateTime?> conditional, int rangeStartYear, int rangeEndYear)
        {
            return conditional.CreateValidationCheck(x => x.AgeMustNotBeInRange(rangeStartYear, rangeEndYear));
        }

        private static ValidationCheck MustFallOnA(this NotNullCondition<DateTime?> conditional, DayOfWeek target)
        {
            return conditional.CreateValidationCheck(x => x.MustFallOnA(target));
        }

        private static ValidationCheck MustNotFallOnA(this NotNullCondition<DateTime?> conditional, DayOfWeek target)
        {
            return conditional.CreateValidationCheck(x => x.MustNotFallOnA(target));
        }

        private static ValidationCheck MustBeAWeekDay(this NotNullCondition<DateTime?> conditional)
        {
            return conditional.CreateValidationCheck(MustBeAWeekDay);
        }

        private static ValidationCheck MustBeAWeekendDay(this NotNullCondition<DateTime?> conditional)
        {
            return conditional.CreateValidationCheck(MustBeAWeekendDay);
        }

        private static ValidationCheck MustBeInYear(this NotNullCondition<DateTime?> conditional, int year)
        {
            return conditional.CreateValidationCheck(x => x.MustBeInYear(year));
        }

        private static ValidationCheck MustNotBeInYear(this NotNullCondition<DateTime?> conditional, int year)
        {
            return conditional.CreateValidationCheck(x => x.MustNotBeInYear(year));
        }

        private static ValidationCheck YearMustBeInRange(this NotNullCondition<DateTime?> conditional, int startRange, int endRange)
        {
            return conditional.CreateValidationCheck(x => x.YearMustBeInRange(startRange, endRange));
        }

        private static ValidationCheck YearMustBeNotInRange(this NotNullCondition<DateTime?> conditional, int startRange, int endRange)
        {
            return conditional.CreateValidationCheck(x => x.YearMustBeNotInRange(startRange, endRange));
        }

        private static ValidationCheck MustBeInMonth(this NotNullCondition<DateTime?> conditional, MonthOfYear month)
        {
            return conditional.CreateValidationCheck(x => x.MustBeInMonth(month));
        }

        private static ValidationCheck MustNotBeInMonth(this NotNullCondition<DateTime?> conditional, MonthOfYear month)
        {
            return conditional.CreateValidationCheck(x => x.MustNotBeInMonth(month));
        }

        private static ValidationCheck MonthMustBeInRange(this NotNullCondition<DateTime?> conditional, MonthOfYear startRange, MonthOfYear endRange)
        {
            return conditional.CreateValidationCheck(x => x.MonthMustBeInRange(startRange, endRange));
        }

        private static ValidationCheck MonthMustBeNotInRange(this NotNullCondition<DateTime?> conditional, MonthOfYear startRange, MonthOfYear endRange)
        {
            return conditional.CreateValidationCheck(x => x.MonthMustBeNotInRange(startRange, endRange));
        }
    }
}
