using System;

namespace JustDeclare.Main.Conditions
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