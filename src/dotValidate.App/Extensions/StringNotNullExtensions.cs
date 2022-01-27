using JustDeclare.Conditions;
using JustDeclare.Models;
using JustDeclare.Models.Enums;

namespace JustDeclare
{
    public static partial class JustDeclareExtensions
    {
        public static ValidationCheck MustBe(this NotNullCondition<string> conditional, string target)
        {
            return conditional.CreateValidationCheck(x => x.MustBe(target));
        }

        public static ValidationCheck MustBe(this NotNullCondition<string> conditional, string target, MatchCase matchCase)
        {
            return conditional.CreateValidationCheck(x => x.MustBe(target, matchCase));
        }

        public static ValidationCheck MustNotBe(this NotNullCondition<string> conditional, string target)
        {
            return conditional.CreateValidationCheck(x => x.MustNotBe(target));
        }

        public static ValidationCheck MustNotBe(this NotNullCondition<string> conditional, string target, MatchCase matchCase)
        {
            return conditional.CreateValidationCheck(x => x.MustNotBe(target, matchCase));
        }

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

        public static ValidationCheck MustContain(this NotNullCondition<string> conditional, string target)
        {
            return conditional.CreateValidationCheck(x => x.MustContain(target));
        }

        public static ValidationCheck MustContain(this NotNullCondition<string> conditional, string target, MatchCase matchCase)
        {
            return conditional.CreateValidationCheck(x => x.MustContain(target, matchCase));
        }
        public static ValidationCheck MustNotContain(this NotNullCondition<string> conditional, string target)
        {
            return conditional.CreateValidationCheck(x => x.MustNotContain(target));
        }

        public static ValidationCheck MustNotContain(this NotNullCondition<string> conditional, string target, MatchCase matchCase)
        {
            return conditional.CreateValidationCheck(x => x.MustNotContain(target, matchCase));
        }

        public static ValidationCheck MustStartWith(this NotNullCondition<string> conditional, string target)
        {
            return conditional.CreateValidationCheck(x => x.MustStartWith(target));
        }

        public static ValidationCheck MustStartWith(this NotNullCondition<string> conditional, string target, MatchCase matchCase)
        {
            return conditional.CreateValidationCheck(x => x.MustStartWith(target, matchCase));
        }
        public static ValidationCheck MustNotStartWith(this NotNullCondition<string> conditional, string target)
        {
            return conditional.CreateValidationCheck(x => x.MustNotStartWith(target));
        }

        public static ValidationCheck MustNotStartWith(this NotNullCondition<string> conditional, string target, MatchCase matchCase)
        {
            return conditional.CreateValidationCheck(x => x.MustNotStartWith(target, matchCase));
        }

        public static ValidationCheck MustEndWith(this NotNullCondition<string> conditional, string target)
        {
            return conditional.CreateValidationCheck(x => x.MustEndWith(target));
        }

        public static ValidationCheck MustEndWith(this NotNullCondition<string> conditional, string target, MatchCase matchCase)
        {
            return conditional.CreateValidationCheck(x => x.MustEndWith(target, matchCase));
        }

        public static ValidationCheck MustNotEndWith(this NotNullCondition<string> conditional, string target)
        {
            return conditional.CreateValidationCheck(x => x.MustNotEndWith(target));
        }

        public static ValidationCheck MustNotEndWith(this NotNullCondition<string> conditional, string target, MatchCase matchCase)
        {
            return conditional.CreateValidationCheck(x => x.MustNotEndWith(target, matchCase));
        }

        public static ValidationCheck MustMatchPattern(this NotNullCondition<string> conditional, string pattern)
        {
            return conditional.CreateValidationCheck(x => x.MustMatchPattern(pattern));
        }

        public static ValidationCheck MustNotMatchPattern(this NotNullCondition<string> conditional, string pattern)
        {
            return conditional.CreateValidationCheck(x => x.MustNotMatchPattern(pattern));
        }

        private static ValidationCheck MustBeAnEmailAddress(this NotNullCondition<string> conditional)
        {
            return conditional.CreateValidationCheck(MustBeAnEmailAddress);
        }
    }
}
