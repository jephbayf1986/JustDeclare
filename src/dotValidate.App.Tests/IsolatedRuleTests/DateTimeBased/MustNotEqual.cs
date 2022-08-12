using dotValidate.Tests.TestHelpers;
using Shouldly;
using System;
using Xunit;

namespace dotValidate.Tests.IsolatedRuleTests.DateTimeBased
{
    public class MustNotEqual : DateTimeTestClass
    {
        private static readonly DateTime TARGET = new DateTime(2020, 10, 20, 20, 20, 20);

        private class TestClassValidationRules : ValidationRules<TestClass>
        {
            public TestClassValidationRules()
            {
                DeclareRules(
                        x => x.TestNonNullable.MustNotEqual(TARGET),
                        x => x.TestNullable.MustNotEqual(TARGET)
                    );
            }
        }

        [Fact]
        public void GivenAboveRules_WhenNoValuesAtTarget_PassTest()
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
        public void GivenAboveRules_WhenAnyDateMatchesTarget_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            request.TestNonNullable = TARGET;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestNonNullable), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(request.TestNonNullable.ToString()),
                                              x => x.FailureSummary().ShouldContain(TARGET.ToString()));
        }

        private static TestClass GetTestClass()
        {
            return new TestClass()
            {
                TestNonNullable = TARGET.AddDays(RandomHelpers.IntBetween(1, 100)),
                TestNullable = TARGET.AddHours(RandomHelpers.IntBetween(-100, -1))
            };
        }
    }
}