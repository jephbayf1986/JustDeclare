using dotValidate.Tests.TestHelpers;
using Shouldly;
using Xunit;

namespace dotValidate.Tests.IsolatedRuleTests.StringBased
{
    public class MustBeNoLongerThan : StringTestClass
    {
        private const int ShortMaximum = 8;
        private const int LongMaximum = 100;

        private class TestClassValidationRules : ValidationRules<TestClass>
        {
            public TestClassValidationRules()
            {
                DeclareRules(
                        x => x.TestNullable.MustBeNoLongerThan(ShortMaximum),
                        x => x.TestNonNullable.MustBeNoLongerThan(LongMaximum)
                    );
            }
        }

        [Fact]
        public void GivenAboveRules_WhenAllValuesShorterThanMaximum_PassTest()
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
        public void GivenAboveRules_WhenAnyValuesNull_PassTest()
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

        private static TestClass GetTestClass()
        {
            return new TestClass()
            {
                TestNullable = RandomHelpers.RandomString(ShortMaximum - 1),
                TestNonNullable = RandomHelpers.RandomString(LongMaximum - 1)
            };
        }
    }
}