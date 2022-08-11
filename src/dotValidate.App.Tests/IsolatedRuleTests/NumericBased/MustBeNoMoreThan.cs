using dotValidate.Tests.TestHelpers;
using Shouldly;
using Xunit;

namespace dotValidate.Tests.IsolatedRuleTests.NumericBased
{
    public class MustBeNoMoreThan : NumericTestClass
    {
        private const int MAXIMUM = 10;
        private const double MAXIMUM_DOUBLE = 9.9;

        private class TestClassValidationRules : ValidationRules<TestClass>
        {
            public TestClassValidationRules()
            {
                DeclareRules(
                        x => x.TestNonNullableInt.MustBeNoMoreThan(MAXIMUM),
                        x => x.TestNullableInt.MustBeNoMoreThan(MAXIMUM_DOUBLE),
                        x => x.TestUint.MustBeNoMoreThan((uint)MAXIMUM),
                        x => x.TestLong.MustBeNoMoreThan(MAXIMUM),
                        x => x.TestShort.MustBeNoMoreThan((short)MAXIMUM),
                        x => x.TestByte.MustBeNoMoreThan((byte)MAXIMUM),
                        x => x.TestNonNullableDouble.MustBeNoMoreThan(MAXIMUM_DOUBLE),
                        X => X.TestNullableDouble.MustBeNoMoreThan(MAXIMUM),
                        x => x.TestNonNullableDecimal.MustBeNoMoreThan(MAXIMUM_DOUBLE),
                        X => X.TestNullableDecimal.MustBeNoMoreThan(MAXIMUM)
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
            request.TestNonNullableInt = actualValue;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestNonNullableInt), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("less than or equal to", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(actualValue.ToString()));
        }

        [Fact]
        public void GivenAboveRules_WhenIntValueGreaterThanDecimalMaximum_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            var actualValue = RandomHelpers.IntBetween((int)MAXIMUM_DOUBLE + 1, int.MaxValue);
            request.TestNullableInt = actualValue;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestNullableInt), Case.Insensitive),
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
        public void GivenAboveRules_WhenDoubleValueGreaterThanDoubleMaximum_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            var actualValue = MAXIMUM_DOUBLE + 0.1;
            request.TestNonNullableDouble = actualValue;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestNonNullableDouble), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("less than or equal to", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(actualValue.ToString()));
        }

        [Fact]
        public void GivenAboveRules_WhenDoubleValueGreaterThanMaximum_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            var actualValue = RandomHelpers.IntBetween(MAXIMUM + 1, int.MaxValue);
            request.TestNullableDouble = actualValue;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestNullableDouble), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("less than or equal to", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(actualValue.ToString()));
        }

        [Fact]
        public void GivenAboveRules_WhenDecimalValueGreaterThanDoubleMaximum_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            var actualValue = MAXIMUM_DOUBLE + 0.1;
            request.TestNonNullableDecimal = (decimal)actualValue;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestNonNullableDecimal), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("less than or equal to", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(actualValue.ToString()));
        }

        [Fact]
        public void GivenAboveRules_WhenDecimalValueGreaterThanMaximum_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            var actualValue = RandomHelpers.IntBetween(MAXIMUM + 1, int.MaxValue);
            request.TestNullableDecimal = actualValue;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestNullableDecimal), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("less than or equal to", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(actualValue.ToString()));
        }

        private static TestClass GetTestClass()
        {
            return new TestClass()
            {
                TestNonNullableInt = RandomHelpers.IntBetween(int.MinValue, MAXIMUM),
                TestNullableInt = RandomHelpers.IntBetween(int.MinValue, (int)MAXIMUM_DOUBLE - 1),
                TestUint = (uint)RandomHelpers.IntBetween(0, MAXIMUM),
                TestLong = RandomHelpers.IntBetween(int.MinValue, MAXIMUM),
                TestShort = (short)RandomHelpers.IntBetween(short.MinValue, MAXIMUM),
                TestByte = (byte)RandomHelpers.IntBetween(byte.MinValue, MAXIMUM),
                TestNonNullableDouble = RandomHelpers.IntBetween(int.MinValue, (int)MAXIMUM_DOUBLE - 1),
                TestNullableDouble = RandomHelpers.IntBetween(int.MinValue, MAXIMUM),
                TestNonNullableDecimal = RandomHelpers.IntBetween(int.MinValue, (int)MAXIMUM_DOUBLE - 1),
                TestNullableDecimal = RandomHelpers.IntBetween(int.MinValue, MAXIMUM)
            };
        }
    }
}
