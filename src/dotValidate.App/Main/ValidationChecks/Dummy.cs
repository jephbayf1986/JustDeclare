using dotValidate.Models;
using System;

namespace dotValidate.Main.ValidationChecks
{
    internal class Dummy : ValidationCheck
    {
        protected internal override string DefaultRuleBreakDescription => throw new NotImplementedException();

        protected internal override bool GetTestResult()
         => true;
    }
}