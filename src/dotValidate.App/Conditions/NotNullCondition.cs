using dotValidate.Main.ValidationChecks;
using dotValidate.Models;
using System;

namespace dotValidate.Conditions
{
    /// <summary>
    /// Not Null Condition<br/>
    /// Used for chaining WhenNotNull() condition.
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    public class NotNullCondition<TValue>
    {
        internal NotNullCondition(TValue carryOverValue)
        {
            CarryOverValue = carryOverValue;
        }

        private readonly TValue CarryOverValue;

        internal ValidationCheck CreateValidationCheck(Func<TValue, ValidationCheck> validationCheck)
        {
            if (CarryOverValue == null)
                return new Dummy();

            return validationCheck(CarryOverValue);
        }
    }
}
