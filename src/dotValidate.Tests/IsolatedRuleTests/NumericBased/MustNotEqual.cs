using dotValidate.Tests.TestHelpers;
using Shouldly;
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
                        x => x.TestNullableInt.MustNotEqual(TARGET_WHOLE),
                        x => x.TestUint.MustNotEqual((uint)TARGET_WHOLE),
                        x => x.TestLong.MustNotEqual(TARGET_WHOLE),
                        x => x.TestShort.MustNotEqual((short)TARGET_WHOLE),
                        x => x.TestByte.MustNotEqual((byte)TARGET_WHOLE),
                        X => X.TestNullableDouble.MustNotEqual(TARGET_DOUBLE),
                        X => X.TestNullableDecimal.MustNotEqual(TARGET_DECIMAL)
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
        public void GivenAboveRules_WhenIntValueDiffersFromTarget_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            request.TestNullableInt = TARGET_WHOLE;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestNullableInt), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("equal to", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(TARGET_WHOLE.ToString()));
        }

        [Fact]
        public void GivenAboveRules_WhenUintValueDiffersFromTarget_FailTestWithPropertyInMessage()
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
        public void GivenAboveRules_WhenLongValueDiffersFromTarget_FailTestWithPropertyInMessage()
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
        public void GivenAboveRules_WhenShortValueDiffersFromTarget_FailTestWithPropertyInMessage()
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
        public void GivenAboveRules_WhenByteValueDiffersFromTarget_FailTestWithPropertyInMessage()
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
        public void GivenAboveRules_WhenDoubleValueDiffersFromTarget_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            request.TestNullableDouble = TARGET_DOUBLE;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestNullableDouble), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("equal to", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(TARGET_DOUBLE.ToString()));
        }

        [Fact]
        public void GivenAboveRules_WhenDecimalValueDiffersFromTarget_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            request.TestNullableDecimal = TARGET_DECIMAL;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestNullableDecimal), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("equal to", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(TARGET_DECIMAL.ToString()));
        }

        private static TestClass GetTestClass()
        {
            return new TestClass()
            {
                TestNullableInt = TARGET_WHOLE + RandomHelpers.IntBetween(1, 100),
                TestUint = (uint)(TARGET_WHOLE + RandomHelpers.IntBetween(1, 100)),
                TestLong = TARGET_WHOLE + RandomHelpers.IntBetween(1, 100),
                TestShort = (short)(TARGET_WHOLE + RandomHelpers.IntBetween(1, 100)),
                TestByte = (byte)(TARGET_WHOLE + RandomHelpers.IntBetween(1, 100)),
                TestNullableDouble = TARGET_DOUBLE + RandomHelpers.IntBetween(1, 100),
                TestNullableDecimal = TARGET_DECIMAL + RandomHelpers.IntBetween(1, 100)
            };
        }
    }
}
