using dotValidate.Tests.TestHelpers;
using Shouldly;
using Xunit;

namespace dotValidate.Tests.IsolatedRuleTests.StringBased
{
    public class MustEndWith : StringTestClass
    {
        private const string TARGET = "FOOBAR";

        private class TestClassValidationRules : ValidationRules<TestClass>
        {
            public TestClassValidationRules()
            {
                DeclareRules(
                        x => x.TestNullable.MustEndWith(TARGET),
                        x => x.TestNonNullable.MustEndWith(TARGET, Enums.Case.Insensitve)
                    );
            }
        }

        [Fact]
        public void GivenAboveRules_WhenAllValuesEndWithTarget_PassTest()
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
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestNullable), Shouldly.Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("should end with", Shouldly.Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(TARGET, Shouldly.Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("null", Shouldly.Case.Insensitive));
        }

        [Fact]
        public void GivenAboveRules_WhenAnyStringDoesNotEndWithTarget_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            request.TestNullable = TARGET + RandomHelpers.RandomString();

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestNullable), Shouldly.Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("should end with", Shouldly.Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(request.TestNullable.Substring(0, 10), Shouldly.Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(TARGET, Shouldly.Case.Insensitive));
        }

        [Fact]
        public void GivenCaseComparisonNotDeclared_WhenStringEndsWithTargetButWrongCase_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            request.TestNullable = RandomHelpers.RandomString() + TARGET.ToLower();

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestNullable), Shouldly.Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("should end with", Shouldly.Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(request.TestNullable.Substring(0, 10), Shouldly.Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(TARGET, Shouldly.Case.Insensitive));
        }

        [Fact]
        public void GivenCaseIgnoreSpecified_WhenStringEndsWithTargetButWrongCase_PassTest()
        {
            // Arrange
            var request = GetTestClass();
            request.TestNonNullable = RandomHelpers.RandomString() + TARGET.ToLower();

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
                TestNullable = RandomHelpers.RandomString() + TARGET,
                TestNonNullable = RandomHelpers.RandomString() + TARGET
            };
        }
    }
}