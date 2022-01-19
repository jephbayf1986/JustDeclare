using JustDeclare.Main.ValidationChecks;
using JustDeclare.Models;

namespace JustDeclare
{
    public static partial class JustDeclareExtensions
    {
        public static ValidationCheck MustBeTrue(this bool? value)
        {
            return new BoolEqual(value, true);
        }

        public static ValidationCheck MustNotBeTrue(this bool? value)
        {
            return value.MustBeTrue()
                        .Inverted();
        }

        public static ValidationCheck MustBeFalse(this bool? value)
        {
            return new BoolEqual(value, false);
        }

        public static ValidationCheck MustNotBeFalse(this bool? value)
        {
            return value.MustBeFalse()
                        .Inverted();
        }
    }
}
