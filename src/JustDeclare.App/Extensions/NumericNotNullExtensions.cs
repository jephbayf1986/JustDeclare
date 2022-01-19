using JustDeclare.Conditions;
using JustDeclare.Main.ValidationChecks;
using JustDeclare.Models;
using System;

namespace JustDeclare
{
    public static partial class JustDeclareExtensions
    {
        public static ValidationCheck MustBeZero<T>(this NotNullCondition<T?> conditional)
            where T : struct, IComparable, IFormattable
        {
            return conditional.CreateValidationCheck(x => new NumericEqual<T>(x, 0));
        }

        public static ValidationCheck MustBeNoMoreThan<T>(this NotNullCondition<T?> conditional, IComparable maximum)
            where T : struct, IComparable, IFormattable
        {
            return conditional.CreateValidationCheck(x => new NumericMaximum<T>(x, maximum));
        }

        public static ValidationCheck MustBeNoLessThan<T>(this NotNullCondition<T?> conditional, IComparable minimum)
            where T : struct, IComparable, IFormattable
        {
            return conditional.CreateValidationCheck(x => new NumericMinimum<T>(x, minimum));
        }

        public static ValidationCheck MustBeNoLongerThan(this NotNullCondition<string> conditional, int maximumLength)
        {
            return conditional.CreateValidationCheck(x => x.MustBeNoLongerThan(maximumLength));
        }

        public static ValidationCheck MustBeNoShorterThan(this NotNullCondition<string> conditional, int minimumLength)
        {
            return conditional.CreateValidationCheck(x => x.MustBeNoShorterThan(minimumLength));
        }
    }
}
