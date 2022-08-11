namespace dotValidate.Testing.Tests.TestResources
{
    internal class AService
    {
        private readonly IValidator _validator;

        public AService(IValidator validator)
        {
            _validator = validator;
        }

        public void AMethod(ARequest request)
        {
            var result = _validator.Validate(request)
                                   .Using<ARequestValidator>();

            if (result == null)
                throw new NullReferenceException("No Validator Result Returned");

            if (result.HasFailures)
                throw new ArgumentException(result.FailureSummary());
        }
    }
}
