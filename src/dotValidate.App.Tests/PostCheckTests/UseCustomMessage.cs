using Shouldly;
using Xunit;

namespace dotValidate.Tests.PostCheckTests
{
    public class UseCustomMessage : PostCheckTestClass
    {
        private const string Message = "Don't be null";

        private class TestClassValidationRules : ValidationRules<TestClass>
        {
            public TestClassValidationRules()
            {
                DeclareRules(
                        x => x.TestString.MustNotBeNull()
                                         .UseCustomMessage(Message)
                    );
            }
        }

        [Fact]
        public void GivenAboveRule_WhenRuleFailsWithCustomMessage_FailWithCustomMessageInResult()
        {
            // Arrange
            var request = new TestClass();
            request.TestString = null;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(Message));
        }
    }
}