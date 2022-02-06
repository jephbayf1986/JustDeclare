using dotValidate.Main.Conditions;
using System.Collections.Generic;

namespace dotValidate.Conditions
{
    /// <summary>
    /// Condition Chain<br/>
    /// Used for chaining together When(), AndWhen() and Then() conditions.
    /// </summary>
    /// <typeparam name="TValue">Type to run conditions against</typeparam>
    public class ConditionChain<TValue>
    {
        private IList<ValidationCondition<TValue>> _validationConditions;

        internal TValue CarryOverValue { get; set; }

        internal ConditionChain(TValue carryOverValue, ValidationCondition<TValue> firstCondition)
        {
            CarryOverValue = carryOverValue;

            _validationConditions = new List<ValidationCondition<TValue>>()
            {
                firstCondition
            };
        }

        internal bool AllConditionsPassed()
        {
            foreach (var condition in _validationConditions)
            {
                var conditionPassed = condition.Test(CarryOverValue);

                if (!conditionPassed)
                    return false;
            }

            return true;
        }

        internal void AddCondition(ValidationCondition<TValue> condition)
        {
            _validationConditions.Add(condition);
        }
    }
}
