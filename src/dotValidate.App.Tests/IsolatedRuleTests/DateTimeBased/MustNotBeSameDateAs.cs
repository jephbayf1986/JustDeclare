using dotValidate.Tests.TestHelpers;
using Shouldly;
using System;
using Xunit;

namespace dotValidate.Tests.IsolatedRuleTests.DateTimeBased
{
    public class MustNotBeSameDateAs : DateTimeTestClass
    {
        private static readonly DateTime TARGET = new DateTime(2020, 10, 20, 20, 20, 20);

        private class TestClassValidationRules : ValidationRules<TestClass>
        {
            public TestClassValidationRules()
            {
                DeclareRules(
                        x => x.TestNonNullable.MustNotBeSameDateAs(TARGET),
                        x => x.TestNullable.MustNotBeSameDateAs(TARGET)
                    );
            }
        }

        [Fact]
        public void GivenAboveRules_WhenNoValuesFallOnTargetDate_PassTest()
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
        public void GivenAboveRules_WhenNullableDateIsNull_PassTest()
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
        public void GivenAboveRules_WhenAnyDateMatchesTargetDate_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            request.TestNonNullable = TARGET.AddHours(-10).AddMinutes(-10).AddSeconds(-10);

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestNonNullable), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(request.TestNonNullable.ToShortDateString()),
                                              x => x.FailureSummary().ShouldContain(TARGET.ToShortDateString()));
        }

        private static TestClass GetTestClass()
        {
            return new TestClass()
            {
                TestNonNullable = TARGET.AddDays(RandomHelpers.IntBetween(1, 100)),
                TestNullable = TARGET.AddDays(RandomHelpers.IntBetween(-100, -1))
            };
        }
    }
}