using Shouldly;
using Xunit;

namespace dotValidate.Tests.IsolatedRuleTests.StringBased
{
    public class MustNotMatchPattern : StringTestClass
    {
        private const string NUMBERIC_PATTERM = "^[0-9]+$";
        private const string EMAIL_PATTERN = "/^S+@S+.S+$/";

        private class TestClassValidationRules : ValidationRules<TestClass>
        {
            public TestClassValidationRules()
            {
                DeclareRules(
                        x => x.TestNullable.MustNotMatchPattern(NUMBERIC_PATTERM),
                        x => x.TestNonNullable.MustNotMatchPattern(EMAIL_PATTERN)
                    );
            }
        }

        [Fact]
        public void GivenAboveRules_WhenNoValuesMatchTargetPatterns_PassTest()
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
        public void GivenAboveRules_WhenAnyStringMatchesPattern_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            request.TestNullable = "4566";

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestNullable), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("should not match", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(request.TestNullable, Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(NUMBERIC_PATTERM, Case.Insensitive));
        }

        private static TestClass GetTestClass()
        {
            return new TestClass()
            {
                TestNullable = "ABCDEF",
                TestNonNullable = "abcdef.com"
            };
        }
    }
}