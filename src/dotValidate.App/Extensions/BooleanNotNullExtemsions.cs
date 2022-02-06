using dotValidate.Conditions;
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
        /// <param name="conditional">Not Null Condition - Returned from WhenNotNull()</param>
        /// <returns>Validation Check</returns>
        public static ValidationCheck MustBeTrue(this NotNullCondition<bool?> conditional)
        {
            return conditional.CreateValidationCheck(MustBeTrue);
        }

        /// <summary>
        /// Must Be False
        /// </summary>
        /// <param name="conditional">Not Null Condition - Returned from WhenNotNull()</param>
        /// <returns>Validation Check</returns>
        public static ValidationCheck MustBeFalse(this NotNullCondition<bool?> conditional)
        {
            return conditional.CreateValidationCheck(MustBeFalse);
        }
    }
}
