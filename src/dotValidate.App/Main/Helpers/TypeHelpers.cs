using System;

namespace dotValidate.Main.Helpers
{
    internal static class TypeHelpers
    {
        public static bool TryChangeType<TIn, TOut>(this TIn input, out TOut output)
            where TIn : struct, IConvertible
            where TOut : struct
        {
            output = default(TOut);

            try
            {
                output = (TOut)Convert.ChangeType(input, typeof(TOut));

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}