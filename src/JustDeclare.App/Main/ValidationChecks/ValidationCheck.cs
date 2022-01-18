using JustDeclare.Models;

namespace JustDeclare.Main.ValidationChecks
{
    internal abstract partial class ValidationCheck<T> : ValidationCheck
    {
        public ValidationCheck(T value)
        {
            ValueProvided = value;
        }

        protected readonly T ValueProvided;
    }
}
