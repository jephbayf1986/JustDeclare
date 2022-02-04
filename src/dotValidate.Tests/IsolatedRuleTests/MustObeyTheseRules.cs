using dotValidate.Tests.TestHelpers;
using Shouldly;
using Xunit;

namespace dotValidate.Tests.IsolatedRuleTests
{
    public class MustObeyTheseRules : GeneralTestClass
    {
        private class TestClassValidationRules : ValidationRules<TestClass>
        {
            public TestClassValidationRules()
            {
                DeclareRules(
                        x => x.ChildObject.MustObeyTheseRules(
                                x => x.TestInteger.MustNotBeNull(),
                                x => x.TestString.MustNotBeNull(),
                                x => x.TestDouble.MustBeNull(),
                                x => x.TestDecimal.MustBeNull(),
                                x => x.TestDateTime.MustBeNull()
                            )
                    );
            }
        }

        [Fact]
        public void GivenAboveRules_WhenAllValuesNotNull_PassTest()
        {
            // Arrange
            var request = GetTestClass();
            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.HasFailures.ShouldBeFalse();
        }

        private static TestClass GetTestClass()
        {
            return new TestClass()
            {
                ChildObject = new TestClass()
                {
                    TestInteger = RandomHelpers.IntBetween(1, 10),
                    TestString = RandomHelpers.RandomString(),
                    TestDouble = null,
                    TestDecimal = null,
                    TestDateTime = null
                }
            };
        }
    }
}