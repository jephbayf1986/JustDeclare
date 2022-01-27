using JustDeclare.Models;

namespace JustDeclare
{
    public static partial class JustDeclareExtensions
    {
        public static T UseCustomMessage<T>(this T test, string message)
            where T : ValidationCheck
        {
            test.SetCustomMessage(message);

            return test;
        }

        public static T EndValidationIfFails<T>(this T test)
            where T : ValidationCheck
        {
            test.StopValidatingOnFailure();

            return test;
        }

        internal static ValidationCheck Inverted(this ValidationCheck check)
        {
            check.InvertResult();

            return check;
        }
    }
}