using dotValidate.Testing.Tests.TestResources;
using Shouldly;
using Xunit;

namespace dotValidate.Testing.Tests
{
    public class MockValidatorTests
    {
        [Fact]
        public void WhenAlwaysPasses_ShouldNotThrow()
        {
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

            Should.Throw<ArgumentException>(() => service.AMethod(request));
        }

        [Fact]
        public void WhenAlwaysFailsWithCustomMessage_ShouldThrowWithMessage() 
        {
            var customMessage = Guid.NewGuid().ToString();

            var request = new ARequest();

            var validator = MockValidator.AlwaysFails(customMessage);

            var service = new AService(validator.Object);

            Should.Throw<ArgumentException>(() => service.AMethod(request), customMessage: customMessage);
        }

        [Fact]
        public void GivenRequestTypeAnyValidator_WhenPassesValidation_ShouldNotThrow()
        {
            var request = new ARequest();

            var validator = MockValidator.GivenAnyRequest<ARequest>()
                                         .WithAnyValidator()
                                         .PassesValidation();

            var service = new AService(validator.Object);

            Should.NotThrow(() => service.AMethod(request));
        }

        [Fact]
        public void GivenRequestTypeSpecificValidator_WhenPassesValidation_ShouldNotThrow()
        {
            var request = new ARequest();

            var validator = MockValidator.GivenAnyRequest<ARequest>()
                                         .WithValidator<ARequestValidator>()
                                         .PassesValidation();

            var service = new AService(validator.Object);

            Should.NotThrow(() => service.AMethod(request));
        }

        [Fact]
        public void GivenSpecificRequestAnyValidator_WhenPassesValidation_ShouldNotThrow()
        {
            var request = new ARequest();

            var validator = MockValidator.GivenRequest(request)
                                         .WithAnyValidator()
                                         .PassesValidation();

            var service = new AService(validator.Object);

            Should.NotThrow(() => service.AMethod(request));
        }
        
        [Fact]
        public void GivenSpecificRequestSpecificValidator_WhenPassesValidation_ShouldNotThrow()
        {
            var request = new ARequest();

            var validator = MockValidator.GivenRequest(request)
                                         .WithValidator<ARequestValidator>()
                                         .PassesValidation();

            var service = new AService(validator.Object);

            Should.NotThrow(() => service.AMethod(request));
        }

        [Fact]
        public void GivenRequestTypeAnyValidator_WhenFailsValidation_ShouldThrow()
        {
            var request = new ARequest();

            var validator = MockValidator.GivenAnyRequest<ARequest>()
                                         .WithAnyValidator()
                                         .FailsValidation();

            var service = new AService(validator.Object);

            Should.Throw<ArgumentException>(() => service.AMethod(request));
        }

        [Fact]
        public void GivenRequestTypeSpecificValidator_WhenFailsValidation_ShouldThrow()
        {
            var request = new ARequest();

            var validator = MockValidator.GivenAnyRequest<ARequest>()
                                         .WithValidator<ARequestValidator>()
                                         .FailsValidation();

            var service = new AService(validator.Object);

            Should.Throw<ArgumentException>(() => service.AMethod(request));
        }

        [Fact]
        public void GivenSpecificRequestAnyValidator_WhenFailsValidation_ShouldThrow()
        {
            var request = new ARequest();

            var validator = MockValidator.GivenRequest(request)
                                         .WithAnyValidator()
                                         .FailsValidation();

            var service = new AService(validator.Object);

            Should.Throw<ArgumentException>(() => service.AMethod(request));
        }

        [Fact]
        public void GivenSpecificRequestSpecificValidator_WhenFailsValidation_ShouldThrow()
        {
            var request = new ARequest();

            var validator = MockValidator.GivenRequest(request)
                                         .WithValidator<ARequestValidator>()
                                         .FailsValidation();

            var service = new AService(validator.Object);

            Should.Throw<ArgumentException>(() => service.AMethod(request));
        }

        [Fact]
        public void GivenRequestTypeAnyValidator_WhenFailsValidationWithCustomMessage_ShouldThrowWithMessage()
        {
            var customMessage = Guid.NewGuid().ToString();

            var request = new ARequest();

            var validator = MockValidator.GivenAnyRequest<ARequest>()
                                         .WithAnyValidator()
                                         .FailsValidation();

            var service = new AService(validator.Object);

            Should.Throw<ArgumentException>(() => service.AMethod(request), customMessage: customMessage);
        }

        [Fact]
        public void GivenRequestTypeSpecificValidator_WhenFailsValidationWithCustomMessage_ShouldThrowWithMessage()
        {
            var customMessage = Guid.NewGuid().ToString();

            var request = new ARequest();

            var validator = MockValidator.GivenAnyRequest<ARequest>()
                                         .WithValidator<ARequestValidator>()
                                         .FailsValidation();

            var service = new AService(validator.Object);

            Should.Throw<ArgumentException>(() => service.AMethod(request), customMessage: customMessage);
        }

        [Fact]
        public void GivenSpecificRequestAnyValidator_WhenFailsValidationWithCustomMessage_ShouldThrowWithMessage()
        {
            var customMessage = Guid.NewGuid().ToString();

            var request = new ARequest();

            var validator = MockValidator.GivenRequest(request)
                                         .WithAnyValidator()
                                         .FailsValidation();

            var service = new AService(validator.Object);

            Should.Throw<ArgumentException>(() => service.AMethod(request), customMessage: customMessage);
        }

        [Fact]
        public void GivenSpecificRequestSpecificValidator_WhenFailsValidationWithCustomMessage_ShouldThrowWithMessage()
        {
            var customMessage = Guid.NewGuid().ToString();

            var request = new ARequest();

            var validator = MockValidator.GivenRequest(request)
                                         .WithValidator<ARequestValidator>()
                                         .FailsValidation();

            var service = new AService(validator.Object);

            Should.Throw<ArgumentException>(() => service.AMethod(request), customMessage: customMessage);
        }

        [Fact]
        public void GivenRequestTypeAnyValidator_WhenMultipleFailsValidation_ShouldNotThrow()
        {
            var numberOfFailures = 8;

            var request = new ARequest();

            var validator = MockValidator.GivenAnyRequest<ARequest>()
                                         .WithAnyValidator()
                                         .MultipleFailsValidation(numberOfFailures);

            var service = new AService(validator.Object);

            Should.Throw<ArgumentException>(() => service.AMethod(request));
        }

        [Fact]
        public void GivenRequestTypeSpecificValidator_WhenMultipleFailsValidation_ShouldThrowWithEachErrorInMessage()
        {
            var numberOfFailures = 10;

            var request = new ARequest();

            var validator = MockValidator.GivenAnyRequest<ARequest>()
                                         .WithValidator<ARequestValidator>()
                                         .MultipleFailsValidation(numberOfFailures);

            var service = new AService(validator.Object);

            Should.Throw<ArgumentException>(() => service.AMethod(request))
                .Message.ShouldContain($"{numberOfFailures} validation errors");
        }

        [Fact]
        public void GivenSpecificRequestAnyValidator_WhenMultipleFailsValidation_ShouldThrowWithEachErrorInMessage()
        {
            var numberOfFailures = 12;

            var request = new ARequest();

            var validator = MockValidator.GivenRequest(request)
                                         .WithAnyValidator()
                                         .MultipleFailsValidation(numberOfFailures);

            var service = new AService(validator.Object);

            Should.Throw<ArgumentException>(() => service.AMethod(request))
                .Message.ShouldContain($"{numberOfFailures} validation errors");
        }

        [Fact]
        public void GivenSpecificRequestSpecificValidator_WhenMultipleFailsValidation_ShouldThrowWithEachErrorInMessage()
        {
            var numberOfFailures = 14;

            var request = new ARequest();

            var validator = MockValidator.GivenRequest(request)
                                         .WithValidator<ARequestValidator>()
                                         .MultipleFailsValidation(numberOfFailures);

            var service = new AService(validator.Object);

            Should.Throw<ArgumentException>(() => service.AMethod(request))
                .Message.ShouldContain($"{numberOfFailures} validation errors");
        }

        [Fact]
        public void GivenMultipleRules_WhenFirstRuleTriggered_ShouldNotThrow()
        {
            var request = new ARequest();

            var validator = MockValidator.GivenRequest(request)
                                         .WithValidator<ARequestValidator>()
                                         .PassesValidation()
                                             .AndGivenAnyRequest<BRequest>()
                                             .WithValidator<BRequestValidator>()
                                             .FailsValidation();

            var service = new AService(validator.Object);

            Should.NotThrow(() => service.AMethod(request));
        }

        [Fact]
        public void GivenMultipleRules_WhenLaterRuleTriggered_ShouldNotThrow()
        {
            var request = new ARequest();

            var validator = MockValidator.GivenAnyRequest<BRequest>()
                                         .WithValidator<BRequestValidator>()
                                         .FailsValidation()
                                             .AndGivenRequest(request)
                                             .WithValidator<ARequestValidator>()
                                             .PassesValidation();

            var service = new AService(validator.Object);

            Should.NotThrow(() => service.AMethod(request));
        }

        [Fact]
        public void GivenSpecificRequest_WhenAnotherRequestIsPassed_ShouldThrowNullException()
        {
            var request = new ARequest();

            var validator = MockValidator.GivenAnyRequest<BRequest>()
                                         .WithValidator<BRequestValidator>()
                                         .FailsValidation();

            var service = new AService(validator.Object);

            Should.Throw<NullReferenceException>(() => service.AMethod(request));
        }
    }
}