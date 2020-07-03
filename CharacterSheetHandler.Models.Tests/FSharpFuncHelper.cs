using Microsoft.FSharp.Core;

using System;

namespace CharacterSheetHandler.Models.Tests
{
    public static class FSharpFuncHelper
    {
        public static FSharpFunc<T1, FSharpFunc<T2, TResult>> Create<T1, T2, TResult>(Func<T1, T2, TResult> func)
        {
            Converter<T1, FSharpFunc<T2, TResult>> conv = value1 =>
            {
                return Create<T2, TResult>(value2 => func(value1, value2));
            };
            return FSharpFunc<T1, FSharpFunc<T2, TResult>>.FromConverter(conv);
        }

        private static FSharpFunc<T1, TResult> Create<T1, TResult>(Func<T1, TResult> fun)
        {
            return FSharpFunc<T1, TResult>.FromConverter(new Converter<T1, TResult>(fun));
        }
    }
}
