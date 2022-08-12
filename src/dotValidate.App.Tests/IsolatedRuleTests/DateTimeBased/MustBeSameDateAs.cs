using Shouldly;
using System;
using Xunit;

namespace dotValidate.Tests.IsolatedRuleTests.DateTimeBased
{
    public class MustBeSameDateAs : DateTimeTestClass
    {
        private static readonly DateTime TARGET = new DateTime(2020, 10, 20, 20, 20, 20);

        private class TestClassValidationRules : ValidationRules<TestClass>
        {
            public TestClassValidationRules()
            {
                DeclareRules(
                        x => x.TestNonNullable.MustBeSameDateAs(TARGET),
                        x => x.TestNullable.MustBeSameDateAs(TARGET)
                    );
            }
        }

        [Fact]
        public void GivenAboveRules_WhenAllValuesSameDayAsTarget_PassTest()
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
                                              x => x.FailureSummary().ShouldContain("fall on the same date as", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("null", Case.Insensitive));
        }

        [Fact]
        public void GivenAboveRules_WhenAnyValueDiffersFromTarget_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            var actualValue = DateTime.Now;
            request.TestNonNullable = actualValue;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestNonNullable), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("fall on the same date as", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(actualValue.ToShortDateString()));
        }

        private static TestClass GetTestClass()
        {
            return new TestClass()
            {
                TestNonNullable = TARGET.Date,
                TestNullable = TARGET.AddHours(-10).AddMinutes(-10).AddSeconds(-10)
            };
        }
    }
}
