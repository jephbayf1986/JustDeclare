using dotValidate.Testing.Extensions;
using dotValidate.Testing.Models;
using dotValidate.Testing.TypeMatchers;
using Moq;

namespace dotValidate.Testing
{
    public sealed class MockValidator
    {
        internal Mock<IValidator> Mock = new Mock<IValidator>();

        public static SpecificRequestRuleStep1<TRequest> GivenRequest<TRequest>(TRequest request)
            => new SpecificRequestRuleStep1<TRequest>(request, new MockValidator());

        public static AnyRequestRuleStep1<TRequest> GivenAnyRequest<TRequest>()
            => new AnyRequestRuleStep1<TRequest>(new MockValidator());

        public SpecificRequestRuleStep1<TRequest> AndGivenRequest<TRequest>(TRequest request)
            => new SpecificRequestRuleStep1<TRequest>(request, this);
        
        public AnyRequestRuleStep1<TRequest> AndGivenAnyRequest<TRequest>()
            => new AnyRequestRuleStep1<TRequest>(this);

        public static MockValidator AlwaysPasses()
        {
            var mockValidator = new MockValidator();

            mockValidator.Mock.Setup(x => x.ValidateRequest<IsAnyValidationRules<It.IsAnyType>, It.IsAnyType>(It.IsAny<It.IsAnyType>()))
                              .Returns(ValidationResultOverride.Pass());

            return mockValidator;
        }

        public static MockValidator AlwaysFails(string failureMessage = null)
        {
            var mockValidator = new MockValidator();

            mockValidator.Mock.Setup(x => x.ValidateRequest<IsAnyValidationRules<It.IsAnyType>, It.IsAnyType>(It.IsAny<It.IsAnyType>()))
                              .Returns(ValidationResultOverride.Fail(customFailureMessage: failureMessage));

            return mockValidator;
        }

        public static implicit operator Mock<IValidator>(MockValidator mockValidator) => mockValidator.Mock;

        public IValidator Object 
        {
            get
            {
                return Mock.Object;
            } 
        }
    }
}