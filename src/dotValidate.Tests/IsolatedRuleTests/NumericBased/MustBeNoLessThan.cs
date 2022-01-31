using dotValidate.Tests.TestHelpers;
using Shouldly;
using Xunit;

namespace dotValidate.Tests.IsolatedRuleTests.NumericBased
{
    public class MustBeNoLessThan : NumericTestClass
    {
        private const int MINIMUM = 10;
        private const decimal MINIMUM_DECIMAL = 10.1M;

        private class TestClassValidationRules : ValidationRules<TestClass>
        {
            public TestClassValidationRules()
            {
                DeclareRules(
                        x => x.TestNonNullableInt.MustBeNoLessThan(MINIMUM),
                        x => x.TestNullableInt.MustBeNoLessThan(MINIMUM_DECIMAL),
                        x => x.TestUint.MustBeNoLessThan(MINIMUM),
                        x => x.TestLong.MustBeNoLessThan(MINIMUM),
                        x => x.TestShort.MustBeNoLessThan(MINIMUM),
                        x => x.TestByte.MustBeNoLessThan(MINIMUM),
                        x => x.TestNonNullableDouble.MustBeNoLessThan(MINIMUM_DECIMAL),
                        X => X.TestNullableDouble.MustBeNoLessThan(MINIMUM),
                        x => x.TestNonNullableDecimal.MustBeNoLessThan(MINIMUM_DECIMAL),
                        X => X.TestNullableDecimal.MustBeNoLessThan(MINIMUM)
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
        public void GivenAboveRules_WhenIntValueLessThanMinimum_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            var actualValue = RandomHelpers.IntBetween(int.MinValue, MINIMUM - 1);
            request.TestNonNullableInt = actualValue;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestNonNullableInt), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("greater than or equal to", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(actualValue.ToString()));
        }

        [Fact]
        public void GivenAboveRules_WhenIntValueNull_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            request.TestNullableInt = null;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestNullableInt), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("greater than or equal to", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("null", Case.Insensitive));
        }

        [Fact]
        public void GivenAboveRules_WhenIntValueLessThanDecimalMinimum_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            var actualValue = (int)MINIMUM_DECIMAL - 1;
            request.TestNullableInt = actualValue;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestNullableInt), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("greater than or equal to", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(actualValue.ToString()));
        }

        [Fact]
        public void GivenAboveRules_WhenUintValueLessThanMinimum_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            var actualValue = (uint)RandomHelpers.IntBetween(0, MINIMUM - 1);
            request.TestUint = actualValue;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestUint), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("greater than or equal to", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(actualValue.ToString()));
        }

        [Fact]
        public void GivenAboveRules_WhenLongValueLessThanMinimum_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            var actualValue = RandomHelpers.IntBetween(int.MinValue, MINIMUM - 1);
            request.TestLong = actualValue;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestLong), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("greater than or equal to", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(actualValue.ToString()));
        }

        [Fact]
        public void GivenAboveRules_WhenShortValueNull_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            request.TestShort = null;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestShort), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("greater than or equal to", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("null", Case.Insensitive));
        }

        [Fact]
        public void GivenAboveRules_WhenShortValueLessThanMinimum_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            short actualValue = (short)RandomHelpers.IntBetween(short.MinValue, MINIMUM - 1);
            request.TestShort = actualValue;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestShort), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("greater than or equal to", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(actualValue.ToString()));
        }

        [Fact]
        public void GivenAboveRules_WhenByteValueLessThanMinimum_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            byte actualValue = (byte)RandomHelpers.IntBetween(byte.MinValue, MINIMUM - 1);
            request.TestByte = actualValue;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestByte), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("greater than or equal to", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(actualValue.ToString()));
        }

        [Fact]
        public void GivenAboveRules_WhenDoubleValueLessThanDcimalMinimum_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            var actualValue = (double)MINIMUM_DECIMAL - 1;
            request.TestNonNullableDouble = actualValue;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestNonNullableDouble), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("greater than or equal to", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(actualValue.ToString()));
        }

        [Fact]
        public void GivenAboveRules_WhenDoubleValueNull_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            request.TestNullableDouble = null;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestNullableDouble), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("greater than or equal to", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("null", Case.Insensitive));
        }

        [Fact]
        public void GivenAboveRules_WhenDoubleValueLessThanMinimum_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            var actualValue = RandomHelpers.IntBetween(int.MinValue, MINIMUM - 1);
            request.TestNullableDouble = actualValue;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestNullableDouble), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("greater than or equal to", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(actualValue.ToString()));
        }

        [Fact]
        public void GivenAboveRules_WhenDecimalValueLessThanDecimalMinimum_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            var actualValue = MINIMUM_DECIMAL - 1;
            request.TestNonNullableDecimal = actualValue;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestNonNullableDecimal), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("greater than or equal to", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(actualValue.ToString()));
        }

        [Fact]
        public void GivenAboveRules_WhenDecimalValueNull_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            request.TestNullableDecimal = null;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestNullableDecimal), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("greater than or equal to", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("null", Case.Insensitive));
        }

        [Fact]
        public void GivenAboveRules_WhenDecimalValueLessThanMinimum_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            var actualValue = RandomHelpers.IntBetween(int.MinValue, MINIMUM - 1);
            request.TestNullableDecimal = actualValue;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestNullableDecimal), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("greater than or equal to", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(actualValue.ToString()));
        }

        private static TestClass GetTestClass()
        {
            return new TestClass()
            {
                TestNonNullableInt = RandomHelpers.IntBetween(MINIMUM, int.MaxValue),
                TestNullableInt = RandomHelpers.IntBetween((int)MINIMUM_DECIMAL + 1, int.MaxValue),
                TestUint = (uint)RandomHelpers.IntBetween(MINIMUM, int.MaxValue),
                TestLong = RandomHelpers.IntBetween(MINIMUM, int.MaxValue),
                TestShort = (short)RandomHelpers.IntBetween(MINIMUM, short.MaxValue),
                TestByte = (byte)RandomHelpers.IntBetween(MINIMUM, byte.MaxValue),
                TestNonNullableDouble = RandomHelpers.IntBetween((int)MINIMUM_DECIMAL + 1, int.MaxValue),
                TestNullableDouble = RandomHelpers.IntBetween(MINIMUM, int.MaxValue),
                TestNonNullableDecimal = RandomHelpers.IntBetween((int)MINIMUM_DECIMAL + 1, int.MaxValue),
                TestNullableDecimal = RandomHelpers.IntBetween(MINIMUM, int.MaxValue)
            };
        }
    }
}
