﻿using dotValidate.Conditions;
using dotValidate.Main.Conditions;
using dotValidate.Main.ValidationChecks;
using dotValidate.Models;
using System;

namespace dotValidate
{
    /// <summary>
    /// Property Extensions for building Validation Rules with dotValidate
    /// </summary>
    public static partial class PropertyExtensions
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
                return new Dummy();

            return conditionFunc(currentConditions.CarryOverValue);
        }
    }
}