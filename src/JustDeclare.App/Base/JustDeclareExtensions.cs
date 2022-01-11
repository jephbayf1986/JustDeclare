using JustDeclare.Conditions;
using JustDeclare.Main.Conditions;
using JustDeclare.Main.ValidationChecks;
using JustDeclare.Models;
using System;
using System.Linq.Expressions;

namespace JustDeclare.Base
{
    public static class JustDeclareExtensions
    {
        public static NotNullCondition<T> WhenNotNull<T>(this T value)
        {
            return new NotNullCondition<T>(value);
        }

        public static ConditionChain<T> When<T>(this T value, Func<T, bool> condition)
        {
            var customCondition = new ValidationCondition<T>(condition);

            return new ConditionChain<T>(value, customCondition);
        }

        public static ConditionChain<T> AndWhen<T>(this ConditionChain<T> currentConditions, Func<T, bool> condition)
        {
            var customCondition = new ValidationCondition<T>(condition);

            currentConditions.AddCondition(customCondition);

            return currentConditions;
        }

        public static ValidationCheck Then<T>(this ConditionChain<T> currentConditions, Func<T, ValidationCheck> conditionFunc)
        {
            if (!currentConditions.AllConditionsPassed())
                return new DummyTest();

            return conditionFunc(currentConditions.CarryOverValue);
        }

        public static ValidationCheck MustNotBeNull(this object value)
        {
            return new NotNull(value);
        }

        public static ValidationCheck MustNotBeBlank(this string value)
        {
            return new NotBlank(value);
        }

        public static ValidationCheck MustNotBeBlank(this NotNullCondition<string> conditional)
        {
            if (conditional.CarryOverValue == null)
                return new DummyTest();

            return new NotBlank(conditional.CarryOverValue);
        }

        public static ValidationCheck MustNotBeZero<T>(this T value)
            where T : struct, IComparable
        {
            return new NotZero<T>(value);
        }

        public static ValidationCheck MustNotBeZero<T>(this NotNullCondition<T?> conditional)
            where T : struct, IComparable
        {
            if (!conditional.CarryOverValue.HasValue)
                return new DummyTest();

            return new NotZero<T>(conditional.CarryOverValue.Value);
        }

        public static ValidationCheck MustBeNoMoreThan<T>(this T value, T maximum)
            where T : struct, IComparable
        {
            return new NumericMaximum<T>(value, maximum);
        }

        public static ValidationCheck MustBeNoMoreThan<T>(this NotNullCondition<T?> conditional, IComparable maximum)
            where T : struct, IComparable
        {
            if (!conditional.CarryOverValue.HasValue)
                return new DummyTest();

            return new NumericMaximum<T>(conditional.CarryOverValue.Value, maximum);
        }

        public static ValidationCheck MustBeNoLessThan<T>(this T value, T minimum)
            where T : struct, IComparable
        {
            return new NumericMinimum<T>(value, minimum);
        }

        public static ValidationCheck MustBeNoLessThan<T>(this NotNullCondition<T?> conditional, IComparable minimum)
            where T : struct, IComparable
        {
            if (!conditional.CarryOverValue.HasValue)
                return new DummyTest();

            return new NumericMinimum<T>(conditional.CarryOverValue.Value, minimum);
        }

        public static ValidationCheck MustBeNoLongerThan(this string value, int maximumLength)
        {
            return new MaximumLength(value, maximumLength);
        }

        public static ValidationCheck MustBeNoLongerThan(this NotNullCondition<string> conditional, int maximumLength)
        {
            if (conditional.CarryOverValue == null)
                return new DummyTest();

            return new MaximumLength(conditional.CarryOverValue, maximumLength);
        }

        public static ValidationCheck MustBeNoShorterThan(this string value, int minimumLength)
        {
            return new MinimumLength(value, minimumLength);
        }

        public static ValidationCheck MustBeNoShorterThan(this NotNullCondition<string> conditional, int minimumLength)
        {
            if (conditional.CarryOverValue == null)
                return new DummyTest();

            return new MinimumLength(conditional.CarryOverValue, minimumLength);
        }

        public static ValidationCheck MustMatchPattern(this string value, string pattern)
        {
            return new RegexMatch(value, pattern);
        }

        public static ValidationCheck MustMatchPattern(this NotNullCondition<string> conditional, string pattern)
        {
            if (conditional.CarryOverValue == null)
                return new DummyTest();

            return new RegexMatch(conditional.CarryOverValue, pattern);
        }

        public static ValidationCheck DeclareConditions<TSubEntity>(this TSubEntity entity, params Expression<Func<TSubEntity, ValidationCheck>>[] rules)
        {
            return new NestedConditions<TSubEntity>(entity, rules);
        }

        public static ValidationCheck DeclareConditions<TSubEntity>(this NotNullCondition<TSubEntity> conditional, params Expression<Func<TSubEntity, ValidationCheck>>[] rules)
        {
            if (conditional.CarryOverValue == null)
                return new DummyTest();

            return new NestedConditions<TSubEntity>(conditional.CarryOverValue, rules);
        }

        public static T UseCustomMessage<T>(this T test, string message)
            where T : ValidationCheck
        {
            test.SetCustomMessage(message);

            return test;
        }

        public static T EndValidationIfFails<T>(this T test)
            where T : ValidationCheck
        {
            test.StopValidatingOnFailure();

            return test;
        }
    }
}