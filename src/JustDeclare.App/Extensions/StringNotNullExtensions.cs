using JustDeclare.Conditions;
using JustDeclare.Models;

namespace JustDeclare
{
    public static partial class JustDeclareExtensions
    {
        public static ValidationCheck MustNotBeBlank(this NotNullCondition<string> conditional)
        {
            return conditional.CreateValidationCheck(MustNotBeBlank);
        }

        public static ValidationCheck MustBeBlank(this NotNullCondition<string> conditional)
        {
            return conditional.CreateValidationCheck(MustBeBlank);
        }

        public static ValidationCheck MustMatchPattern(this NotNullCondition<string> conditional, string pattern)
        {
            return conditional.CreateValidationCheck(x => x.MustMatchPattern(pattern));
        }
    }
}
