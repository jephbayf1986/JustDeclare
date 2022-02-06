using dotValidate.Tests.TestHelpers;
using Shouldly;
using Xunit;

namespace dotValidate.Tests.IsolatedRuleTests.StringBased
{
    public class MustBe : StringTestClass
    {
        private const string TARGET = "FOOBAR";

        private class TestClassValidationRules : ValidationRules<TestClass>
        {
            public TestClassValidationRules()
            {
                DeclareRules(
                        x => x.TestNullable.MustBe(TARGET),
                        x => x.TestNonNullable.MustBe(TARGET, Enums.Case.Insensitve)
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
                                              x => x.FailureSummary().ShouldContain(TARGET, Shouldly.Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("null", Shouldly.Case.Insensitive));
        }

        [Fact]
        public void GivenAboveRules_WhenAnyStringIsNotTarget_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            request.TestNullable = RandomHelpers.RandomString();

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestNullable), Shouldly.Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(request.TestNullable.Substring(0, 10), Shouldly.Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(TARGET, Shouldly.Case.Insensitive));
        }

        [Fact]
        public void GivenCaseComparisonNotDeclared_WhenStringIsTargetButWrongCase_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            request.TestNullable = TARGET.ToLower();

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestNullable), Shouldly.Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(request.TestNullable, Shouldly.Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(TARGET, Shouldly.Case.Insensitive));
        }

        [Fact]
        public void GivenCaseIgnoreSpecified_WhenStringIsTargetButWrongCase_PassTest()
        {
            // Arrange
            var request = GetTestClass();
            request.TestNonNullable = TARGET.ToLower();

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
                TestNullable = TARGET,
                TestNonNullable = TARGET
            };
        }
    }
}