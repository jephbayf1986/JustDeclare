using JustDeclare.Models;
using JustDeclare.Models.Enums;

namespace JustDeclare.Main.ValidationChecks
{
    internal abstract partial class ValidationCheck<T> : ValidationCheck
    {
        protected string Was => Invert ? "was not" : "was";

        protected string Should => Invert ? "should not" : "should";

        protected string ShouldBeNull => Invert ? "is required" : "should be null";

        protected string ShouldBeBlank => Invert ? "is required" : "should be blank";

        protected string GreaterThanOrEqualTo => Invert ? "less than" : "greater than or equal to";

        protected string LessThanOrEqualTo => Invert ? "greater than" : "less than or equal to";
        
        protected string ValueProvidedDisplay 
        { 
            get
            {
                if (ValueProvided == null)
                    return "null";

                if (ValueProvided is string)
                {
                    if (ValueProvided as string == string.Empty)
                        return "blank";

                    if ((ValueProvided as string).Length > 10)
                        return $"'{ValueProvided.ToString().Substring(0, 10)}...'";

                    return $"'{ValueProvided}'";
                }

                return ValueProvided.ToString();
            } 
        }
        
        protected string NumberOfCharacters
        {
            get
            {
                if (!(ValueProvided is string))
                    return string.Empty;

                if (ValueProvided == null)
                    return string.Empty;

                return $" ({ValueProvided.ToString().Length} characters)";
            }
        }
            

        protected string OrWithSensitivity(MatchCase caseSensitivity)
            => caseSensitivity == MatchCase.Sensitive ? string.Empty : " or any case-insensitive match";
    }
}