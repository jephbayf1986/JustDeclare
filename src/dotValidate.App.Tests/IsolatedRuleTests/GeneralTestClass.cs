using System;

namespace dotValidate.Tests.IsolatedRuleTests
{
    public abstract class GeneralTestClass
    {
        protected class TestClass
        {
            public int? TestInteger { get; set; }

            public string? TestString { get; set; }

            public double? TestDouble { get; set; }

            public decimal? TestDecimal { get; set; }

            public DateTime? TestDateTime { get; set; }

            public TestClass? ChildObject { get; set; }
        }
    }
}