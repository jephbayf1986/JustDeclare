namespace dotValidate.Testing.Tests
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

            if (result.HasFailures)
                throw new Exception(result.FailureSummary());
        }
    }
}
