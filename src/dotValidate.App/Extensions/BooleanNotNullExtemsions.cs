using dotValidate.Conditions;
using dotValidate.Models;

namespace dotValidate
{
    /// <summary>
    /// Property Extensions for building Validation Rules with dotValidate
    /// </summary>
    public static partial class PropertyExtensions
    {
        public static ValidationCheck MustBeTrue(this NotNullCondition<bool?> conditional)
        {
            return conditional.CreateValidationCheck(MustBeTrue);
        }

        public static ValidationCheck MustBeFalse(this NotNullCondition<bool?> conditional)
        {
            return conditional.CreateValidationCheck(MustBeFalse);
        }
    }
}
