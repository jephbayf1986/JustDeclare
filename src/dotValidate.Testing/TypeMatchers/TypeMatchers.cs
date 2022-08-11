using Moq;
using System;

namespace dotValidate.Testing.TypeMatchers
{
    [TypeMatcher]
    public class IsValidationPair<TValidator, TRequest> : ValidationRules<TRequest>, ITypeMatcher
        where TValidator : ValidationRules<TRequest>
    {
        bool ITypeMatcher.Matches(Type typeArgument)
        {
            return typeof(TValidator).IsAssignableFrom(typeArgument);
        }
    }
}
