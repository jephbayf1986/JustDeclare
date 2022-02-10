using Shouldly;
using System;
using Xunit;

namespace dotValidate.Tests.IsolatedRuleTests.DateTimeBased
{
    public class MustEqual : DateTimeTestClass
    {
        private static readonly DateTime TARGET = new DateTime(2020, 10, 20, 20, 20, 20);

        private class TestClassValidationRules : ValidationRules<TestClass>
        {
            public TestClassValidationRules()
            {
                DeclareRules(
                        x => x.TestNonNullable.MustEqual(TARGET),
                        x => x.TestNullable.MustEqual(TARGET)
                    );
            }
        }

        [Fact]
        public void GivenAboveRules_WhenAllValuesAtTarget_PassTest()
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
        public void GivenAboveRules_WhenNullableIntValueNull_FailTestWithPropertyInMessage()
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
                                              x => x.FailureSummary().ShouldContain("equal to", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("null", Case.Insensitive));
        }

        [Fact]
        public void GivenAboveRules_WhenAnyValueDiffersFromTarget_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            var actualValue = new DateTime();
            request.TestNonNullable = actualValue;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestNonNullable), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("equal to", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(actualValue.ToString()));
        }

        private static TestClass GetTestClass()
        {
            return new TestClass()
            {
                TestNonNullable = TARGET,
                TestNullable = TARGET
            };
        }
    }
}
