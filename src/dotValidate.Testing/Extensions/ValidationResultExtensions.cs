using dotValidate.Models;
using Shouldly;
using System;
using System.Linq;

namespace dotValidate.Testing.Extensions
{
    public static class ValidationResultExtensions
    {
        public static void ShouldHavePassed(this ValidationResult validationResult)
        {
            validationResult.HasFailures.ShouldBeFalse(validationResult.GetAdditionalInfoText());
        }

        public static void ShouldHaveFailed(this ValidationResult validationResult)
        {
            validationResult.HasFailures.ShouldBeTrue();
        }

        public static void ShouldHaveOneFailureOnly(this ValidationResult validationResult)
        {
            validationResult.Failures.Count.ShouldBe(1, validationResult.GetAdditionalInfoText());
        }

        public static void ShouldHaveFailuresCount(this ValidationResult validationResult, int numberOfFailures)
        {
            string customMessage;

            if (validationResult.HasFailures)
            {
                customMessage = validationResult.GetAdditionalInfoText();
            }
            else
            {
                customMessage = $"The validation result passed";
            }

            validationResult.Failures.Count.ShouldBe(numberOfFailures, customMessage);
        }

        public static void ShouldIncludeFailureText(this ValidationResult validationResult, string expectedMessage, StringComparison stringComparison = StringComparison.OrdinalIgnoreCase)
        {
            string customMessage;

            if (validationResult.HasFailures)
            {
                customMessage = validationResult.GetAdditionalInfoText();
            }
            else
            {
                customMessage = $"The validation result passed";
            }

            validationResult.Failures.Any(x => x.FailureDescription.IndexOf(expectedMessage, stringComparison) >= 0)
                                     .ShouldBeTrue(customMessage);
        }

        private static string GetAdditionalInfoText(this ValidationResult validationResult)
        {
            return $"The full failure summary provided was as follows: '{validationResult.FailureSummary()}'.";
        }
    }
}
