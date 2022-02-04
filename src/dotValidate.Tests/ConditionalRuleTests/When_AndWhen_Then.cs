using dotValidate.Tests.TestHelpers;
using Shouldly;
using Xunit;

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
                        x => x.When(r => (r.TestString ?? string.Empty).Contains(TEXT_TARGET))
                              .Then(r => r.TestBool.MustBeFalse()),
                        x => x.When(r => r.TestByte != null)
                              .AndWhen(r => r.TestByte > 10)
                              .Then(r => r.TestInt.MustNotBeInRange(20, 30)),
                        x => x.When(r => r.TestDouble != null)
                              .AndWhen(r => r.TestDouble < 0)
                              .Then(r => r.TestSubClass.MustObeyTheseRules(
                                                                            s => s.Id.MustBeGreaterThanOrEqualTo(1)
                                                                        ))

                    );
            }
        }

        [Fact]
        public void GivenPriorConditionsMet_WhenRulesObeyed_PassTest()
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
        public void GivenPriorConditionsNotMet_WhenRulesObeyed_PassTest()
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
        public void GivenStringContainsConditionIsMet_WhenBoolValueTrue_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            request.TestBool = true;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestBool), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("false", Case.Insensitive));
        }

        [Theory]
        [InlineData(11, 20)]
        [InlineData(111, 25)]
        [InlineData(111, 30)]
        [InlineData(byte.MaxValue, 30)]
        public void GivenBothByteConditionsAreMet_WhenIntInRangeToAvoid_FailTestWithPropertyInMessage(byte byteVal, int intValue)
        {
            // Arrange
            var request = GetTestClass();
            request.TestByte = byteVal;
            request.TestInt = intValue;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestInt), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("should not fall within", Case.Insensitive));
        }

        [Theory]
        [InlineData(-1, -20)]
        [InlineData(-10.5, -50)]
        [InlineData(-57.645, -150)]
        [InlineData(double.MinValue, -200)]
        public void GivenBothDoubleConditionsAreMet_WhenSubClassIdLessThan1_FailTestWithPropertyInMessage(double doubleVal, int idValue)
        {
            // Arrange
            var request = GetTestClass();
            request.TestDouble = doubleVal;
            request.TestSubClass = new TestSubClass
            {
                Id = idValue,
            };

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestSubClass), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestSubClass.Id), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("should be greater than or equal", Case.Insensitive));
        }

        private static TestClass GetTestClass()
        {
            return new TestClass()
            {
                TestBool = false,
                TestInt = RandomHelpers.IntBetween(0, 19),
                TestByte = (byte)RandomHelpers.IntBetween(11, 100),
                TestDouble = RandomHelpers.IntBetween(-100, -1),
                TestString = TEXT_TARGET + RandomHelpers.RandomString(7),
                TestSubClass = new TestSubClass
                {
                    Id = RandomHelpers.IntBetween(1, 10)
                }
            };
        }
    }
}