using Shouldly;
using System;
using Xunit;

namespace JustDeclare.Tests.IsolatedRuleTests
{
    public class MustBeNull
    {
        internal class TestClass
        {
            public int? TestInteger { get; set; }

            public string? TestString { get; set; }

            public double? TestDouble { get; set; }

            public decimal? TestDecimal { get; set; }

            public DateTime? TestDateTime { get; set; }
        }

        internal class TestClassValidationRules : ValidationRules<TestClass>
        {
            public TestClassValidationRules()
            {
                DeclareRules(
                        x => x.TestInteger.MustBeNull(),
                        x => x.TestString.MustBeNull(),
                        X => X.TestDouble.MustBeNull(),
                        X => X.TestDecimal.MustBeNull(),
                        x => x.TestDateTime.MustBeNull()
                    );
            }
        }

        [Fact]
        public void GivenAboveRules_WhenAllValuesNull_PassTest()
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
            return new TestClass();
        }
    }
}
