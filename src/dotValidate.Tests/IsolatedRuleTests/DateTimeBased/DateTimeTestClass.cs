using System;

namespace dotValidate.Tests.IsolatedRuleTests.DateTimeBased
{
    public abstract class DateTimeTestClass
    {
        protected class TestClass
        {
            public DateTime TestNonNullable { get; set; }

            public DateTime? TestNullable { get; set; }
        }
    }
}