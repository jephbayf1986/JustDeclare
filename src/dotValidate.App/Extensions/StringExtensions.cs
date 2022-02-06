using dotValidate.Enums;
using dotValidate.Main.ValidationChecks;
using dotValidate.Models;
using System;

namespace dotValidate
{
    public static partial class JustDeclareExtensions
    {
        public static ValidationCheck MustBe(this string value, string target)
        {
            return new StringEqual(value, target);
        }

        public static ValidationCheck MustBe(this string value, string target, Case matchCase)
        {
            return new StringEqual(value, target, matchCase);
        }

        public static ValidationCheck MustNotBe(this string value, string target)
        {
            return value.MustBe(target)
                        .Inverted();
        }

        public static ValidationCheck MustNotBe(this string value, string target, Case matchCase)
        {
            return value.MustBe(target, matchCase)
                        .Inverted();
        }

        public static ValidationCheck MustNotBeBlank(this string value)
        {
            return value.MustBeBlank()
                        .Inverted();
        }

        public static ValidationCheck MustBeBlank(this string value)
        {
            return new StringBlank(value);
        }

        public static ValidationCheck MustBeNoLongerThan(this string value, int maximumLength)
        {
            return new StringMaximumLength(value, maximumLength);
        }

        public static ValidationCheck MustBeNoShorterThan(this string value, int minimumLength)
        {
            return new StringMinimumLength(value, minimumLength);
        }

        public static ValidationCheck MustContain(this string value, string target)
        {
            return new StringContains(value, target);
        }

        public static ValidationCheck MustContain(this string value, string target, Case matchCase)
        {
            return new StringContains(value, target, matchCase);
        }
        public static ValidationCheck MustNotContain(this string value, string target)
        {
            return value.MustContain(target)
                        .Inverted();
        }

        public static ValidationCheck MustNotContain(this string value, string target, Case matchCase)
        {
            return value.MustContain(target, matchCase)
                        .Inverted();
        }

        public static ValidationCheck MustStartWith(this string value, string target)
        {
            return new StringStartsWith(value, target);
        }

        public static ValidationCheck MustStartWith(this string value, string target, Case matchCase)
        {
            return new StringStartsWith(value, target, matchCase);
        }
        public static ValidationCheck MustNotStartWith(this string value, string target)
        {
            return value.MustStartWith(target)
                        .Inverted();
        }

        public static ValidationCheck MustNotStartWith(this string value, string target, Case matchCase)
        {
            return value.MustStartWith(target, matchCase)
                        .Inverted();
        }

        public static ValidationCheck MustEndWith(this string value, string target)
        {
            return new StringEndsWith(value, target);
        }

        public static ValidationCheck MustEndWith(this string value, string target, Case matchCase)
        {
            return new StringEndsWith(value, target, matchCase);
        }

        public static ValidationCheck MustNotEndWith(this string value, string target)
        {
            return value.MustEndWith(target)
                        .Inverted();
        }

        public static ValidationCheck MustNotEndWith(this string value, string target, Case matchCase)
        {
            return value.MustEndWith(target, matchCase)
                        .Inverted();
        }

        public static ValidationCheck MustMatchPattern(this string value, string pattern)
        {
            return new StringRegexMatch(value, pattern);
        }

        public static ValidationCheck MustNotMatchPattern(this string value, string pattern)
        {
            return value.MustMatchPattern(pattern)
                        .Inverted();
        }

        private static ValidationCheck MustBeAnEmailAddress(this string value)
        {
            throw new NotImplementedException();
        }
    }
}