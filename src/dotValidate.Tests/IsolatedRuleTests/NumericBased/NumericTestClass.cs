namespace dotValidate.Tests.IsolatedRuleTests.NumericBased
{
    public abstract class NumericTestClass
    {
        protected class TestClass
        {
            public int TestNonNullableInt { get; set; }

            public int? TestNullableInt { get; set; }

            public uint TestUint { get; set; }

            public long TestLong { get; set; }

            public ulong? TestULong { get; set; }

            public short? TestShort { get; set; }

            public byte TestByte { get; set; }

            public double TestNonNullableDouble { get; set; }

            public double? TestNullableDouble { get; set; }

            public decimal TestNonNullableDecimal { get; set; }

            public decimal? TestNullableDecimal { get; set; }
        }
    }
}
