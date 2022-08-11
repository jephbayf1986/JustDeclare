using dotValidate.Testing.Extensions;
using dotValidate.Testing.Tests.TestResources;
using Xunit;

namespace dotValidate.Testing.Tests
{
    public class ValidationResultTests
    {
        private static IValidator validator = new Validator();

        [Fact]
        public void ShouldHavePassed()
        {
            var request = new ARequest() { Id = 1 };

            var result = validator.Validate(request)
                                  .Using<ARequestValidator>();

            result.ShouldHavePassed();
        }

        [Fact]
        public void ShouldHaveFailed()
        {
            var request = new ARequest() { Id = 0 };

            var result = validator.Validate(request)
                                  .Using<ARequestValidator>();

            result.ShouldHaveFailed();
        }

        [Fact]
        public void ShouldHaveOneFailureOnly()
        {
            var request = new BRequest() { Id = "A" };

            var result = validator.Validate(request)
                                  .Using<BRequestValidator>();

            result.ShouldHaveOneFailureOnly();
        }

        [Fact]
        public void ShouldHaveFailuresCount()
        {
            var request = new BRequest() { Id = string.Empty };

            var result = validator.Validate(request)
                                  .Using<BRequestValidator>();

            result.ShouldHaveFailuresCount(2);
        }

        [Fact]
        public void ShouldIncludeFailureText()
        {
            var request = new ARequest() { Id = 15 };

            var result = validator.Validate(request)
                                  .Using<ARequestValidator>();

            result.ShouldIncludeFailureText("less than 10");
        }
    }
}