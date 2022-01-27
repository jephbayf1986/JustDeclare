using JustDeclare.Tests.TestHelpers;
using Shouldly;
using Xunit;

namespace JustDeclare.Tests.IsolatedRuleTests.NumericBased
{
    public class MustBeLessThanOrEqualTo : NumericTestClass
    {
        private const int MAXIMUM = 10;

        private class TestClassValidationRules : ValidationRules<TestClass>
        {
            public TestClassValidationRules()
            {
                DeclareRules(
                        x => x.TestInteger.MustBeLessThanOrEqualTo(MAXIMUM),
                        x => x.TestUint.MustBeLessThanOrEqualTo((uint)MAXIMUM),
                        x => x.TestLong.MustBeLessThanOrEqualTo(MAXIMUM),
                        x => x.TestShort.MustBeLessThanOrEqualTo((short)MAXIMUM),
                        x => x.TestByte.MustBeLessThanOrEqualTo((byte)MAXIMUM),
                        X => X.TestDouble.MustBeLessThanOrEqualTo(MAXIMUM),
                        X => X.TestDecimal.MustBeLessThanOrEqualTo(MAXIMUM)
                    );
            }
        }

        [Fact]
        public void GivenAboveRules_WhenAllValuesAtTarget_PassTest()
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
        public void GivenAboveRules_WhenAllValuesAreNull_PassTest()
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
        public void GivenAboveRules_WhenIntValueGreaterThanMaximum_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            var actualValue = RandomHelpers.IntBetween(MAXIMUM + 1, int.MaxValue);
            request.TestInteger = actualValue;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestInteger), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("less than or equal to", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(actualValue.ToString()));
        }

        [Fact]
        public void GivenAboveRules_WhenUintValueGreaterThanMaximum_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            var actualValue = (uint)RandomHelpers.IntBetween(MAXIMUM + 1, int.MaxValue);
            request.TestUint = actualValue;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestUint), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("less than or equal to", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(actualValue.ToString()));
        }

        [Fact]
        public void GivenAboveRules_WhenLongValueGreaterThanMaximum_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            var actualValue = RandomHelpers.IntBetween(MAXIMUM + 1, int.MaxValue);
            request.TestLong = actualValue;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestLong), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("less than or equal to", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(actualValue.ToString()));
        }

        [Fact]
        public void GivenAboveRules_WhenShortValueGreaterThanMaximum_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            short actualValue = (short)RandomHelpers.IntBetween(MAXIMUM + 1, short.MaxValue);
            request.TestShort = actualValue;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestShort), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("less than or equal to", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(actualValue.ToString()));
        }

        [Fact]
        public void GivenAboveRules_WhenByteValueGreaterThanMaximum_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            byte actualValue = (byte)RandomHelpers.IntBetween(MAXIMUM + 1, byte.MaxValue);
            request.TestByte = actualValue;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestByte), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("less than or equal to", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(actualValue.ToString()));
        }

        [Fact]
        public void GivenAboveRules_WhenDoubleValueGreaterThanMaximum_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            var actualValue = RandomHelpers.IntBetween(MAXIMUM + 1, int.MaxValue);
            request.TestDouble = actualValue;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestDouble), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("less than or equal to", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(actualValue.ToString()));
        }

        [Fact]
        public void GivenAboveRules_WhenDecimalValueGreaterThanMaximum_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            var actualValue = RandomHelpers.IntBetween(MAXIMUM + 1, int.MaxValue);
            request.TestDecimal = actualValue;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestDecimal), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("less than or equal to", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(actualValue.ToString()));
        }

        private static TestClass GetTestClass()
        {
            return new TestClass()
            {
                TestInteger = RandomHelpers.IntBetween(int.MinValue, MAXIMUM),
                TestUint = (uint)RandomHelpers.IntBetween(0, MAXIMUM),
                TestLong = RandomHelpers.IntBetween(int.MinValue, MAXIMUM),
                TestShort = (short)RandomHelpers.IntBetween(short.MinValue, MAXIMUM),
                TestByte = (byte)RandomHelpers.IntBetween(byte.MinValue, MAXIMUM),
                TestDouble = RandomHelpers.IntBetween(int.MinValue, MAXIMUM),
                TestDecimal = RandomHelpers.IntBetween(int.MinValue, MAXIMUM)
            };
        }
    }
}
