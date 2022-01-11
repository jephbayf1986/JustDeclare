namespace JustDeclare.Conditions
{
    public class NotNullCondition<TValue>
    {
        public NotNullCondition(TValue carryOverValue)
        {
            CarryOverValue = carryOverValue;
        }

        public TValue CarryOverValue { get; private set; }
    }
}
