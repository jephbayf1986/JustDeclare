using JustDeclare.Models;

namespace JustDeclare.Main.ValidationChecks
{
    internal abstract partial class ValidationCheck<T> : ValidationCheck
    {
        protected string Was => Invert ? "was not" : "was";

        protected string Should => Invert ? "should not" : "should";

        protected string ShouldBeNull => Invert ? "is required" : "should be null";
    }
}