using dotValidate.Tests.TestHelpers;
using Shouldly;
using Xunit;

namespace dotValidate.Tests.ConditionalRuleTests
{
    public class WhenNotNull : ConditionalTestClass
    {
        private const string TEXT_TARGET = "ABC";

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

        [Fact]
        public void GivenAboveRules_WhenAnyValueNull_PassTest()
        {
            // Arrange
            var request = new TestClass();
            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.HasFailures.ShouldBeFalse();
        }

        [Fact]
        public void GivenAboveRules_WhenAllValuesNotNullAndObeyRules_PassTest()
        {
            // Arrange
            var request = GetTestClass();
            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.HasFailures.ShouldBeFalse();
        }

        [Fact]
        public void GivenAboveRules_WhenBoolValueNotNullNotObeyingFollowUpRule_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            request.TestBool = false;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestBool), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("true", Case.Insensitive));
        }

        [Theory]
        [InlineData(int.MinValue)]
        [InlineData(0)]
        [InlineData(50)]
        [InlineData(100)]
        public void GivenAboveRules_WhenIntValueNotNullNotObeyingFollowUpRule_FailTestWithPropertyInMessage(int testValue)
        {
            // Arrange
            var request = GetTestClass();
            request.TestInt = testValue;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestInt), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(testValue.ToString(), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("100", Case.Insensitive));
        }

        [Theory]
        [InlineData(byte.MinValue)]
        [InlineData(0)]
        [InlineData(19)]
        [InlineData(31)]
        [InlineData(byte.MaxValue)]
        public void GivenAboveRules_WhenByteValueNotNullNotObeyingFollowUpRule_FailTestWithPropertyInMessage(byte testValue)
        {
            // Arrange
            var request = GetTestClass();
            request.TestByte = testValue;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestByte), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(testValue.ToString(), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("range", Case.Insensitive));
        }

        [Theory]
        [InlineData(10.500001)]
        [InlineData(20.8)]
        [InlineData(100)]
        [InlineData(double.MaxValue)]
        public void GivenAboveRules_WhenDoubleValueNotNullNotObeyingFollowUpRule_FailTestWithPropertyInMessage(double testValue)
        {
            // Arrange
            var request = GetTestClass();
            request.TestDouble = testValue;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestDouble), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(testValue.ToString(), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("less than or equal to", Case.Insensitive));
        }

        [Theory]
        //[InlineData(decimal.MinValue)]
        //[InlineData(-0.00001M)]
        //[InlineData(0.00001M)]
        [InlineData(100)]
        //[InlineData(decimal.MaxValue)]
        public void GivenAboveRules_WhenDecimalValueNotNullNotObeyingFollowUpRule_FailTestWithPropertyInMessage(decimal testValue)
        {
            // Arrange
            var request = GetTestClass();
            request.TestDecimal = testValue;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestDecimal), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(testValue.ToString(), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("zero", Case.Insensitive));
        }

        [Fact]
        public void GivenAboveRules_WhenStringValueNotNullNotObeyingFollowUpRule_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            request.TestString = "_" + RandomHelpers.RandomString(10);

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestString), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("start with", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(TEXT_TARGET, Case.Insensitive));
        }

        [Theory]
        [InlineData(int.MinValue)]
        [InlineData(-100)]
        [InlineData(0)]
        public void GivenAboveRules_WhenSubClassValueNotNullNotObeyingFollowUpRule_FailTestWithPropertyInMessage(int testValue)
        {
            // Arrange
            var request = GetTestClass();
            request.TestSubClass = new TestSubClass
            {
                Id = testValue
            };

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestSubClass), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestSubClass.Id), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(testValue.ToString(), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("1", Case.Insensitive));
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
