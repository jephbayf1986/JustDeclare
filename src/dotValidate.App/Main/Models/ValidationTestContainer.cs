using dotValidate.Models;
using System;

namespace dotValidate.Main.Models
{
    internal class ValidationTestContainer<TInput>
    {
        public string PropertyName { get; set; }

        public Func<TInput, ValidationCheck> CreateTest { get; set; }
    }
}