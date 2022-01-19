using JustDeclare.Tests.TestHelpers;
using Shouldly;
using Xunit;

namespace JustDeclare.Tests.IsolatedRuleTests.NumericBased
{
    public class MustNotEqual
    {
        internal class TestClass
        {
            public int? TestInteger { get; set; }

            public uint? TestUint { get; set; }

            public long? TestLong { get; set; }

            public short? TestShort { get; set; }

            public byte? TestByte { get; set; }

            public double? TestDouble { get; set; }

            public decimal? TestDecimal { get; set; }
        }

        private const int TARGET_WHOLE = 76;
        private const double TARGET_DOUBLE = 13.62;
        private const decimal TARGET_DECIMAL = 15.23M;

        internal class TestClassValidationRules : ValidationRules<TestClass>
        {
            public TestClassValidationRules()
            {
                DeclareRules(
                        x => x.TestInteger.MustNotEqual(TARGET_WHOLE),
                        x => x.TestUint.MustNotEqual((uint)TARGET_WHOLE),
                        x => x.TestLong.MustNotEqual(TARGET_WHOLE),
                        x => x.TestShort.MustNotEqual((short)TARGET_WHOLE),
                        x => x.TestByte.MustNotEqual((byte)TARGET_WHOLE),
                        X => X.TestDouble.MustNotEqual(TARGET_DOUBLE),
                        X => X.TestDecimal.MustNotEqual(TARGET_DECIMAL)
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
            request.TestInteger = TARGET_WHOLE;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestInteger), Case.Insensitive),
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
            request.TestDouble = TARGET_DOUBLE;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestDouble), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("equal to", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(TARGET_DOUBLE.ToString()));
        }

        [Fact]
        public void GivenAboveRules_WhenDecimalValueDiffersFromTarget_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            request.TestDecimal = TARGET_DECIMAL;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestDecimal), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("equal to", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(TARGET_DECIMAL.ToString()));
        }

        private static TestClass GetTestClass()
        {
            return new TestClass()
            {
                TestInteger = TARGET_WHOLE + RandomHelpers.IntBetween(1, 100),
                TestUint = (uint)(TARGET_WHOLE + RandomHelpers.IntBetween(1, 100)),
                TestLong = TARGET_WHOLE + RandomHelpers.IntBetween(1, 100),
                TestShort = (short)(TARGET_WHOLE + RandomHelpers.IntBetween(1, 100)),
                TestByte = (byte)(TARGET_WHOLE + RandomHelpers.IntBetween(1, 100)),
                TestDouble = TARGET_DOUBLE + RandomHelpers.IntBetween(1, 100),
                TestDecimal = TARGET_DECIMAL + RandomHelpers.IntBetween(1, 100)
            };
        }
    }
}
