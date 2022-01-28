using dotValidate.Tests.TestHelpers;
using Shouldly;
using Xunit;

namespace dotValidate.Tests.IsolatedRuleTests.NumericBased
{
    public class MustNotBeInRange : NumericTestClass
    {
        private const int MINIMUM = 10;
        private const int MAXIMUM = 20;

        private class TestClassValidationRules : ValidationRules<TestClass>
        {
            public TestClassValidationRules()
            {
                DeclareRules(
                        x => x.TestNullableInt.MustNotBeInRange(MINIMUM, MAXIMUM),
                        x => x.TestUint.MustNotBeInRange((uint)MINIMUM, (uint)MAXIMUM),
                        x => x.TestLong.MustNotBeInRange(MINIMUM, MAXIMUM),
                        x => x.TestShort.MustNotBeInRange((short)MINIMUM, (short)MAXIMUM),
                        x => x.TestByte.MustNotBeInRange((byte)MINIMUM,(byte)MAXIMUM),
                        X => X.TestNullableDouble.MustNotBeInRange(MINIMUM, MAXIMUM),
                        X => X.TestNullableDecimal.MustNotBeInRange(MINIMUM, MAXIMUM)
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
        public void GivenAboveRules_WhenIntValueFallsWithinRange_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            var actualValue = RandomHelpers.IntBetween(MINIMUM, MAXIMUM);
            request.TestNullableInt = actualValue;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestNullableInt), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("not fall within", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(actualValue.ToString()));
        }

        [Fact]
        public void GivenAboveRules_WhenUintValueFallsWithinRange_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            var actualValue = (uint)RandomHelpers.IntBetween(MINIMUM, MAXIMUM);
            request.TestUint = actualValue;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestUint), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("not fall within", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(actualValue.ToString()));
        }

        [Fact]
        public void GivenAboveRules_WhenLongValueFallsWithinRange_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            var actualValue = RandomHelpers.IntBetween(MINIMUM, MAXIMUM);
            request.TestLong = actualValue;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestLong), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("not fall within", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(actualValue.ToString()));
        }

        [Fact]
        public void GivenAboveRules_WhenShortValueFallsWithinRange_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            var actualValue = (short)RandomHelpers.IntBetween(MINIMUM, MAXIMUM);
            request.TestShort = actualValue;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestShort), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("not fall within", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(actualValue.ToString()));
        }

        [Fact]
        public void GivenAboveRules_WhenByteValueFallsWithinRange_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            var actualValue = (byte)RandomHelpers.IntBetween(MINIMUM, MAXIMUM);
            request.TestByte = actualValue;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestByte), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("not fall within", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(actualValue.ToString()));
        }

        [Fact]
        public void GivenAboveRules_WhenDoubleValueFallsWithinRange_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            var actualValue = RandomHelpers.IntBetween(MINIMUM, MAXIMUM);
            request.TestNullableDouble = actualValue;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestNullableDouble), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("not fall within", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(actualValue.ToString()));
        }

        [Fact]
        public void GivenAboveRules_WhenDecimalValueFallsWithinRange_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            var actualValue = RandomHelpers.IntBetween(MINIMUM, MAXIMUM);
            request.TestNullableDecimal = actualValue;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestNullableDecimal), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("not fall within", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(actualValue.ToString()));
        }

        private static TestClass GetTestClass()
        {
            return new TestClass()
            {
                TestNullableInt = RandomHelpers.IntBetween(int.MinValue, MINIMUM - 1),
                TestUint = (uint)RandomHelpers.IntBetween(0, MINIMUM - 1),
                TestLong = RandomHelpers.IntBetween(int.MinValue, MINIMUM - 1),
                TestShort = (short)RandomHelpers.IntBetween(short.MinValue, MINIMUM - 1),
                TestByte = (byte)RandomHelpers.IntBetween(MAXIMUM + 1, byte.MaxValue),
                TestNullableDouble = RandomHelpers.IntBetween(MAXIMUM + 1, int.MaxValue),
                TestNullableDecimal = RandomHelpers.IntBetween(MAXIMUM + 1, int.MaxValue)
            };
        }
    }
}