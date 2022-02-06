using dotValidate.Tests.TestHelpers;
using Shouldly;
using Xunit;

namespace dotValidate.Tests.IsolatedRuleTests.StringBased
{
    public class MustNotStartWith : StringTestClass
    {
        private const string TARGET = "FOOBAR";

        private class TestClassValidationRules : ValidationRules<TestClass>
        {
            public TestClassValidationRules()
            {
                DeclareRules(
                        x => x.TestNullable.MustNotStartWith(TARGET),
                        x => x.TestNonNullable.MustNotStartWith(TARGET, Enums.Case.Insensitve)
                    );
            }
        }

        [Fact]
        public void GivenAboveRules_WhenNoValuesStartWithTarget_PassTest()
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
        public void GivenAboveRules_WhenNullableStringIsNull_PassTest()
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
        public void GivenAboveRules_WhenAnyStringStartsWithTarget_FailTestWithPropertyInMessage()
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
                                              x => x.FailureSummary().ShouldContain("should not start with", Shouldly.Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(request.TestNullable.Substring(0, 10), Shouldly.Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(TARGET, Shouldly.Case.Insensitive));
        }

        [Fact]
        public void GivenCaseComparisonNotDeclared_WhenStringStartsWithTargetButWrongCase_PassTest()
        {
            // Arrange
            var request = GetTestClass();
            request.TestNullable = TARGET.ToLower() + RandomHelpers.RandomString();

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.HasFailures.ShouldBeFalse();
        }

        [Fact]
        public void GivenCaseIgnoreSpecified_WhenStringStartsWithTargetButWrongCase_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            request.TestNonNullable = TARGET.ToLower() + RandomHelpers.RandomString();

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestNonNullable), Shouldly.Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("should not start with", Shouldly.Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(request.TestNonNullable.Substring(0, 10), Shouldly.Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(TARGET, Shouldly.Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("case-insensitive", Shouldly.Case.Insensitive));
        }
        
        private static TestClass GetTestClass()
        {
            return new TestClass()
            {
                TestNullable = RandomHelpers.RandomString(),
                TestNonNullable = RandomHelpers.RandomString() + TARGET
            };
        }
    }
}