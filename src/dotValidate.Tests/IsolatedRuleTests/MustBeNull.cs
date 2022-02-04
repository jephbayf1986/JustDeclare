using dotValidate.Tests.TestHelpers;
using Shouldly;
using Xunit;

namespace dotValidate.Tests.IsolatedRuleTests
{
    public class MustNotBeNull : GeneralTestClass
    { 
        private class TestClassValidationRules : ValidationRules<TestClass>
        {
            public TestClassValidationRules()
            {
                DeclareRules(
                        x => x.TestInteger.MustNotBeNull(),
                        x => x.TestString.MustNotBeNull(),
                        X => X.TestDouble.MustNotBeNull(),
                        X => X.TestDecimal.MustNotBeNull(),
                        x => x.TestDateTime.MustNotBeNull(),
                        x => x.ChildObject.MustNotBeNull()
                    );
            }
        }

        [Fact]
        public void GivenAboveRules_WhenAllValuesNotNull_PassTest()
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
                                              x => x.FailureSummary().ShouldContain("required", Case.Insensitive));
        }

        [Fact]
        public void GivenAboveRules_WhenStringValueNull_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            request.TestString = null;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestString), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("required", Case.Insensitive));
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
                                              x => x.FailureSummary().ShouldContain("required", Case.Insensitive));
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
                                              x => x.FailureSummary().ShouldContain("required", Case.Insensitive));
        }

        [Fact]
        public void GivenAboveRules_WhenDateTimeValueNull_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            request.TestDateTime = null;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestDateTime), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("required", Case.Insensitive));
        }

        [Fact]
        public void GivenAboveRules_WhenObjectValueNull_FailTestWithPropertyInMessage()
        {
            // Arrange
            var request = GetTestClass();
            request.ChildObject = null;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.ChildObject), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("required", Case.Insensitive));
        }

        private static TestClass GetTestClass()
        {
            return new TestClass()
            {
                TestInteger = RandomHelpers.IntBetween(1, 10),
                TestString = RandomHelpers.RandomString(),
                TestDouble = RandomHelpers.IntBetween(1, 10),
                TestDecimal = RandomHelpers.IntBetween(1, 10),
                TestDateTime = RandomHelpers.DateInPast(100),
                ChildObject = new TestClass()
            };
        }
    }
}
