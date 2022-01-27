using dotValidate.Models;
using System;

namespace dotValidate.Main.ValidationChecks
{
    internal class Dummy : ValidationCheck
    {
        protected override string DefaultRuleBreakDescription => throw new NotImplementedException();
        
        protected override bool GetTestResult()
         => true;
    }
}