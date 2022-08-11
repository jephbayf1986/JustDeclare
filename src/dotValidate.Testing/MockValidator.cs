using dotValidate.Models;
using dotValidate.Testing.Extensions;
using dotValidate.Testing.Models;
using Moq;

namespace dotValidate.Testing
{
    public class MockValidator
    {
        internal Mock<IValidator> Mock = new Mock<IValidator>();

        public static SpecificRequestRuleStep1<TRequest> GivenRequest<TRequest>(TRequest request)
            => new SpecificRequestRuleStep1<TRequest>(request, new MockValidator());

        public static AnyRequestRuleStep1<TRequest> GivenAnyRequest<TRequest>()
            => new AnyRequestRuleStep1<TRequest>(new MockValidator());

        public static MockValidator AlwaysPasses()
        {
            var mockValidator = new MockValidator();

            mockValidator.Mock.SetReturnsDefault<ValidationResult>(ValidationResultOverride.Pass());

            return mockValidator;
        }

        public static MockValidator AlwaysFails(string failureMessage = null)
        {
            var mockValidator = new MockValidator();

            mockValidator.Mock.SetReturnsDefault<ValidationResult>(ValidationResultOverride.Fail(customFailureMessage: failureMessage));

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