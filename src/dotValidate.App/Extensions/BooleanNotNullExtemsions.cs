using JustDeclare.Conditions;
using JustDeclare.Models;

namespace JustDeclare
{
    public static partial class JustDeclareExtensions
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
