using JustDeclare.Models;
using System;

namespace JustDeclare.Main.ValidationChecks
{
    internal class DummyTest : ValidationCheck
    {
        protected override string DefaultRuleBreakDescription => throw new NotImplementedException();

        protected override bool GetTestResult()
         => true;
    }
}