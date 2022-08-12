using dotValidate.Main.ValidationChecks;
using dotValidate.Models;
using System;

namespace dotValidate.Extensions
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
        public static ValidationCheck MustBeSameDayAs(this DateTime value, DateTime target)
        {
            return new DateEqual(value, target);
        }

        /// <summary>
        /// Must Not Be Same Day as...
        /// </summary>
        /// <param name="value">DateTime value to validate</param>
        /// <param name="target">Target DateTime to avoid</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustNotBeSameDayAs(this DateTime value, DateTime target)
        {
            return value.MustBeSameDayAs(target)
                        .Inverted();
        }
    }
}