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
        /// Must Be...
        /// </summary>
        /// <param name="value">String value to validate</param>
        /// <param name="target">Target string to equal</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustBe(this string value, string target)
        {
            return new StringEqual(value, target);
        }

        /// <summary>
        /// Must Be...
        /// </summary>
        /// <param name="value">String value to validate</param>
        /// <param name="target">Target string to equal</param>
        /// <param name="caseSensitivity">Case sensitivity to be used in comparison</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustBe(this string value, string target, Case caseSensitivity)
        {
            return new StringEqual(value, target, caseSensitivity);
        }

        /// <summary>
        /// Must Not Be...
        /// </summary>
        /// <param name="value">String value to validate</param>
        /// <param name="target">Target string to avoid</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustNotBe(this string value, string target)
        {
            return value.MustBe(target)
                        .Inverted();
        }

        /// <summary>
        /// Must Not Be...
        /// </summary>
        /// <param name="value">String value to validate</param>
        /// <param name="target">Target string to avoid</param>
        /// <param name="caseSensitivity">Case sensitivity to be used in comparison</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustNotBe(this string value, string target, Case caseSensitivity)
        {
            return value.MustBe(target, caseSensitivity)
                        .Inverted();
        }

        /// <summary>
        /// Must Not Be Blank
        /// </summary>
        /// <param name="value">String value to validate</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustNotBeBlank(this string value)
        {
            return value.MustBeBlank()
                        .Inverted();
        }

        /// <summary>
        /// Must Be Blank
        /// </summary>
        /// <param name="value">String value to validate</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustBeBlank(this string value)
        {
            return new StringBlank(value);
        }

        /// <summary>
        /// Must Be No Longer Than...
        /// </summary>
        /// <param name="value">String value to validate</param>
        /// <param name="maximumLength">Maximum allowed length of text value</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustBeNoLongerThan(this string value, int maximumLength)
        {
            return new StringMaximumLength(value, maximumLength);
        }

        /// <summary>
        /// Must Be No Shorter Than...
        /// </summary>
        /// <param name="value">String value to validate</param>
        /// <param name="minimumLength">Minimum allowed length of text value</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustBeNoShorterThan(this string value, int minimumLength)
        {
            return new StringMinimumLength(value, minimumLength);
        }

        /// <summary>
        /// Must Contain...
        /// </summary>
        /// <param name="value">String value to validate</param>
        /// <param name="target">Target string to contain</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustContain(this string value, string target)
        {
            return new StringContains(value, target);
        }

        /// <summary>
        /// Must Contain...
        /// </summary>
        /// <param name="value">String value to validate</param>
        /// <param name="target">Target string to contain</param>
        /// <param name="caseSensitivity">Case sensitivity to be used in comparison</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustContain(this string value, string target, Case caseSensitivity)
        {
            return new StringContains(value, target, caseSensitivity);
        }

        /// <summary>
        /// Must Not Contain...
        /// </summary>
        /// <param name="value">String value to validate</param>
        /// <param name="target">Target string to aviod</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustNotContain(this string value, string target)
        {
            return value.MustContain(target)
                        .Inverted();
        }

        /// <summary>
        /// Must Not Contain...
        /// </summary>
        /// <param name="value">String value to validate</param>
        /// <param name="target">Target string to aviod</param>
        /// <param name="caseSensitivity">Case sensitivity to be used in comparison</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustNotContain(this string value, string target, Case caseSensitivity)
        {
            return value.MustContain(target, caseSensitivity)
                        .Inverted();
        }

        /// <summary>
        /// Must Start With...
        /// </summary>
        /// <param name="value">String value to validate</param>
        /// <param name="target">Target string to start with</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustStartWith(this string value, string target)
        {
            return new StringStartsWith(value, target);
        }

        /// <summary>
        /// Must Start With...
        /// </summary>
        /// <param name="value">String value to validate</param>
        /// <param name="target">Target string to start with</param>
        /// <param name="caseSensitivity">Case sensitivity to be used in comparison</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustStartWith(this string value, string target, Case caseSensitivity)
        {
            return new StringStartsWith(value, target, caseSensitivity);
        }

        /// <summary>
        /// Must Not Start With...
        /// </summary>
        /// <param name="value">String value to validate</param>
        /// <param name="target">Target string to aviod</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustNotStartWith(this string value, string target)
        {
            return value.MustStartWith(target)
                        .Inverted();
        }

        /// <summary>
        /// Must Not Start With...
        /// </summary>
        /// <param name="value">String value to validate</param>
        /// <param name="target">Target string to aviod</param>
        /// <param name="caseSensitivity">Case sensitivity to be used in comparison</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustNotStartWith(this string value, string target, Case caseSensitivity)
        {
            return value.MustStartWith(target, caseSensitivity)
                        .Inverted();
        }

        /// <summary>
        /// Must End With...
        /// </summary>
        /// <param name="value">String value to validate</param>
        /// <param name="target">Target string to end with</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustEndWith(this string value, string target)
        {
            return new StringEndsWith(value, target);
        }

        /// <summary>
        /// Must End With...
        /// </summary>
        /// <param name="value">String value to validate</param>
        /// <param name="target">Target string to end with</param>
        /// <param name="caseSensitivity">Case sensitivity to be used in comparison</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustEndWith(this string value, string target, Case caseSensitivity)
        {
            return new StringEndsWith(value, target, caseSensitivity);
        }

        /// <summary>
        /// Must Not End With...
        /// </summary>
        /// <param name="value">String value to validate</param>
        /// <param name="target">Target string to aviod</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustNotEndWith(this string value, string target)
        {
            return value.MustEndWith(target)
                        .Inverted();
        }

        /// <summary>
        /// Must Not End With...
        /// </summary>
        /// <param name="value">String value to validate</param>
        /// <param name="target">Target string to aviod</param>
        /// <param name="caseSensitivity">Case sensitivity to be used in comparison</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustNotEndWith(this string value, string target, Case caseSensitivity)
        {
            return value.MustEndWith(target, caseSensitivity)
                        .Inverted();
        }

        /// <summary>
        /// Must Match Pattern...
        /// </summary>
        /// <param name="value">String value to validate</param>
        /// <param name="pattern">Regex pattern to check against</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustMatchPattern(this string value, string pattern)
        {
            return new StringRegexMatch(value, pattern);
        }

        /// <summary>
        /// Must Not Match Pattern...
        /// </summary>
        /// <param name="value">String value to validate</param>
        /// <param name="pattern">Regex pattern to check against</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustNotMatchPattern(this string value, string pattern)
        {
            return value.MustMatchPattern(pattern)
                        .Inverted();
        }
    }
}