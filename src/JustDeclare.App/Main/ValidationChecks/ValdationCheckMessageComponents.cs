using JustDeclare.Models;
using JustDeclare.Models.Enums;
using System;

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
                }

                return ValueProvided.ToString();
            } 
        }

        protected string OrWithSensitivity(MatchCase caseSensitivity)
            => caseSensitivity == MatchCase.Sensitive ? string.Empty : " or any case-insensitive match";
    }
}