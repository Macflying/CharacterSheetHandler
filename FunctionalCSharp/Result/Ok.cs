using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalCSharp.Result
{

    public class Ok<TSuccess, TError> : Result<TSuccess, TError>
    {
        private TSuccess _content;

        public Ok(TSuccess value) => _content = value;

        public static Result<TSuccess, TError> Value(TSuccess ok)
            => new Ok<TSuccess, TError>(ok);

        public static implicit operator TSuccess(Ok<TSuccess, TError> ok)
            => ok._content;
    }
}
