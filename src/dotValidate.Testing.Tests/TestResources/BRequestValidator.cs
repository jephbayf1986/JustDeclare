namespace dotValidate.Testing.Tests.TestResources
{
    internal class BRequestValidator : ValidationRules<BRequest>
    {
        public BRequestValidator()
        {
            DeclareRules(
                    x => x.Id.MustNotBeBlank(), 
                    x => x.Id.MustBeNoShorterThan(2)
                );
        }
    }
}