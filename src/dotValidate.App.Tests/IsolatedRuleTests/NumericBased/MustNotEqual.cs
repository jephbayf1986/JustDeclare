using dotValidate.Tests.TestHelpers;
using Shouldly;
using System;
using Xunit;

namespace dotValidate.Tests.IsolatedRuleTests.NumericBased
{
    public class MustNotEqual : NumericTestClass
    {
        private const int TARGET_WHOLE = 76;
        private const double TARGET_DOUBLE = 13.62;
        private const decimal TARGET_DECIMAL = 15.23M;

        private class TestClassValidationRules : ValidationRules<TestClass>
        {
            public TestClassValidationRules()
            {
                DeclareRules(
                        x => x.TestNonNullableInt.MustNotEqual(TARGET_WHOLE),
                        x => x.TestNullableInt.MustNotEqual(TARGET_DOUBLE),
                        x => x.TestUint.MustNotEqual((uint)TARGET_WHOLE),
                        x => x.TestLong.MustNotEqual(TARGET_WHOLE),
                        x => x.TestULong.MustNotEqual(TARGET_DECIMAL),
                        x => x.TestShort.MustNotEqual(TARGET_WHOLE),
                        x => x.TestByte.MustNotEqual(TARGET_WHOLE),
                        X => X.TestNonNullableDouble.MustNotEqual(TARGET_DOUBLE),
                        X => X.TestNullableDouble.MustNotEqual(TARGET_DECIMAL),
                        X => X.TestNonNullableDecimal.MustNotEqual(TARGET_DECIMAL),
                        X => X.TestNullableDecimal.MustNotEqual(TARGET_WHOLE)
                    );
            }
        }

        [Fact]
        public void GivenAboveRules_WhenAllValuesNotAtTarget_PassTest()
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
        public void GivenAboveRules_WhenIntValueEqualToTarget_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            request.TestNonNullableInt = TARGET_WHOLE;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestNonNullableInt), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("equal to", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(TARGET_WHOLE.ToString()));
        }

        [Fact]
        public void GivenAboveRules_WhenUintValueEqualToTarget_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            request.TestUint = TARGET_WHOLE;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestUint), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("equal to", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(TARGET_WHOLE.ToString()));
        }

        [Fact]
        public void GivenAboveRules_WhenLongValueEqualToTarget_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            request.TestLong = TARGET_WHOLE;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestLong), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("equal to", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(TARGET_WHOLE.ToString()));
        }

        [Fact]
        public void GivenAboveRules_WhenShortValueEqualToTarget_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            request.TestShort = TARGET_WHOLE;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestShort), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("equal to", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(TARGET_WHOLE.ToString()));
        }

        [Fact]
        public void GivenAboveRules_WhenByteValueEqualToTarget_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            request.TestByte = TARGET_WHOLE;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestByte), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("equal to", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(TARGET_WHOLE.ToString()));
        }

        [Fact]
        public void GivenAboveRules_WhenDoubleValueEqualToTarget_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            request.TestNonNullableDouble = TARGET_DOUBLE;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestNonNullableDouble), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("equal to", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(TARGET_DOUBLE.ToString()));
        }

        [Fact]
        public void GivenAboveRules_WhenDecimalValueEqualToTarget_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            request.TestNonNullableDecimal = TARGET_DECIMAL;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestNonNullableDecimal), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("equal to", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(TARGET_DECIMAL.ToString()));
        }

        [Fact]
        public void GivenAboveRules_WhenIntValueDiffersFromDoubleTargetByOnlyFraction_PassTest()
        {
            // Arrange
            var request = GetTestClass();
            request.TestNullableInt = ((int)TARGET_DOUBLE) + 1;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.HasFailures.ShouldBeFalse();
        }

        [Fact]
        public void GivenAboveRules_WhenIntValueDiffersFromDecimalTargetByOnlyFraction_PassTest()
        {
            // Arrange
            var request = GetTestClass();
            request.TestULong = ((int)TARGET_DECIMAL) + 1;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.HasFailures.ShouldBeFalse();
        }

        [Fact]
        public void GivenAboveRules_WhenDoubleValueEqualToIntTargetByOnlyFraction_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            request.TestNullableDecimal = TARGET_WHOLE;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestNullableDecimal), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("equal to", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(TARGET_WHOLE.ToString()));
        }

        [Fact]
        public void GivenAboveRules_WhenDoubleValueEqualToDecimalTargetByOnlyFraction_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            request.TestNullableDouble = Convert.ToDouble(TARGET_DECIMAL);

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestNullableDouble), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("equal to", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(TARGET_DECIMAL.ToString()));
        }

        private static TestClass GetTestClass()
        {
            return new TestClass()
            {
                TestNonNullableInt = TARGET_WHOLE + RandomHelpers.IntBetween(1, 100),
                TestNullableInt = TARGET_WHOLE + RandomHelpers.IntBetween(1, 100),
                TestUint = (uint)(TARGET_WHOLE + RandomHelpers.IntBetween(1, 100)),
                TestLong = TARGET_WHOLE + RandomHelpers.IntBetween(1, 100),
                TestULong = (ulong)(TARGET_WHOLE + RandomHelpers.IntBetween(1, 100)),
                TestShort = (short)(TARGET_WHOLE + RandomHelpers.IntBetween(1, 100)),
                TestByte = (byte)(TARGET_WHOLE + RandomHelpers.IntBetween(1, 100)),
                TestNonNullableDouble = TARGET_DOUBLE + RandomHelpers.IntBetween(1, 100),
                TestNullableDouble = TARGET_DOUBLE + RandomHelpers.IntBetween(1, 100),
                TestNonNullableDecimal = TARGET_DECIMAL + RandomHelpers.IntBetween(1, 100),
                TestNullableDecimal = TARGET_DECIMAL + RandomHelpers.IntBetween(1, 100)
            };
        }
    }
}
