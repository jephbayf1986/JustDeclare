using Moq;
using System;

namespace dotValidate.Testing.TypeMatchers
{
    [TypeMatcher]
    public class IsAnyValidationRules<T> : ValidationRules<T>, ITypeMatcher
    {
        bool ITypeMatcher.Matches(Type typeArgument)
        {
            if (typeArgument.BaseType != typeof(ValidationRules<T>))
                return false;

            if (typeArgument.GenericTypeArguments.Length != 1)
                return false;

            return typeof(T).IsAssignableFrom(typeArgument.GenericTypeArguments[0]);
        }
    }
}
