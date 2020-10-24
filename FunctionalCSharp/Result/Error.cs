using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalCSharp.Result
{
    public class Error<TSuccess, TError> : Result<TSuccess, TError>
    {
        private TError _content;

        public Error(TError value) => _content = value;

        public static Result<TSuccess, TError> Value(TError error)
            => new Error<TSuccess, TError>(error);

        public static implicit operator TError(Error<TSuccess, TError> error)
            => error._content;
    }
}
