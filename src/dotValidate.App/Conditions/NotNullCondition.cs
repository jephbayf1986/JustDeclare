using JustDeclare.Main.ValidationChecks;
using JustDeclare.Models;
using System;

namespace JustDeclare.Conditions
{
    public class NotNullCondition<TValue>
    {
        public NotNullCondition(TValue carryOverValue)
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
