using dotValidate.Models;

namespace dotValidate.Main.ValidationChecks
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
