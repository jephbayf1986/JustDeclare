using dotValidate.Tests.TestHelpers;
using Shouldly;
using Xunit;

namespace dotValidate.Tests.IsolatedRuleTests.NumericBased
{
    public class MustNotBeZero : NumericTestClass
    {
        private class TestClassValidationRules : ValidationRules<TestClass>
        {
            public TestClassValidationRules()
            {
                DeclareRules(
                        x => x.TestNonNullableInt.MustNotBeZero(),
                        x => x.TestNullableInt.MustNotBeZero(),
                        x => x.TestUint.MustNotBeZero(),
                        x => x.TestLong.MustNotBeZero(),
                        x => x.TestShort.MustNotBeZero(),
                        x => x.TestByte.MustNotBeZero(),
                        x => x.TestNonNullableDouble.MustNotBeZero(),
                        x => x.TestNullableDouble.MustNotBeZero(),
                        x => x.TestNonNullableDecimal.MustNotBeZero(),
                        x => x.TestNullableDecimal.MustNotBeZero()
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
        public void GivenAboveRules_WhenAnyNullableValuesAreNull_PassTest()
        {
            // Arrange
            var request = GetTestClass();
            request.TestNullableInt = null;
            request.TestNullableDouble = null;
            request.TestNullableDecimal = null;
            request.TestShort = null;
            request.TestULong = null;

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
            request.TestNullableInt = 0;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestNullableInt), Case.Insensitive),
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
            request.TestNullableDouble = 0;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestNullableDouble), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("zero", Case.Insensitive));
        }

        [Fact]
        public void GivenAboveRules_WhenDecimalValueIsZero_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            request.TestNullableDecimal = 0;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestNullableDecimal), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("zero", Case.Insensitive));
        }

        private static TestClass GetTestClass()
        {
            return new TestClass()
            {
                TestNonNullableInt = RandomHelpers.IntBetween(1, 100),
                TestNullableInt = RandomHelpers.IntBetween(1, 100),
                TestUint = (uint)RandomHelpers.IntBetween(1, 100),
                TestLong = RandomHelpers.IntBetween(1, 100),
                TestULong = (ulong)RandomHelpers.IntBetween(1, 100),
                TestShort = (short)RandomHelpers.IntBetween(1, 100),
                TestByte = (byte)RandomHelpers.IntBetween(1, 100),
                TestNonNullableDouble = RandomHelpers.IntBetween(1, 100),
                TestNullableDouble = RandomHelpers.IntBetween(1, 100),
                TestNonNullableDecimal = RandomHelpers.IntBetween(1, 100),
                TestNullableDecimal = RandomHelpers.IntBetween(1, 100)
            };
        }
    }
}