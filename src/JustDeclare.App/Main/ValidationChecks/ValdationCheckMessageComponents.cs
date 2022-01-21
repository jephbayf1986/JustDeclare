using JustDeclare.Models;

namespace JustDeclare.Main.ValidationChecks
{
    internal abstract partial class ValidationCheck<T> : ValidationCheck
    {
        protected string Was => Invert ? "was not" : "was";

        protected string Should => Invert ? "should not" : "should";

        protected string ShouldBeNull => Invert ? "is required" : "should be null";

        protected string GreaterThanOrEqualTo => Invert ? "less than" : "greater than or equal to";

        protected string LessThanOrEqualTo => Invert ? "greater than" : "less than or equal to";
        
        protected string ValueProvidedDisplay 
        { 
            get
            {
                if (ValueProvided == null)
                    return "null";

                return ValueProvided.ToString();
            } 
        }
    }
}