using dotValidate.Enums;
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
        /// Must Be Same Day as...
        /// </summary>
        /// <param name="value">DateTime value to validate</param>
        /// <param name="target">Target DateTime to be same date as</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustBeSameDateAs(this DateTime value, DateTime target)
        {
            return new DatePartEqual(value, target);
        }

        /// <summary>
        /// Must Be Same Day as...
        /// </summary>
        /// <param name="value">Nullable DateTime value to validate</param>
        /// <param name="target">Target DateTime to be same date as</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustBeSameDateAs(this DateTime? value, DateTime target)
        {
            return new DatePartEqual(value, target);
        }

        /// <summary>
        /// Must Not Be Same Day as...
        /// </summary>
        /// <param name="value">DateTime value to validate</param>
        /// <param name="target">Target DateTime to avoid</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustNotBeSameDateAs(this DateTime value, DateTime target)
        {
            return value.MustBeSameDateAs(target)
                        .Inverted();
        }

        /// <summary>
        /// Must Not Be Same Day as...
        /// </summary>
        /// <param name="value">Nullable DateTime value to validate</param>
        /// <param name="target">Target DateTime to avoid</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustNotBeSameDateAs(this DateTime? value, DateTime target)
        {
            return value.MustBeSameDateAs(target)
                        .Inverted();
        }

        /// <summary>
        /// Must Be Later Than Or Equal To...
        /// </summary>
        /// <param name="value">DateTime value to validate</param>
        /// <param name="minimumDateTime">Minimum allowed DateTime</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustBeLaterThanOrEqualTo(this DateTime value, DateTime minimumDateTime)
        {
            return new DateMinimum(value, minimumDateTime);
        }

        /// <summary>
        /// Must Be Later Than Or Equal To...
        /// </summary>
        /// <param name="value">Nullable DateTime value to validate</param>
        /// <param name="minimumDateTime">Minimum allowed DateTime</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustBeLaterThanOrEqualTo(this DateTime? value, DateTime minimumDateTime)
        {
            return new DateMinimum(value, minimumDateTime);
        }

        /// <summary>
        /// Must Be Earlier Than Or Equal To...
        /// </summary>
        /// <param name="value">DateTime value to validate</param>
        /// <param name="maximumDateTime">Maximum allowed DateTime</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustBeEarlierThanOrEqualTo(this DateTime value, DateTime maximumDateTime)
        {
            return new DateMaximum(value, maximumDateTime);
        }

        /// <summary>
        /// Must Be Earlier Than Or Equal To...
        /// </summary>
        /// <param name="value">Nullable DateTime value to validate</param>
        /// <param name="maximumDateTime">Maximum allowed DateTime</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustBeEarlierThanOrEqualTo(this DateTime? value, DateTime maximumDateTime)
        {
            return new DateMaximum(value, maximumDateTime);
        }

        /// <summary>
        /// Must Be Later Than...
        /// </summary>
        /// <param name="value">DateTime subject to validation rule</param>
        /// <param name="targetDateTime">Target DateTime to be later than</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustBeLaterThan(this DateTime value, DateTime targetDateTime)
        {
            return new DateMaximum(value, targetDateTime)
                        .Inverted();
        }

        /// <summary>
        /// Must Be Later Than...
        /// </summary>
        /// <param name="value">Nullable DateTime subject to validation rule</param>
        /// <param name="targetDateTime">Target DateTime to be later than</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustBeLaterThan(this DateTime? value, DateTime targetDateTime)
        {
            return new DateMaximum(value, targetDateTime)
                        .Inverted();
        }

        /// <summary>
        /// Must Be Earlier Than...
        /// </summary>
        /// <param name="value">DateTime subject to validation rule</param>
        /// <param name="targetDateTime">Target DateTime to be earlier than</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustBeEarlierThan(this DateTime value, DateTime targetDateTime)
        {
            return new DateMinimum(value, targetDateTime)
                        .Inverted();
        }

        /// <summary>
        /// Must Be Earlier Than...
        /// </summary>
        /// <param name="value">Nullable DateTime subject to validation rule</param>
        /// <param name="targetDateTime">Target DateTime to be earlier than</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustBeEarlierThan(this DateTime? value, DateTime targetDateTime)
        {
            return new DateMinimum(value, targetDateTime)
                        .Inverted();
        }

        /// <summary>
        /// Must Be Later Than Or The Same Date As...
        /// </summary>
        /// <param name="value">DateTime value to validate</param>
        /// <param name="minimumDate">Minimum allowed Date (Note: Time Part is ignored)</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustBeLaterThanOrSameDateAs(this DateTime value, DateTime minimumDate)
        {
            return new DateMinimum(value, minimumDate.Date);
        }

        /// <summary>
        /// Must Be Later Than Or The Same Date As...
        /// </summary>
        /// <param name="value">Nullable DateTime value to validate</param>
        /// <param name="minimumDate">Minimum allowed Date (Note: Time Part is ignored)</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustBeLaterThanOrSameDateAs(this DateTime? value, DateTime minimumDate)
        {
            return new DateMinimum(value, minimumDate.Date);
        }

        /// <summary>
        /// Must Be Earlier Than Or The Same Date As...
        /// </summary>
        /// <param name="value">DateTime value to validate</param>
        /// <param name="maximumDate">Maximum allowed Date (Note: Time Part is ignored)</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustBeEarlierThanOrSameDateAs(this DateTime value, DateTime maximumDate)
        {
            var inverseMinDate = maximumDate.Date.AddDays(1);

            return new DateMinimum(value, inverseMinDate)
                        .Inverted();
        }

        /// <summary>
        /// Must Be Earlier Than Or The Same Date As...
        /// </summary>
        /// <param name="value">Nullable DateTime value to validate</param>
        /// <param name="maximumDate">Maximum allowed Date (Note: Time Part is ignored)</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustBeEarlierThanOrSameDateAs(this DateTime? value, DateTime maximumDate)
        {
            var inverseMinDate = maximumDate.Date.AddDays(1);

            return new DateMinimum(value, inverseMinDate)
                        .Inverted();
        }

        /// <summary>
        /// Must Be In Past
        /// </summary>
        /// <param name="value">DateTime value to validate</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustBeInPast(this DateTime value)
        {
            return value.MustBeEarlierThan(DateTime.Now);
        }

        /// <summary>
        /// Must Be In Past
        /// </summary>
        /// <param name="value">Nullable DateTime value to validate</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustBeInPast(this DateTime? value)
        {
            return value.MustBeEarlierThan(DateTime.Now);
        }

        /// <summary>
        /// Must Be In Future
        /// </summary>
        /// <param name="value">DateTime value to validate</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustBeInFuture(this DateTime value)
        {
            return value.MustBeLaterThan(DateTime.Now);
        }

        /// <summary>
        /// Must Be In Future
        /// </summary>
        /// <param name="value">Nullable DateTime value to validate</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustBeInFuture(this DateTime? value)
        {
            return value.MustBeLaterThan(DateTime.Now);
        }

        /// <summary>
        /// Age Must Be Younger Than
        /// </summary>
        /// <param name="value">DateTime value to validate</param>
        /// <param name="maximumYears">Maximum Allowed Age in Years</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck AgeMustBeYoungerThan(this DateTime value, int maximumYears)
        {
            var targetDateTime = DateTime.Now.Date.AddYears(-maximumYears - 1);

            return value.MustBeLaterThan(targetDateTime);
        }

        /// <summary>
        /// Age Must Be Younger Than
        /// </summary>
        /// <param name="value">Nullable DateTime value to validate</param>
        /// <param name="maximumYears">Maximum Allowed Age in Years</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck AgeMustBeYoungerThan(this DateTime? value, int maximumYears)
        {
            var targetDateTime = DateTime.Now.Date.AddYears(-maximumYears - 1);

            return value.MustBeLaterThan(targetDateTime);
        }

        /// <summary>
        /// Age Must Be Older Than
        /// </summary>
        /// <param name="value">DateTime value to validate</param>
        /// <param name="minimumYears">Minimum Allowed Age in Years</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck AgeMustBeOlderThan(this DateTime value, int minimumYears)
        {
            var maximumDate = DateTime.Now.Date.AddYears(-minimumYears);

            return value.MustBeEarlierThanOrSameDateAs(maximumDate);
        }






















        private static ValidationCheck MustBeInRange(this DateTime value, DateTime rangeStart, DateTime rangeEnd)
        {
            return new DateRange(value, rangeStart, rangeEnd);
        }

        private static ValidationCheck MustNotBeInRange(this DateTime value, DateTime rangeStart, DateTime rangeEnd)
        {
            return value.MustBeInRange(rangeStart, rangeEnd)
                        .Inverted();
        }
        
        private static ValidationCheck AgeMustBeInRange(this DateTime value, int rangeStartYears, int rangeEndYears)
        {
            var rangeStart = DateTime.Now.Date.AddYears(-rangeStartYears);
            var rangeEnd = DateTime.Now.Date.AddYears(-rangeEndYears);

            return new DateRange(value, rangeStart, rangeEnd);
        }
        
        private static ValidationCheck AgeMustNotBeInRange(this DateTime value, int rangeStartYears, int rangeEndYears)
        {
            return value.AgeMustBeInRange(rangeStartYears, rangeEndYears)
                        .Inverted();
        }

        private static ValidationCheck MustBeDayOfTheWeek(this DateTime value, DayOfWeek target)
        {
            return new DateDayOfWeek(value, target);
        }

        private static ValidationCheck MustNotBeDayOfTheWeek(this DateTime value, DayOfWeek target)
        {
            return value.MustBeDayOfTheWeek(target)
                        .Inverted();
        }

        private static ValidationCheck MustBeAWeekDay(this DateTime value)
        {
            return new DateWeekDay(value);
        }

        private static ValidationCheck MustBeAWeekendDay(this DateTime value)
        {
            return value.MustBeAWeekDay()
                        .Inverted();
        }

        private static ValidationCheck MustBeInYear(this DateTime value, int year)
        {
            return new DateYear(value, year);
        }

        private static ValidationCheck MustNotBeInYear(this DateTime value, int year)
        {
            return value.MustBeInYear(year)
                        .Inverted();
        }

        private static ValidationCheck YearMustBeInRange(this DateTime value, int startRange, int endRange)
        {
            return new DateYearRange(value, startRange, endRange);
        }

        private static ValidationCheck YearMustBeNotInRange(this DateTime value, int startRange, int endRange)
        {
            return value.YearMustBeInRange(startRange, endRange)
                        .Inverted();
        }

        private static ValidationCheck MustBeInMonth(this DateTime value, MonthOfYear month)
        {
            return new DateMonth(value, month);
        }

        private static ValidationCheck MustNotBeInMonth(this DateTime value, MonthOfYear month)
        {
            return value.MustBeInMonth(month)
                        .Inverted();
        }

        private static ValidationCheck MonthMustBeInRange(this DateTime value, MonthOfYear startRange, MonthOfYear endRange)
        {
            return new DateMonthRange(value, startRange, endRange);
        }

        private static ValidationCheck MonthMustBeNotInRange(this DateTime value, MonthOfYear startRange, MonthOfYear endRange)
        {
            return value.MonthMustBeInRange(startRange, endRange)
                        .Inverted();
        }
    }
}