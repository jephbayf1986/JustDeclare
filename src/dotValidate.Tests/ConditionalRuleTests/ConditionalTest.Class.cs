namespace dotValidate.Tests.ConditionalRuleTests
{
    public abstract class ConditionalTestClass
    {
        protected class TestClass
        {
            public bool? TestBool { get; set; }

            public int? TestInt { get; set; }

            public byte? TestByte { get; set; }

            public double? TestDouble { get; set; }

            public decimal? TestDecimal { get; set; }

            public string? TestString { get; set; }

            public TestSubClass? TestSubClass { get; set; }
        }

        protected class TestSubClass
        {
            public int Id { get; set; }
        }
    }
}
