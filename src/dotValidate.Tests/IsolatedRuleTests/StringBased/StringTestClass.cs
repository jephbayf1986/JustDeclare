using dotValidate.Tests.TestHelpers;

namespace dotValidate.Tests.IsolatedRuleTests.StringBased
{
    public abstract class StringTestClass
    {
        protected class TestClass
        {
            public string TestNonNullable { get; set; } = RandomHelpers.RandomString();
            public string? TestNullable { get; set; }
        }
    }
}