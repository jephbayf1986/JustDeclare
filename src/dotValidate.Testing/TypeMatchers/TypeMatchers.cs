using Moq;
using System;

namespace dotValidate.Testing.TypeMatchers
{
    [TypeMatcher]
    public class IsAnyValidationRules<T> : ValidationRules<T>, ITypeMatcher
    {
        bool ITypeMatcher.Matches(Type typeArgument)
        {
            return typeof(T).IsAssignableFrom(typeArgument);
        }
    }
}
