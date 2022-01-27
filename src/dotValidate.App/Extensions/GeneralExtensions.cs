using JustDeclare.Main.ValidationChecks;
using JustDeclare.Models;
using System;
using System.Linq.Expressions;

namespace JustDeclare
{
    public static partial class JustDeclareExtensions
    {
        public static ValidationCheck MustBeNull(this object value)
            => new Null(value);

        public static ValidationCheck MustNotBeNull(this object value)
            => value.MustBeNull()
                    .Inverted();

        public static ValidationCheck MustObeyTheseRules<T>(this T entity, params Expression<Func<T, ValidationCheck>>[] rules)
        {
            return new NestedRules<T>(entity, rules);
        }
    }
}