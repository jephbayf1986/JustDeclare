using System;

namespace dotValidate.Main.Helpers
{
    internal static class TypeHelpers
    {
        public static bool TryChangeType<TIn, TOut>(this TIn input, out TOut output, bool exact = true)
            where TIn : struct
            where TOut : struct
        {
            output = default(TOut);

            try
            {
                output = input.ChangeType<TIn, TOut>();

                return !exact || input.Equals(output.ChangeType<TOut, TIn>());
            }
            catch
            {
                return false;
            }
        }

        private static TOut ChangeType<TIn, TOut>(this TIn input)
            where TIn : struct
            where TOut : struct
        {
            return (TOut)Convert.ChangeType(input, typeof(TOut));
        }
    }
}