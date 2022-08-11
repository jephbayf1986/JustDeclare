using dotValidate.Tests.TestHelpers;
using Shouldly;
using Xunit;

namespace dotValidate.Tests.IsolatedRuleTests.StringBased
{
    public class MustBeNoShorterThan : StringTestClass
    {
        private const int SHORT_MINIMUM = 1;
        private const int LONG_MINIMUM = 20;

        private class TestClassValidationRules : ValidationRules<TestClass>
        {
            public TestClassValidationRules()
            {
                DeclareRules(
                        x => x.TestNullable.MustBeNoShorterThan(SHORT_MINIMUM),
                        x => x.TestNonNullable.MustBeNoShorterThan(LONG_MINIMUM)
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
                                              x => x.FailureSummary().ShouldContain("shortest allowed length", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain($"{SHORT_MINIMUM} characters", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("null", Case.Insensitive));
        }

        [Fact]
        public void GivenAboveRules_WhenAnyStringIsShorterThanMinimum_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            request.TestNonNullable = RandomHelpers.RandomString(LONG_MINIMUM - 1);

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestNonNullable), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("shortest allowed length", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain($"{LONG_MINIMUM} characters", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(request.TestNonNullable.Substring(0, 10), Case.Insensitive));
        }

        private static TestClass GetTestClass()
        {
            return new TestClass()
            {
                TestNullable = RandomHelpers.RandomString(SHORT_MINIMUM + 1),
                TestNonNullable = RandomHelpers.RandomString(LONG_MINIMUM + 1)
            };
        }
    }
}