using JustDeclare.Tests.TestHelpers;
using Shouldly;
using Xunit;

namespace JustDeclare.Tests.IsolatedRuleTests.StringBased
{
    public class MustBeNoShorterThan : StringTestClass
    {
        private const int ShortMinimum = 1;
        private const int LongMinimum = 20;

        private class TestClassValidationRules : ValidationRules<TestClass>
        {
            public TestClassValidationRules()
            {
                DeclareRules(
                        x => x.TestNullable.MustBeNoShorterThan(ShortMinimum),
                        x => x.TestNonNullable.MustBeNoShorterThan(LongMinimum)
                    );
            }
        }

        [Fact]
        public void GivenAboveRules_WhenAllValuesLongerThanMinimum_PassTest()
        {
            // Arrange
            var request = GetTestClass();
            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.HasFailures.ShouldBeFalse();
        }

        [Fact]
        public void GivenAboveRules_WhenAnyStringIsNull_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            request.TestNullable = null;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestNullable), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("shortest allowed", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain($"{ShortMinimum} characters", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("null", Case.Insensitive));
        }

        private static TestClass GetTestClass()
        {
            return new TestClass()
            {
                TestNullable = RandomHelpers.RandomString(ShortMinimum + 1),
                TestNonNullable = RandomHelpers.RandomString(LongMinimum + 1)
            };
        }
    }
}