using System;
using System.Collections.Generic;
using System.Text;

using FunctionalCSharp.Option;

namespace FunctionalCSharp.Result
{
    /// <summary>
    /// Wrap a success.
    /// </summary>
    /// <typeparam name="TSuccess">The success' type.</typeparam>
    /// <typeparam name="TError">The error's type.</typeparam>
    public class Ok<TSuccess, TError> : Result<TSuccess, TError>
    {
        private readonly TSuccess _content;

        private Ok(TSuccess value)
        {
            if (value is null)
                throw new ArgumentNullException(nameof(value), $"{nameof(Ok<TSuccess, TError>)} value shouldn't be null. Consider using {nameof(None<TSuccess>)} to represent an absence of value.");

            _content = value;
        }

        public static Result<TSuccess, TError> Value(TSuccess ok) => new Ok<TSuccess, TError>(ok);

        public override Result<TNewSuccess, TError> Map<TNewSuccess>(Func<TSuccess, TNewSuccess> map)
        {
            if (map is null)
                throw new ArgumentNullException(nameof(map));

            return new Ok<TNewSuccess, TError>(map(_content));
        }

        public override Result<TSuccess, TError> When(Predicate<TSuccess> predicate, TError error)
        {
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));

            if (error is null)
                throw new ArgumentNullException(nameof(error));

            return predicate(_content) ? this : Error<TSuccess, TError>.Value(error);
        }

        public override Result<TSuccess, TError> When(Predicate<TSuccess> predicate, Func<TSuccess, TError> error)
        {
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));

            if (error is null)
                throw new ArgumentNullException(nameof(error));

            return predicate(_content) ? this : Error<TSuccess, TError>.Value(error(_content));
        }

        public override Result<TSuccess, TNewError> MapError<TNewError>(Func<TError, TNewError> mapError)
        {
            if (mapError is null)
                throw new ArgumentNullException(nameof(mapError));

            return new Ok<TSuccess, TNewError>(_content);
        }

        public override TSuccess Reduce(TSuccess whenError) => _content;

        public override TSuccess Reduce(Func<TError, TSuccess> whenError)
        {
            if (whenError is null)
                throw new ArgumentNullException(nameof(whenError));

            return _content;
        }

        public override TError ReduceError(TError whenOk) => whenOk;

        public override TError ReduceError(Func<TSuccess, TError> whenOk)
        {
            if (whenOk is null)
                throw new ArgumentNullException(nameof(whenOk));

            return whenOk(_content);
        }

        public static implicit operator TSuccess(Ok<TSuccess, TError> ok)
            => ok._content;
    }
}
