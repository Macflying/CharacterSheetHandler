using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalCSharp.Result
{
    public abstract class Result<TSuccess, TError>
    {
        internal Result()
        { }

        public static implicit operator Result<TSuccess, TError>(TSuccess ok) =>
            Ok<TSuccess, TError>.Value(ok);

        public static implicit operator Result<TSuccess, TError>(TError error) =>
            Error<TSuccess, TError>.Value(error);
    }
}
