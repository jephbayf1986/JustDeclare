using Shouldly;
using Xunit;

namespace dotValidate.Testing.Tests
{
    public class TestingTests
    {
        [Fact]
        public void WhenAlwaysPasses_ShouldNotThrow()
        {
            var customMessage = new Guid().ToString();

            var request = new ARequest();

            var validator = MockValidator.AlwaysPasses();

            var service = new AService(validator.Object);

            Should.NotThrow(() => service.AMethod(request));
        }

        [Fact]
        public void WhenAlwaysFails_ShouldThrow()
        {
            var request = new ARequest();

            var validator = MockValidator.AlwaysFails();

            var service = new AService(validator.Object);

            Should.Throw<Exception>(() => service.AMethod(request));
        }

        [Fact]
        public void WhenAlwaysFailsWithCustomMessage_ShouldThrowWithMessage() 
        {
            var customMessage = new Guid().ToString();

            var request = new ARequest();

            var validator = MockValidator.AlwaysFails(customMessage);

            var service = new AService(validator.Object);

            Should.Throw<Exception>(() => service.AMethod(request), customMessage: customMessage);
        }

        [Fact]
        public void GivenRequestTypeAnyValidator_ShouldNotThrow()
        {
            var customMessage = new Guid().ToString();

            var request = new ARequest();

            var validator = MockValidator.GivenAnyRequest<ARequest>()
                                         .WithAnyValidator()
                                         .PassesValidation();

            var service = new AService(validator.Object);

            Should.NotThrow(() => service.AMethod(request));
        }
    }
}