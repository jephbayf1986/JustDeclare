using dotValidate.Tests.TestHelpers;
using Shouldly;
using System;
using Xunit;

namespace dotValidate.Tests.IsolatedRuleTests
{
    public class MustBeNull : GeneralTestClass
    {
        private class TestClassValidationRules : ValidationRules<TestClass>
        {
            public TestClassValidationRules()
            {
                DeclareRules(
                        x => x.TestInteger.MustBeNull(),
                        x => x.TestString.MustBeNull(),
                        X => X.TestDouble.MustBeNull(),
                        X => X.TestDecimal.MustBeNull(),
                        x => x.TestDateTime.MustBeNull(),
                        x => x.ChildObject.MustBeNull()
                    );
            }
        }

        [Fact]
        public void GivenAboveRules_WhenAllValuesNull_PassTest()
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
        public void GivenAboveRules_WhenIntValueNotNull_FailTestWithPropertyInMessage()
        {
            // Arrange
            var testInteger = RandomHelpers.IntBetween(1, 10);
            var request = GetTestClass(testInteger: testInteger);

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestInteger), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("should be null", Case.Insensitive));
        }

        [Fact]
        public void GivenAboveRules_WhenStringValueNotNull_FailTestWithPropertyInMessage()
        {
            // Arrange
            var testString = RandomHelpers.RandomString();
            var request = GetTestClass(testString: testString);

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestString), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("should be null", Case.Insensitive));
        }

        [Fact]
        public void GivenAboveRules_WhenDoubleValueNotNull_FailTestWithPropertyInMessage()
        {
            // Arrange
            var testDouble = RandomHelpers.IntBetween(1, 10);
            var request = GetTestClass(testDouble: testDouble);

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestDouble), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("should be null", Case.Insensitive));
        }

        [Fact]
        public void GivenAboveRules_WhenDecimalValueNotNull_FailTestWithPropertyInMessage()
        {
            // Arrange
            var testDecimal = RandomHelpers.IntBetween(1, 10);
            var request = GetTestClass(testDecimal: testDecimal);

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestDecimal), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("should be null", Case.Insensitive));
        }

        [Fact]
        public void GivenAboveRules_WhenDateTimeValueNotNull_FailTestWithPropertyInMessage()
        {
            // Arrange
            var testDateTime = RandomHelpers.DateInPast(100);
            var request = GetTestClass(testDateTime: testDateTime);

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.TestDateTime), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("should be null", Case.Insensitive));
        }

        [Fact]
        public void GivenAboveRules_WhenObjectValueNotNull_FailTestWithPropertyInMessage()
        {
            // Arrange
            var childObject = new TestClass();
            var request = GetTestClass(childObject: childObject);

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.ChildObject), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("should be null", Case.Insensitive));
        }

        private static TestClass GetTestClass(
            int? testInteger = null, 
            string? testString = null,
            double? testDouble = null, 
            decimal? testDecimal = null, 
            DateTime? testDateTime = null,
            TestClass? childObject = null)
        {
            return new TestClass()
            {
                TestInteger = testInteger,
                TestString = testString,
                TestDouble = testDouble,
                TestDecimal = testDecimal,
                TestDateTime = testDateTime,
                ChildObject = childObject
            };
        }
    }
}
