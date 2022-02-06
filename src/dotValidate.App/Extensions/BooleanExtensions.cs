using dotValidate.Main.ValidationChecks;
using dotValidate.Models;

namespace dotValidate
{
    /// <summary>
    /// Property Extensions for building Validation Rules with dotValidate
    /// </summary>
    public static partial class PropertyExtensions
    {
        /// <summary>
        /// Must Be True
        /// </summary>
        /// <param name="value">Boolean value to validate</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustBeTrue(this bool value)
        {
            return new BoolEqual(value, true);
        }

        /// <summary>
        /// Must Be True
        /// </summary>
        /// <param name="value">Nullable Boolean value to validate</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustBeTrue(this bool? value)
        {
            return new BoolEqual(value, true);
        }

        /// <summary>
        /// Must Be False
        /// </summary>
        /// <param name="value">Boolean value to validate</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustBeFalse(this bool value)
        {
            return new BoolEqual(value, false);
        }

        /// <summary>
        /// Must Be False
        /// </summary>
        /// <param name="value">Nullable Boolean value to validate</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustBeFalse(this bool? value)
        {
            return new BoolEqual(value, false);
        }

        /// <summary>
        /// Must Not Be True
        /// </summary>
        /// <param name="value">Nullable Boolean value to validate</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustNotBeTrue(this bool? value)
        {
            return value.MustBeTrue()
                        .Inverted();
        }

        /// <summary>
        /// Must Not Be False
        /// </summary>
        /// <param name="value">Nullable Boolean value to validate</param>
        /// <returns>Validation Check - <i>dotValidate</i> container for all input and output information for the validation rule</returns>
        public static ValidationCheck MustNotBeFalse(this bool? value)
        {
            return value.MustBeFalse()
                        .Inverted();
        }
    }
}