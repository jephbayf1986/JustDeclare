using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotValidate.Tests.ConditionalRuleTests
{
    public class NotNullConditionalTests
    {
        private const string TEXT_TARGET = "ABC";

        private class TestClass
        {
            public bool? TestBool { get; set; }

            public int? TestInt { get; set; }

            public byte? TestByte { get; set; }

            public double? TestDouble { get; set; }

            public decimal? TestDecimal { get; set; }

            public string? TestString { get; set; }

            public TestSubClass? TestSubClass { get; set; }
        }

        private class TestSubClass
        {
            public int Id { get; set; }
        }

        private class TestClassValidationRules : ValidationRules<TestClass>
        {
            public TestClassValidationRules()
            {
                DeclareRules(
                        x => x.TestBool.WhenNotNull()
                                       .MustBeTrue(),
                        x => x.TestInt.WhenNotNull()
                                      .MustBeGreaterThan(100),
                        x => x.TestByte.WhenNotNull()
                                       .MustBeInRange(20, 30),
                        x => x.TestDouble.WhenNotNull()
                                         .MustBeLessThan(10),
                        x => x.TestDecimal.WhenNotNull()
                                          .MustBeZero(),
                        x => x.TestString.WhenNotNull()
                                         .MustStartWith(TEXT_TARGET),
                        x => x.TestSubClass.WhenNotNull()
                                           .MustObeyTheseRules(
                                                    s => s.Id.MustBeGreaterThan(1)
                                                )

                    );
            }
        }
    }
}
