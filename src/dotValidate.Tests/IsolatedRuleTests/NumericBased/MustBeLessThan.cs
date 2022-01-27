using dotValidate.Tests.TestHelpers;
using Shouldly;
using Xunit;

namespace dotValidate.Tests.IsolatedRuleTests.NumericBased
{
    public class MustBeLessThan : NumericTestClass
    {
        private const int TARGET = 10;

        private class TestClassValidationRules : ValidationRules<TestClass>
        {
            public TestClassValidationRules()
            {
                DeclareRules(
                        x => x.TestInteger.MustBeLessThan(TARGET),
                        x => x.TestUint.MustBeLessThan((uint)TARGET),
                        x => x.TestLong.MustBeLessThan(TARGET),
                        x => x.TestShort.MustBeLessThan((short)TARGET),
                        x => x.TestByte.MustBeLessThan((byte)TARGET),
                        X => X.TestDouble.MustBeLessThan(TARGET),
                        X => X.TestDecimal.MustBeLessThan(TARGET)
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
        public void GivenAboveRules_WhenIntValueGreaterThanTarget_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            var actualValue = RandomHelpers.IntBetween(TARGET + 1, int.MaxValue);
            request.TestInteger = actualValue;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestInteger), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("less than", Case.Insensitive),
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
                                              x => x.FailureSummary().ShouldContain("less than", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(TARGET.ToString()));
        }

        [Fact]
        public void GivenAboveRules_WhenUintValueGreaterThanTarget_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            var actualValue = (uint)RandomHelpers.IntBetween(TARGET + 1, int.MaxValue);
            request.TestUint = actualValue;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestUint), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("less than", Case.Insensitive),
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
                                              x => x.FailureSummary().ShouldContain("less than", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(actualValue.ToString()));
        }

        [Fact]
        public void GivenAboveRules_WhenLongValueGreaterThanTarget_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            var actualValue = RandomHelpers.IntBetween(TARGET + 1, int.MaxValue);
            request.TestLong = actualValue;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestLong), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("less than", Case.Insensitive),
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
                                              x => x.FailureSummary().ShouldContain("less than", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(TARGET.ToString()));
        }

        [Fact]
        public void GivenAboveRules_WhenShortValueGreaterThanTarget_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            var actualValue = (short)RandomHelpers.IntBetween(TARGET + 1, short.MaxValue);
            request.TestShort = actualValue;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestShort), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("less than", Case.Insensitive),
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
                                              x => x.FailureSummary().ShouldContain("less than", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(TARGET.ToString()));
        }

        [Fact]
        public void GivenAboveRules_WhenByteValueGreaterThanTarget_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            var actualValue = (byte)RandomHelpers.IntBetween(TARGET + 1, byte.MaxValue);
            request.TestByte = actualValue;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestByte), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("less than", Case.Insensitive),
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
                                              x => x.FailureSummary().ShouldContain("less than", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(TARGET.ToString()));
        }

        [Fact]
        public void GivenAboveRules_WhenDoubleValueGreaterThanTarget_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            var actualValue = RandomHelpers.IntBetween(TARGET + 1, int.MaxValue);
            request.TestDouble = actualValue;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestDouble), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("less than", Case.Insensitive),
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
                                              x => x.FailureSummary().ShouldContain("less than", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(TARGET.ToString()));
        }

        [Fact]
        public void GivenAboveRules_WhenDecimalValueGreaterThanTarget_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            var actualValue = RandomHelpers.IntBetween(TARGET + 1, int.MaxValue);
            request.TestDecimal = actualValue;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestDecimal), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("less than", Case.Insensitive),
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
                                              x => x.FailureSummary().ShouldContain("less than", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(TARGET.ToString()));
        }

        private static TestClass GetTestClass()
        {
            return new TestClass()
            {
                TestInteger = RandomHelpers.IntBetween(int.MinValue, TARGET - 1),
                TestUint = (uint)RandomHelpers.IntBetween(0, TARGET - 1),
                TestLong = RandomHelpers.IntBetween(int.MinValue, TARGET - 1),
                TestShort = (short)RandomHelpers.IntBetween(short.MinValue, TARGET - 1),
                TestByte = (byte)RandomHelpers.IntBetween(byte.MinValue, TARGET - 1),
                TestDouble = RandomHelpers.IntBetween(int.MinValue, TARGET - 1),
                TestDecimal = RandomHelpers.IntBetween(int.MinValue, TARGET - 1)
            };
        }
    }
}