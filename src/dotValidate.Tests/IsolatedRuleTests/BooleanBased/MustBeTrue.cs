using Shouldly;
using Xunit;

namespace dotValidate.Tests.IsolatedRuleTests.BooleanBased
{
    public class MustBeTrue : BooleanTestClass
    {
        private class TestClassValidationRules : ValidationRules<TestClass>
        {
            public TestClassValidationRules()
            {
                DeclareRules(
                        x => x.TestNullable.MustBeTrue(),
                        x => x.TestNonNullable.MustBeTrue()
                    );
            }
        }

        [Fact]
        public void GivenAboveRules_WhenAllValuesTrue_PassTest()
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
        public void GivenAboveRules_WhenNonNullableIsFalse_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            request.TestNonNullable = false;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestNonNullable), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("true", Case.Insensitive));
        }

        [Fact]
        public void GivenAboveRules_WhenNullableIsFalse_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            request.TestNullable = false;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestNullable), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("true", Case.Insensitive));
        }

        [Fact]
        public void GivenAboveRules_WhenNullableIsNull_FailTestWithPropertyInMessage()
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
                                              x => x.FailureSummary().ShouldContain("true", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("null", Case.Insensitive));
        }

        private static TestClass GetTestClass()
        {
            return new TestClass()
            {
                TestNullable = true,
                TestNonNullable = true,
            };
        }
    }
}