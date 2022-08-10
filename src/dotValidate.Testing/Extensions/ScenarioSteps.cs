using dotValidate.Testing.Models;
using dotValidate.Testing.TypeMatchers;
using Moq;

namespace dotValidate.Testing.Extensions
{
    public class SpecificRequestRuleStep1<TRequest>
    {
        private readonly TRequest _request;
        private readonly MockValidator _mockValidator;

        public SpecificRequestRuleStep1(TRequest request, MockValidator mockValidator)
        {
            _request = request;
            _mockValidator = mockValidator;
        }

        public SpecificRequestRuleStep2<TValidator, TRequest> WithValidator<TValidator>()
            where TValidator : ValidationRules<TRequest>, new()
        {
            return new SpecificRequestRuleStep2<TValidator, TRequest>(_request, _mockValidator);
        }
        
        public SpecificRequestRuleStep2<TRequest> WithAnyValidator()
        {
            return new SpecificRequestRuleStep2<TRequest>(_request, _mockValidator);
        }
    }

    public class AnyRequestRuleStep1<TRequest>
    {
        private readonly MockValidator _mockValidator;

        public AnyRequestRuleStep1(MockValidator mockValidator)
        {
            _mockValidator = mockValidator;
        }
        
        public AnyRequestRuleStep2<TValidator, TRequest> WithValidator<TValidator>()
            where TValidator : ValidationRules<TRequest>, new()
        {
            return new AnyRequestRuleStep2<TValidator, TRequest>(_mockValidator);
        }

        public AnyRequestRuleStep2<TRequest> WithAnyValidator()
        {
            return new AnyRequestRuleStep2<TRequest>(_mockValidator);
        }
    }

    public class SpecificRequestRuleStep2<TValidator, TRequest>
        where TValidator : ValidationRules<TRequest>, new()
    {
        private readonly TRequest _request;
        private readonly MockValidator _mockValidator;

        public SpecificRequestRuleStep2(TRequest request, MockValidator mockValidator)
        {
            _request = request;
            _mockValidator = mockValidator;
        }

        public MockValidator PassesValidation()
        {
            _mockValidator.Mock.Setup(x => x.ValidateRequest<TValidator, TRequest>(_request))
                .Returns(ValidationResultOverride.Pass(typeof(TRequest).Name));

            return _mockValidator;
        }

        public MockValidator FailsValidation(string failureMessage = null)
        {
            _mockValidator.Mock.Setup(x => x.ValidateRequest<TValidator, TRequest>(_request))
                .Returns(ValidationResultOverride.Fail(requestName: typeof(TRequest).Name, customFailureMessage: failureMessage));

            return _mockValidator;
        }
    }

    public class SpecificRequestRuleStep2<TRequest>
    {
        private readonly TRequest _request;
        private readonly MockValidator _mockValidator;

        public SpecificRequestRuleStep2(TRequest request, MockValidator mockValidator)
        {
            _request = request;
            _mockValidator = mockValidator;
        }

        public MockValidator PassesValidation()
        {
            _mockValidator.Mock.Setup(x => x.ValidateRequest<IsAnyValidationRules<TRequest>, TRequest>(_request))
                .Returns(ValidationResultOverride.Pass(typeof(TRequest).Name));

            return _mockValidator;
        }

        public MockValidator FailsValidation(string failureMessage = null)
        {
            _mockValidator.Mock.Setup(x => x.ValidateRequest<IsAnyValidationRules<TRequest>, TRequest>(_request))
                .Returns(ValidationResultOverride.Fail(requestName: typeof(TRequest).Name, customFailureMessage: failureMessage));

            return _mockValidator;
        }
    }

    public class AnyRequestRuleStep2<TValidator, TRequest>
        where TValidator : ValidationRules<TRequest>, new()
    {
        private readonly MockValidator _mockValidator;

        public AnyRequestRuleStep2(MockValidator mockValidator)
        {
            _mockValidator = mockValidator;
        }

        public MockValidator PassesValidation()
        {
            _mockValidator.Mock.Setup(x => x.ValidateRequest<TValidator, TRequest>(It.IsAny<TRequest>()))
                .Returns(ValidationResultOverride.Pass());

            return _mockValidator;
        }

        public MockValidator FailsValidation(string failureMessage = null)
        {
            _mockValidator.Mock.Setup(x => x.ValidateRequest<TValidator, TRequest>(It.IsAny<TRequest>()))
                .Returns(ValidationResultOverride.Fail(customFailureMessage: failureMessage));

            return _mockValidator;
        }
    }

    public class AnyRequestRuleStep2<TRequest>
    {
        private readonly MockValidator _mockValidator;

        public AnyRequestRuleStep2(MockValidator mockValidator)
        {
            _mockValidator = mockValidator;
        }
        
        public MockValidator PassesValidation()
        {
            _mockValidator.Mock.Setup(x => x.ValidateRequest<IsAnyValidationRules<TRequest>, TRequest>(It.IsAny<TRequest>()))
                .Returns(ValidationResultOverride.Pass());

            return _mockValidator;
        }

        public MockValidator FailsValidation(string failureMessage = null)
        {
            _mockValidator.Mock.Setup(x => x.ValidateRequest<IsAnyValidationRules<TRequest>, TRequest>(It.IsAny<TRequest>()))
                .Returns(ValidationResultOverride.Fail(customFailureMessage: failureMessage));

            return _mockValidator;
        }
    }
}