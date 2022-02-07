using dotValidate.Conditions;
using dotValidate.Enums;
using dotValidate.Models;

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
        /// <param name="conditional">Not Null Condition - Returned from WhenNotNull()</param>
        /// <param name="target">Target string to equal</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustBe(this NotNullCondition<string> conditional, string target)
        {
            return conditional.CreateValidationCheck(x => x.MustBe(target));
        }

        /// <summary>
        /// Must Be...
        /// </summary>
        /// <param name="conditional">Not Null Condition - Returned from WhenNotNull()</param>
        /// <param name="target">Target string to equal</param>
        /// <param name="caseSensitivity">Case sensitivity to be used in comparison</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustBe(this NotNullCondition<string> conditional, string target, Case caseSensitivity)
        {
            return conditional.CreateValidationCheck(x => x.MustBe(target, caseSensitivity));
        }

        /// <summary>
        /// Must Not Be...
        /// </summary>
        /// <param name="conditional">Not Null Condition - Returned from WhenNotNull()</param>
        /// <param name="target">Target string to aviod</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustNotBe(this NotNullCondition<string> conditional, string target)
        {
            return conditional.CreateValidationCheck(x => x.MustNotBe(target));
        }

        /// <summary>
        /// Must Not Be...
        /// </summary>
        /// <param name="conditional">Not Null Condition - Returned from WhenNotNull()</param>
        /// <param name="target">Target string to aviod</param>
        /// <param name="caseSensitivity">Case sensitivity to be used in comparison</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustNotBe(this NotNullCondition<string> conditional, string target, Case caseSensitivity)
        {
            return conditional.CreateValidationCheck(x => x.MustNotBe(target, caseSensitivity));
        }

        /// <summary>
        /// Must Not Be Blank
        /// </summary>
        /// <param name="conditional">Not Null Condition - Returned from WhenNotNull()</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustNotBeBlank(this NotNullCondition<string> conditional)
        {
            return conditional.CreateValidationCheck(MustNotBeBlank);
        }

        /// <summary>
        /// Must Be Blank
        /// </summary>
        /// <param name="conditional">Not Null Condition - Returned from WhenNotNull()</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustBeBlank(this NotNullCondition<string> conditional)
        {
            return conditional.CreateValidationCheck(MustBeBlank);
        }

        /// <summary>
        /// Must Be No Longer Than...
        /// </summary>
        /// <param name="conditional">Not Null Condition - Returned from WhenNotNull()</param>
        /// <param name="maximumLength">Maximum allowed length of text value</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustBeNoLongerThan(this NotNullCondition<string> conditional, int maximumLength)
        {
            return conditional.CreateValidationCheck(x => x.MustBeNoLongerThan(maximumLength));
        }

        /// <summary>
        /// Must Be No Shorter Than...
        /// </summary>
        /// <param name="conditional">Not Null Condition - Returned from WhenNotNull()</param>
        /// <param name="minimumLength">Minimum allowed length of text value</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustBeNoShorterThan(this NotNullCondition<string> conditional, int minimumLength)
        {
            return conditional.CreateValidationCheck(x => x.MustBeNoShorterThan(minimumLength));
        }

        /// <summary>
        /// Must Contain...
        /// </summary>
        /// <param name="conditional">Not Null Condition - Returned from WhenNotNull()</param>
        /// <param name="target">Target string to contain</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustContain(this NotNullCondition<string> conditional, string target)
        {
            return conditional.CreateValidationCheck(x => x.MustContain(target));
        }

        /// <summary>
        /// Must Contain...
        /// </summary>
        /// <param name="conditional">Not Null Condition - Returned from WhenNotNull()</param>
        /// <param name="target">Target string to contain</param>
        /// <param name="caseSensitivity">Case sensitivity to be used in comparison</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustContain(this NotNullCondition<string> conditional, string target, Case caseSensitivity)
        {
            return conditional.CreateValidationCheck(x => x.MustContain(target, caseSensitivity));
        }

        /// <summary>
        /// Must Not Contain...
        /// </summary>
        /// <param name="conditional">Not Null Condition - Returned from WhenNotNull()</param>
        /// <param name="target">Target string to aviod</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustNotContain(this NotNullCondition<string> conditional, string target)
        {
            return conditional.CreateValidationCheck(x => x.MustNotContain(target));
        }

        /// <summary>
        /// Must Not Contain...
        /// </summary>
        /// <param name="conditional">Not Null Condition - Returned from WhenNotNull()</param>
        /// <param name="target">Target string to aviod</param>
        /// <param name="caseSensitivity">Case sensitivity to be used in comparison</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustNotContain(this NotNullCondition<string> conditional, string target, Case caseSensitivity)
        {
            return conditional.CreateValidationCheck(x => x.MustNotContain(target, caseSensitivity));
        }

        /// <summary>
        /// Must Start With...
        /// </summary>
        /// <param name="conditional">Not Null Condition - Returned from WhenNotNull()</param>
        /// <param name="target">Target string to start with</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustStartWith(this NotNullCondition<string> conditional, string target)
        {
            return conditional.CreateValidationCheck(x => x.MustStartWith(target));
        }

        /// <summary>
        /// Must Start With...
        /// </summary>
        /// <param name="conditional">Not Null Condition - Returned from WhenNotNull()</param>
        /// <param name="target">Target string to start with</param>
        /// <param name="caseSensitivity">Case sensitivity to be used in comparison</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustStartWith(this NotNullCondition<string> conditional, string target, Case caseSensitivity)
        {
            return conditional.CreateValidationCheck(x => x.MustStartWith(target, caseSensitivity));
        }

        /// <summary>
        /// Must Not Start With...
        /// </summary>
        /// <param name="conditional">Not Null Condition - Returned from WhenNotNull()</param>
        /// <param name="target">Target string to aviod</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustNotStartWith(this NotNullCondition<string> conditional, string target)
        {
            return conditional.CreateValidationCheck(x => x.MustNotStartWith(target));
        }

        /// <summary>
        /// Must Not Start With...
        /// </summary>
        /// <param name="conditional">Not Null Condition - Returned from WhenNotNull()</param>
        /// <param name="target">Target string to aviod</param>
        /// <param name="caseSensitivity">Case sensitivity to be used in comparison</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustNotStartWith(this NotNullCondition<string> conditional, string target, Case caseSensitivity)
        {
            return conditional.CreateValidationCheck(x => x.MustNotStartWith(target, caseSensitivity));
        }

        /// <summary>
        /// Must End With...
        /// </summary>
        /// <param name="conditional">Not Null Condition - Returned from WhenNotNull()</param>
        /// <param name="target">Target string to end with</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustEndWith(this NotNullCondition<string> conditional, string target)
        {
            return conditional.CreateValidationCheck(x => x.MustEndWith(target));
        }

        /// <summary>
        /// Must End With...
        /// </summary>
        /// <param name="conditional">Not Null Condition - Returned from WhenNotNull()</param>
        /// <param name="target">Target string to end with</param>
        /// <param name="caseSensitivity">Case sensitivity to be used in comparison</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustEndWith(this NotNullCondition<string> conditional, string target, Case caseSensitivity)
        {
            return conditional.CreateValidationCheck(x => x.MustEndWith(target, caseSensitivity));
        }

        /// <summary>
        /// Must Not End With...
        /// </summary>
        /// <param name="conditional">Not Null Condition - Returned from WhenNotNull()</param>
        /// <param name="target">Target string to aviod</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustNotEndWith(this NotNullCondition<string> conditional, string target)
        {
            return conditional.CreateValidationCheck(x => x.MustNotEndWith(target));
        }

        /// <summary>
        /// Must Not End With...
        /// </summary>
        /// <param name="conditional">Not Null Condition - Returned from WhenNotNull()</param>
        /// <param name="target">Target string to aviod</param>
        /// <param name="caseSensitivity">Case sensitivity to be used in comparison</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustNotEndWith(this NotNullCondition<string> conditional, string target, Case caseSensitivity)
        {
            return conditional.CreateValidationCheck(x => x.MustNotEndWith(target, caseSensitivity));
        }

        /// <summary>
        /// Must Match Pattern...
        /// </summary>
        /// <param name="conditional">Not Null Condition - Returned from WhenNotNull()</param>
        /// <param name="pattern">Regex pattern to check against</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustMatchPattern(this NotNullCondition<string> conditional, string pattern)
        {
            return conditional.CreateValidationCheck(x => x.MustMatchPattern(pattern));
        }

        /// <summary>
        /// Must Not Match Pattern...
        /// </summary>
        /// <param name="conditional">Not Null Condition - Returned from WhenNotNull()</param>
        /// <param name="pattern">Regex pattern to check against</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustNotMatchPattern(this NotNullCondition<string> conditional, string pattern)
        {
            return conditional.CreateValidationCheck(x => x.MustNotMatchPattern(pattern));
        }
    }
}
