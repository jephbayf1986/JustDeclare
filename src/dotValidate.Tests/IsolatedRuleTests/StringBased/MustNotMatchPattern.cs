namespace dotValidate.Tests.IsolatedRuleTests.StringBased
{
    public class MustNotMatchPattern : StringTestClass
    {
        private const string NUMBERIC_PATTERM = "^[0-9]+$";
        private const string EMAIL_PATTERN = "/^S+@S+.S+$/";

        private class TestClassValidationRules : ValidationRules<TestClass>
        {
            public TestClassValidationRules()
            {
                DeclareRules(
                        x => x.TestNullable.MustNotMatchPattern(NUMBERIC_PATTERM),
                        x => x.TestNonNullable.MustNotMatchPattern(EMAIL_PATTERN)
                    );
            }
        }

        private static TestClass GetTestClass()
        {
            return new TestClass()
            {
                TestNullable = "ABCDEF",
                TestNonNullable = "abcdef.com"
            };
        }
    }
}