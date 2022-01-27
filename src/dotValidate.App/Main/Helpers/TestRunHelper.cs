using JustDeclare.Main.Models;
using JustDeclare.Models;
using System.Collections.Generic;

namespace JustDeclare.Main.Helpers
{
    internal static class TestRunHelper
    {
        public static ValidationResult RunAllTestsFor<TInput>(this IEnumerable<ValidationTestContainer<TInput>> testFuncs, TInput input)
        {
            var requestName = typeof(TInput).Name;

            if (input == null)
                return ValidationResult.NullRequest(requestName);

            var result = new ValidationResult(requestName);

            foreach (var testFunc in testFuncs)
            {
                var test = testFunc.CreateTest(input);

                //test.IgnoreIfConditionsNotMet(input);

                test.SetPropertyName(testFunc.PropertyName);

                if (!test.Passed)
                {
                    result.AddFailure(test.Failure);

                    if (test.EndValidationOnFailure)
                        break;
                }
            }

            return result;
        }
    }
}
