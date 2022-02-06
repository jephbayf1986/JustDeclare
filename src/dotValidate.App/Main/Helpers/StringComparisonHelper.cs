using dotValidate.Enums;
using System;

namespace dotValidate.Main.Helpers
{
    internal static class StringComparisonHelper
    {
        internal static StringComparison ToStringComparison(this Case caseSensitivity)
            => caseSensitivity == Case.Insensitve ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
    }
}
