using JustDeclare.Models.Enums;
using System;

namespace JustDeclare.Main.Helpers
{
    internal static class StringComparisonHelper
    {
        internal static StringComparison ToStringComparison(this MatchCase caseSensitivity)
            => caseSensitivity == MatchCase.Insensitve ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
    }
}
