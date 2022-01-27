using JustDeclare.Models;
using System;

namespace JustDeclare.Main.Models
{
    internal class ValidationTestContainer<TInput>
    {
        public string PropertyName { get; set; }

        public Func<TInput, ValidationCheck> CreateTest { get; set; }
    }
}