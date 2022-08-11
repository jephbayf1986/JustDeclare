namespace dotValidate.Testing.Tests
{
    internal class ARequestValidator : ValidationRules<ARequest>
    {
        public ARequestValidator()
        {
            DeclareRules(
                    x => x.Id.MustNotBeZero(),
                    x => x.Id.MustBeLessThan(10)
                );
        }
    }
}