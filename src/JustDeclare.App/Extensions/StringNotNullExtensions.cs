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

        public static ValidationCheck MustBeNoLongerThan(this NotNullCondition<string> conditional, int maximumLength)
        {
            return conditional.CreateValidationCheck(x => x.MustBeNoLongerThan(maximumLength));
        }

        public static ValidationCheck MustBeNoShorterThan(this NotNullCondition<string> conditional, int minimumLength)
        {
            return conditional.CreateValidationCheck(x => x.MustBeNoShorterThan(minimumLength));
        }

        public static ValidationCheck MustMatchPattern(this NotNullCondition<string> conditional, string pattern)
        {
            return conditional.CreateValidationCheck(x => x.MustMatchPattern(pattern));
        }
    }
}
