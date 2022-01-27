using Shouldly;
using Xunit;

namespace JustDeclare.Tests.IsolatedRuleTests.BooleanBased
{
    public class MustNotBeTrue : BooleanTestClass
    {
        private class TestClassValidationRules : ValidationRules<TestClass>
        {
            public TestClassValidationRules()
            {
                DeclareRules(
                        x => x.TestNullable.MustNotBeTrue()
                    );
            }
        }

        [Fact]
        public void GivenAboveRules_WhenNullableIsFalse_PassTest()
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
        public void GivenAboveRules_WhenNullableIsNull_PassTest()
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
        public void GivenAboveRules_WhenNullableIsTrue_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            request.TestNullable = true;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestNullable), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("true", Case.Insensitive));
        }

        private static TestClass GetTestClass()
        {
            return new TestClass()
            {
                TestNullable = false,
                TestNonNullable = false,
            };
        }
    }
}