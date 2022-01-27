namespace dotValidate.Tests.IsolatedRuleTests.NumericBased
{
    public abstract class NumericTestClass
    {
        protected class TestClass
        {
            public int? TestInteger { get; set; }

            public uint? TestUint { get; set; }

            public long? TestLong { get; set; }

            public short? TestShort { get; set; }

            public byte? TestByte { get; set; }

            public double? TestDouble { get; set; }

            public decimal? TestDecimal { get; set; }
        }
    }
}
