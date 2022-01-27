namespace JustDeclare.Tests.IsolatedRuleTests.BooleanBased
{
    public abstract class BooleanTestClass
    {
        protected class TestClass
        {
            public bool? TestNullable { get; set; }

            public bool TestNonNullable { get; set; }
        }
    }
}
