using dotValidate.Tests.TestHelpers;
using Shouldly;
using Xunit;

namespace dotValidate.Tests.PostCheckTests
{
    public class EndValidationIfFails : PostCheckTestClass
    {
        private const string TEXT_TARGET = "SOMETHING";

        private class TestClassValidationRules : ValidationRules<TestClass>
        {
            public TestClassValidationRules()
            {
                DeclareRules(
                        x => x.TestString.MustContain(TEXT_TARGET)
                                         .StopValidationOnFailure(),
                        x => x.TestString.MustStartWith(TEXT_TARGET)
                    );
            }
        }

        [Fact]
        public void GivenAboveRule_WhenBothRulesPass_PassTests()
        {
            // Arrange
            var request = new TestClass();
            request.TestString = TEXT_TARGET + RandomHelpers.RandomString(10);

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.HasFailures.ShouldBeFalse();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("ABC")]
        public void GivenAboveRule_WhenFirstRuleFails_DontPerform2ndTest(string stringValue)
        {
            // Arrange
            var request = new TestClass();
            request.TestString = stringValue;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.NumberOfFailures.ShouldBe(1));
        }

        [Fact]
        public void GivenAboveRule_WhenFirstPassesBut2ndFails_FailTest()
        {
            // Arrange
            var request = new TestClass();
            request.TestString = RandomHelpers.RandomString(5) + TEXT_TARGET;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.NumberOfFailures.ShouldBe(1));
        }
    }
}
