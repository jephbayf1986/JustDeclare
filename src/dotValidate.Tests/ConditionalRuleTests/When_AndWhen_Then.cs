using dotValidate.Tests.TestHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotValidate.Tests.ConditionalRuleTests
{
    public class When_AndWhen_Then : ConditionalTestClass
    {
        private const string TEXT_TARGET = "XYZ";

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
                                         .MustBeLessThanOrEqualTo(10.5),
                        x => x.TestDecimal.WhenNotNull()
                                          .MustBeZero(),
                        x => x.TestString.WhenNotNull()
                                         .MustStartWith(TEXT_TARGET),
                        x => x.TestSubClass.WhenNotNull()
                                           .MustObeyTheseRules(
                                                    s => s.Id.MustBeNoLessThan(1)
                                                )

                    );
            }
        }

        private static TestClass GetTestClass()
        {
            return new TestClass()
            {
                TestBool = true,
                TestInt = RandomHelpers.IntBetween(101, 200),
                TestByte = (byte)RandomHelpers.IntBetween(20, 30),
                TestDouble = RandomHelpers.IntBetween(1, 10),
                TestDecimal = 0,
                TestString = TEXT_TARGET + RandomHelpers.RandomString(7),
                TestSubClass = new TestSubClass
                {
                    Id = RandomHelpers.IntBetween(1, 10)
                }
            };
        }
    }
}