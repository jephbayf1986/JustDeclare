using dotValidate.Tests.TestHelpers;
using Shouldly;
using Xunit;

namespace dotValidate.Tests.IsolatedRuleTests.NumericBased
{
    public class MustBeGreaterThan : NumericTestClass
    {
        private const int TARGET = 10;

        private class TestClassValidationRules : ValidationRules<TestClass>
        {
            public TestClassValidationRules()
            {
                DeclareRules(
                        x => x.TestInteger.MustBeGreaterThan(TARGET),
                        x => x.TestUint.MustBeGreaterThan((uint)TARGET),
                        x => x.TestLong.MustBeGreaterThan(TARGET),
                        x => x.TestShort.MustBeGreaterThan((short)TARGET),
                        x => x.TestByte.MustBeGreaterThan((byte)TARGET),
                        X => X.TestDouble.MustBeGreaterThan(TARGET),
                        X => X.TestDecimal.MustBeGreaterThan(TARGET)
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
        public void GivenAboveRules_WhenIntValueNull_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            request.TestInteger = null;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestInteger), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("greater than", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("null", Case.Insensitive));
        }

        [Fact]
        public void GivenAboveRules_WhenIntValueLessThanTarget_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            var actualValue = RandomHelpers.IntBetween(int.MinValue, TARGET - 1);
            request.TestInteger = actualValue;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestInteger), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("greater than", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(actualValue.ToString()));
        }

        [Fact]
        public void GivenAboveRules_WhenIntValueEqualToTarget_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            request.TestInteger = TARGET;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestInteger), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("greater than", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(TARGET.ToString()));
        }

        [Fact]
        public void GivenAboveRules_WhenUintValueNull_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            request.TestUint = null;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestUint), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("greater than", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("null", Case.Insensitive));
        }

        [Fact]
        public void GivenAboveRules_WhenUintValueLessThanTarget_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            var actualValue = (uint)RandomHelpers.IntBetween(0, TARGET - 1);
            request.TestUint = actualValue;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestUint), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("greater than", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(actualValue.ToString()));
        }

        [Fact]
        public void GivenAboveRules_WhenUintValueEqualToTarget_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            var actualValue = (uint)TARGET;
            request.TestUint = actualValue;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestUint), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("greater than", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(actualValue.ToString()));
        }

        [Fact]
        public void GivenAboveRules_WhenLongValueNull_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            request.TestLong = null;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestLong), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("greater than", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("null", Case.Insensitive));
        }

        [Fact]
        public void GivenAboveRules_WhenLongValueLessThanTarget_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            var actualValue = RandomHelpers.IntBetween(int.MinValue, TARGET - 1);
            request.TestLong = actualValue;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestLong), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("greater than", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(actualValue.ToString()));
        }

        [Fact]
        public void GivenAboveRules_WhenLongValueEqualToTarget_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            request.TestLong = TARGET;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestLong), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("greater than", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(TARGET.ToString()));
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
                                              x => x.FailureSummary().ShouldContain("greater than", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("null", Case.Insensitive));
        }

        [Fact]
        public void GivenAboveRules_WhenShortValueLessThanTarget_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            short actualValue = (short)RandomHelpers.IntBetween(short.MinValue, TARGET - 1);
            request.TestShort = actualValue;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestShort), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("greater than", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(actualValue.ToString()));
        }

        [Fact]
        public void GivenAboveRules_WhenShortValueEqualToTarget_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            request.TestShort = TARGET;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestShort), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("greater than", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(TARGET.ToString()));
        }

        [Fact]
        public void GivenAboveRules_WhenByteValueNull_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            request.TestByte = null;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestByte), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("greater than", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("null", Case.Insensitive));
        }

        [Fact]
        public void GivenAboveRules_WhenByteValueLessThanTarget_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            byte actualValue = (byte)RandomHelpers.IntBetween(byte.MinValue, TARGET - 1);
            request.TestByte = actualValue;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestByte), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("greater than", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(actualValue.ToString()));
        }

        [Fact]
        public void GivenAboveRules_WhenByteValueEqualToTarget_FailTestWithPropertyInMessage()
        {
            // Arrange 
            var request = GetTestClass();
            request.TestByte = TARGET;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestByte), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("greater than", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(TARGET.ToString()));
        }

        [Fact]
        public void GivenAboveRules_WhenDoubleValueNull_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            request.TestDouble = null;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestDouble), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("greater than", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("null", Case.Insensitive));
        }

        [Fact]
        public void GivenAboveRules_WhenDoubleValueLessThanTarget_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            var actualValue = RandomHelpers.IntBetween(int.MinValue, TARGET - 1);
            request.TestDouble = actualValue;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestDouble), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("greater than", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(actualValue.ToString()));
        }

        [Fact]
        public void GivenAboveRules_WhenDoubleValueEqualToTarget_FailTestWithPropertyInMessage()
        {
            // Arrange 
            var request = GetTestClass();
            request.TestDouble = TARGET;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestDouble), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("greater than", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(TARGET.ToString()));
        }

        [Fact]
        public void GivenAboveRules_WhenDecimalValueNull_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            request.TestDecimal = null;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestDecimal), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("greater than", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("null", Case.Insensitive));
        }

        [Fact]
        public void GivenAboveRules_WhenDecimalValueLessThanTarget_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            var actualValue = RandomHelpers.IntBetween(int.MinValue, TARGET - 1);
            request.TestDecimal = actualValue;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestDecimal), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("greater than", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(actualValue.ToString()));
        }

        [Fact]
        public void GivenAboveRules_WhenDecimalValueEqualToTarget_FailTestWithPropertyInMessage()
        {
            // Arrange 
            var request = GetTestClass();
            request.TestDecimal = TARGET;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestDecimal), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("greater than", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(TARGET.ToString()));
        }

        private static TestClass GetTestClass()
        {
            return new TestClass()
            {
                TestInteger = RandomHelpers.IntBetween(TARGET + 1, int.MaxValue),
                TestUint = (uint)RandomHelpers.IntBetween(TARGET + 1, int.MaxValue),
                TestLong = RandomHelpers.IntBetween(TARGET + 1, int.MaxValue),
                TestShort = (short)RandomHelpers.IntBetween(TARGET + 1, short.MaxValue),
                TestByte = (byte)RandomHelpers.IntBetween(TARGET + 1, byte.MaxValue),
                TestDouble = RandomHelpers.IntBetween(TARGET + 1, int.MaxValue),
                TestDecimal = RandomHelpers.IntBetween(TARGET + 1, int.MaxValue)
            };
        }
    }
}