using JustDeclare.Models.Enums;
using JustDeclare.Tests.TestHelpers;
using Shouldly;
using Xunit;

namespace JustDeclare.Tests.IsolatedRuleTests.StringBased
{
    public class MustContain : StringTestClass
    {
        private const string TARGET = "FOOBAR";

        private class TestClassValidationRules : ValidationRules<TestClass>
        {
            public TestClassValidationRules()
            {
                DeclareRules(
                        x => x.TestNullable.MustContain(TARGET),
                        x => x.TestNonNullable.MustContain(TARGET, MatchCase.Insensitve)
                    );
            }
        }

        [Fact]
        public void GivenAboveRules_WhenAllValuesContainTarget_PassTest()
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
                                              x => x.FailureSummary().ShouldContain("should contain", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(TARGET, Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("null", Case.Insensitive));
        }

        [Fact]
        public void GivenAboveRules_WhenAnyStringDoesNotContainTarget_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            request.TestNullable = RandomHelpers.RandomString();

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestNullable), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("should contain", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(request.TestNullable.Substring(0, 10), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(TARGET, Case.Insensitive));
        }

        [Fact]
        public void GivenCaseComparisonNotDeclared_WhenStringContainsTargetButWrongCase_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            request.TestNullable = TARGET.ToLower() + RandomHelpers.RandomString();

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestNullable), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("should contain", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(request.TestNullable.Substring(0, 10), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(TARGET, Case.Insensitive));
        }

        [Fact]
        public void GivenCaseIgnoreSpecified_WhenStringContainsTargetButWrongCase_PassTest()
        {
            // Arrange
            var request = GetTestClass();
            request.TestNonNullable = TARGET.ToLower() + RandomHelpers.RandomString();

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.HasFailures.ShouldBeFalse();
        }

        private static TestClass GetTestClass()
        {
            return new TestClass()
            {
                TestNullable = TARGET + RandomHelpers.RandomString(),
                TestNonNullable = RandomHelpers.RandomString() + TARGET
            };
        }
    }
}