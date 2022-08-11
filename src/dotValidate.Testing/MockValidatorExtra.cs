using dotValidate.Testing.Extensions;
using Moq;

namespace dotValidate.Testing
{
    public class MockValidatorExtra : MockValidator
    {
        internal MockValidatorExtra(Mock<IValidator> mock)
        {
            Mock = mock;
        }

        public SpecificRequestRuleStep1<TRequest> AndGivenRequest<TRequest>(TRequest request)
            => new SpecificRequestRuleStep1<TRequest>(request, this);

        public AnyRequestRuleStep1<TRequest> AndGivenAnyRequest<TRequest>()
            => new AnyRequestRuleStep1<TRequest>(this);

        public static implicit operator Mock<IValidator>(MockValidatorExtra mockValidator) => mockValidator.Mock;
    }
}