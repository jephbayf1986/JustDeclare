using JustDeclare.Main.Conditions;
using System.Collections.Generic;

namespace JustDeclare.Conditions
{
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
