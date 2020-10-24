using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalCSharp.Result
{
    /// <summary>
    /// Wrap a success.
    /// </summary>
    /// <typeparam name="TSuccess">The success' type.</typeparam>
    /// <typeparam name="TError">The error's type.</typeparam>
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
