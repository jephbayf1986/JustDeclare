using Shouldly;
using Xunit;

namespace dotValidate.Tests.IsolatedRuleTests.StringBased
{
    public class MustMatchPattern : StringTestClass
    {
        private const string NUMBERIC_PATTERM = "^[0-9]+$";
        private const string EMAIL_PATTERN = "/^S+@S+.S+$/";

        private class TestClassValidationRules : ValidationRules<TestClass>
        {
            public TestClassValidationRules()
            {
                DeclareRules(
                        x => x.TestNullable.MustMatchPattern(NUMBERIC_PATTERM),
                        x => x.TestNonNullable.MustMatchPattern(EMAIL_PATTERN)
                    );
            }
        }

        [Fact]
        public void GivenAboveRules_WhenAllValuesMatchPatterns_PassTest()
        {
            // Arrange
            var request = GetTestClass();
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
                TestNullable = "012345",
                TestNonNullable = "abc@def.com"
            };
        }
    }
}