namespace JustDeclare.Tests.IsolatedRuleTests.NumericBased
{
    public abstract class StringTestClass
    {
        protected class TestClass
        {
            public string TestNonNullable { get; set; }
            public string? TestNullable { get; set; }
        }
    }
}