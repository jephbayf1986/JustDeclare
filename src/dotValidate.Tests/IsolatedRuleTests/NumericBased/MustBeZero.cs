using dotValidate.Tests.TestHelpers;
using Shouldly;
using Xunit;

namespace dotValidate.Tests.IsolatedRuleTests.NumericBased
{
    public class MustBeZero : NumericTestClass
    {
        private class TestClassValidationRules : ValidationRules<TestClass>
        {
            public TestClassValidationRules()
            {
                DeclareRules(
                        x => x.TestInteger.MustBeZero(),
                        x => x.TestUint.MustBeZero(),
                        x => x.TestLong.MustBeZero(),
                        x => x.TestShort.MustBeZero(),
                        x => x.TestByte.MustBeZero(),
                        X => X.TestDouble.MustBeZero(),
                        X => X.TestDecimal.MustBeZero()
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
                                              x => x.FailureSummary().ShouldContain("zero", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("null", Case.Insensitive));
        }

        [Fact]
        public void GivenAboveRules_WhenIntValueDiffersFromZero_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            var actualValue = RandomHelpers.IntBetween(1, 100);
            request.TestInteger = actualValue;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestInteger), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("zero", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(actualValue.ToString()));
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
                                              x => x.FailureSummary().ShouldContain("zero", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("null", Case.Insensitive));
        }

        [Fact]
        public void GivenAboveRules_WhenUintValueDiffersFromZero_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            var actualValue = RandomHelpers.IntBetween(1, 100);
            request.TestUint = (uint)actualValue;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestUint), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("zero", Case.Insensitive),
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
                                              x => x.FailureSummary().ShouldContain("zero", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("null", Case.Insensitive));
        }

        [Fact]
        public void GivenAboveRules_WhenLongValueDiffersFromZero_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            var actualValue = RandomHelpers.IntBetween(1, 100);
            request.TestLong = actualValue;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestLong), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("zero", Case.Insensitive),
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
                                              x => x.FailureSummary().ShouldContain("zero", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("null", Case.Insensitive));
        }

        [Fact]
        public void GivenAboveRules_WhenShortValueDiffersFromZero_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            var actualValue = RandomHelpers.IntBetween(1, 100);
            request.TestShort = (short)actualValue;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestShort), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("zero", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(actualValue.ToString()));
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
                                              x => x.FailureSummary().ShouldContain("zero", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("null", Case.Insensitive));
        }

        [Fact]
        public void GivenAboveRules_WhenByteValueDiffersFromZero_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            var actualValue = RandomHelpers.IntBetween(1, 100);
            request.TestByte = (byte)actualValue;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestByte), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("zero", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(actualValue.ToString()));
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
                                              x => x.FailureSummary().ShouldContain("zero", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("null", Case.Insensitive));
        }

        [Fact]
        public void GivenAboveRules_WhenDoubleValueDiffersFromZero_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            var actualValue = RandomHelpers.IntBetween(1, 100);
            request.TestDouble = actualValue;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestDouble), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("zero", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(actualValue.ToString()));
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
                                              x => x.FailureSummary().ShouldContain("zero", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("null", Case.Insensitive));
        }

        [Fact]
        public void GivenAboveRules_WhenDecimalValueDiffersFromZero_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            var actualValue = RandomHelpers.IntBetween(1,100);
            request.TestDecimal = actualValue;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestDecimal), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("zero", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(actualValue.ToString()));
        }

        private static TestClass GetTestClass()
        {
            return new TestClass()
            {
                TestInteger = 0,
                TestUint = 0,
                TestLong = 0,
                TestShort = 0,
                TestByte = 0,
                TestDouble = 0,
                TestDecimal = 0
            };
        }
    }
}