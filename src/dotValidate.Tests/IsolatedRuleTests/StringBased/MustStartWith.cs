using dotValidate.Tests.TestHelpers;
using Shouldly;
using Xunit;

namespace dotValidate.Tests.IsolatedRuleTests.StringBased
{
    public class MustStartWith : StringTestClass
    {
        private const string TARGET = "FOOBAR";

        private class TestClassValidationRules : ValidationRules<TestClass>
        {
            public TestClassValidationRules()
            {
                DeclareRules(
                        x => x.TestNullable.MustStartWith(TARGET),
                        x => x.TestNonNullable.MustStartWith(TARGET, Enums.Case.Insensitve)
                    );
            }
        }

        [Fact]
        public void GivenAboveRules_WhenAllValuesStartWithTarget_PassTest()
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
                                              x => x.FailureSummary().ShouldContain("should start with", Shouldly.Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(TARGET, Shouldly.Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("null", Shouldly.Case.Insensitive));
        }

        [Fact]
        public void GivenAboveRules_WhenAnyStringDoesNotStartWithTarget_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            request.TestNullable = RandomHelpers.RandomString() + TARGET;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestNullable), Shouldly.Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("should start with", Shouldly.Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(request.TestNullable.Substring(0, 10), Shouldly.Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(TARGET, Shouldly.Case.Insensitive));
        }

        [Fact]
        public void GivenCaseComparisonNotDeclared_WhenStringStartsWithTargetButWrongCase_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            request.TestNullable = TARGET.ToLower() + RandomHelpers.RandomString();

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestNullable), Shouldly.Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("should start with", Shouldly.Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(request.TestNullable.Substring(0, 10), Shouldly.Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(TARGET, Shouldly.Case.Insensitive));
        }

        [Fact]
        public void GivenCaseIgnoreSpecified_WhenStringStartsWithTargetButWrongCase_PassTest()
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
                TestNonNullable = TARGET + RandomHelpers.RandomString()
            };
        }
    }
}