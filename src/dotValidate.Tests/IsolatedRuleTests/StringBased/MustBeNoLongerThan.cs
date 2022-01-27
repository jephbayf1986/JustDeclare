using dotValidate.Tests.TestHelpers;
using Shouldly;
using Xunit;

namespace dotValidate.Tests.IsolatedRuleTests.StringBased
{
    public class MustBeNoLongerThan : StringTestClass
    {
        private const int SHORT_MAXIMUM = 8;
        private const int LONG_MAXIMUM = 100;

        private class TestClassValidationRules : ValidationRules<TestClass>
        {
            public TestClassValidationRules()
            {
                DeclareRules(
                        x => x.TestNullable.MustBeNoLongerThan(SHORT_MAXIMUM),
                        x => x.TestNonNullable.MustBeNoLongerThan(LONG_MAXIMUM)
                    );
            }
        }

        [Fact]
        public void GivenAboveRules_WhenAllValuesShorterThanMaximum_PassTest()
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
        public void GivenAboveRules_WhenAnyValuesNull_PassTest()
        {
            // Arrange
            var request = GetTestClass();
            request.TestNullable = null;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.HasFailures.ShouldBeFalse();
        }

        [Fact]
        public void GivenAboveRules_WhenAnyStringIsLongerThanMaximum_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            request.TestNonNullable = RandomHelpers.RandomString(LONG_MAXIMUM + 1);

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestNonNullable), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("longest allowed length", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain($"{LONG_MAXIMUM} characters", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(request.TestNonNullable.Substring(0, 10), Case.Insensitive));
        }

        private static TestClass GetTestClass()
        {
            return new TestClass()
            {
                TestNullable = RandomHelpers.RandomString(SHORT_MAXIMUM - 1),
                TestNonNullable = RandomHelpers.RandomString(LONG_MAXIMUM - 1)
            };
        }
    }
}