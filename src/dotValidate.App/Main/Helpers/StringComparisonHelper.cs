using dotValidate.Models.Enums;
using System;

namespace dotValidate.Main.Helpers
{
    internal static class StringComparisonHelper
    {
        internal static StringComparison ToStringComparison(this MatchCase caseSensitivity)
            => caseSensitivity == MatchCase.Insensitve ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
    }
}
