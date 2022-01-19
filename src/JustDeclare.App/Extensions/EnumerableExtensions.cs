using JustDeclare.Main.ValidationChecks;
using JustDeclare.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace JustDeclare
{
    public static partial class JustDeclareExtensions
    {
        public static ValidationCheck MustNotBeEmpty<T>(this IEnumerable<T> value)
        {
            return new EnumerableCountMinimum<T>(value, 1);
        }

        public static ValidationCheck CountMustBeAtLeast<T>(this IEnumerable<T> value, int minimum)
        {
            return new EnumerableCountMinimum<T>(value, minimum);
        }

        public static ValidationCheck CountMustNoMoreThan<T>(this IEnumerable<T> value, int maximum)
        {
            return new EnumerableCountMaximum<T>(value, maximum);
        }

        public static ValidationCheck CountMustBe<T>(this IEnumerable<T> value, int target)
        {
            return new EnumerableCountEqual<T>(value, target);
        }

        public static ValidationCheck CountMustNotBe<T>(this IEnumerable<T> value, int target)
        {
            return value.CountMustBe(target)
                        .Inverted();
        }

        public static ValidationCheck AllMustObeyTheseRules<T>(this IEnumerable<T> value, params Expression<Func<T, ValidationCheck>>[] rules)
        {
            return new EnumerableRules<T>(value, rules);
        }

        public static ValidationCheck SomeMustObeyTheseRules<T>(this IEnumerable<T> value, params Expression<Func<T, ValidationCheck>>[] rules)
        {
            return new EnumerableRules<T>(value, rules, allMustObey: false);
        }
    }
}