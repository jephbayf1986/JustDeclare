using dotValidate.Tests.TestHelpers;
using Shouldly;
using Xunit;

namespace dotValidate.Tests.IsolatedRuleTests
{
    public class MustObeyTheseRules : GeneralTestClass
    {
        private class TestClassValidationRules : ValidationRules<TestClass>
        {
            public TestClassValidationRules()
            {
                DeclareRules(
                        x => x.ChildObject.MustObeyTheseRules(
                                x => x.TestInteger.MustNotBeNull(),
                                x => x.TestString.MustNotBeNull(),
                                x => x.TestDouble.MustBeNull(),
                                x => x.TestDecimal.MustBeNull(),
                                x => x.TestDateTime.MustBeNull()
                            )
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
        public void GivenAboveRules_WhenWholeObjectIsNull_FailWithNullReferenceInMessage()
        {
            // Arrange
            TestClass request = new();
            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.ChildObject), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(nameof(TestClass), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("null reference", Case.Insensitive));
        }

        [Fact]
        public void GivenAboveRules_WhenOneRuleIsBroken_FailWithPropertyInMessage()
        {
            // Arrange
            TestClass request = GetTestClass();
            request.ChildObject.TestInteger = null;

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.ChildObject), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(nameof(request.ChildObject.TestInteger), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("required", Case.Insensitive));
        }

        [Fact]
        public void GivenAboveRules_WhenMoreThanOneRuleIsBroken_FailWithAllPropertiesInMessage()
        {
            // Arrange
            TestClass request = GetTestClass();
            request.ChildObject.TestInteger = null;
            request.ChildObject.TestDecimal = RandomHelpers.IntBetween(0, 10);

            var validator = new TestClassValidationRules();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.ShouldSatisfyAllConditions(x => x.HasFailures.ShouldBeTrue(),
                                              x => x.FailureSummary().ShouldContain(nameof(request.ChildObject), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(2.ToString()),
                                              x => x.FailureSummary().ShouldContain(nameof(request.ChildObject.TestInteger), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain(nameof(request.ChildObject.TestDecimal), Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("required", Case.Insensitive),
                                              x => x.FailureSummary().ShouldContain("should be null", Case.Insensitive));
        }

        private static TestClass GetTestClass()
        {
            return new TestClass()
            {
                ChildObject = new TestClass()
                {
                    TestInteger = RandomHelpers.IntBetween(1, 10),
                    TestString = RandomHelpers.RandomString(),
                    TestDouble = null,
                    TestDecimal = null,
                    TestDateTime = null
                }
            };
        }
    }
}