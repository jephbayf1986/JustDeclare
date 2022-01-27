using JustDeclare.Tests.TestHelpers;
using Shouldly;
using Xunit;

namespace JustDeclare.Tests.IsolatedRuleTests.NumericBased
{
    public class MustNotBeZero : NumericTestClass
    {
        private class TestClassValidationRules : ValidationRules<TestClass>
        {
            public TestClassValidationRules()
            {
                DeclareRules(
                        x => x.TestInteger.MustNotBeZero(),
                        x => x.TestUint.MustNotBeZero(),
                        x => x.TestLong.MustNotBeZero(),
                        x => x.TestShort.MustNotBeZero(),
                        x => x.TestByte.MustNotBeZero(),
                        X => X.TestDouble.MustNotBeZero(),
                        X => X.TestDecimal.MustNotBeZero()
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
        public void GivenAboveRules_WhenIntValueIsZero_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            request.TestInteger = 0;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestInteger), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("zero", Case.Insensitive));
        }

        [Fact]
        public void GivenAboveRules_WhenUintValueIsZero_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            request.TestUint = 0;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestUint), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("zero", Case.Insensitive));
        }

        [Fact]
        public void GivenAboveRules_WhenLongValueIsZero_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            request.TestLong = 0;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestLong), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("zero", Case.Insensitive));
        }

        [Fact]
        public void GivenAboveRules_WhenShortValueIsZero_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            request.TestShort = 0;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestShort), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("zero", Case.Insensitive));
        }

        [Fact]
        public void GivenAboveRules_WhenByteValueIsZero_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            request.TestByte = 0;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestByte), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("zero", Case.Insensitive));
        }

        [Fact]
        public void GivenAboveRules_WhenDoubleValueIsZero_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            request.TestDouble = 0;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestDouble), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("zero", Case.Insensitive));
        }

        [Fact]
        public void GivenAboveRules_WhenDecimalValueIsZero_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            request.TestDecimal = 0;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestDecimal), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("zero", Case.Insensitive));
        }

        private static TestClass GetTestClass()
        {
            return new TestClass()
            {
                TestInteger = RandomHelpers.IntBetween(1, 100),
                TestUint = (uint)RandomHelpers.IntBetween(1, 100),
                TestLong = RandomHelpers.IntBetween(1, 100),
                TestShort = (short)RandomHelpers.IntBetween(1, 100),
                TestByte = (byte)RandomHelpers.IntBetween(1, 100),
                TestDouble = RandomHelpers.IntBetween(1, 100),
                TestDecimal = RandomHelpers.IntBetween(1, 100)
            };
        }
    }
}