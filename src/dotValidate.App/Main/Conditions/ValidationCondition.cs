using System;

namespace dotValidate.Main.Conditions
{
    internal class ValidationCondition<T>
    {
        public ValidationCondition(Func<T, bool> test)
        {
            Test = test;
        }

        public Func<T, bool> Test { get; private set; }
    }
}