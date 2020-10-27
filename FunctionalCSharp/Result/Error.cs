
using System;

using FunctionalCSharp.Option;

namespace FunctionalCSharp.Result
{
    /// <summary>
    /// Wrap an Error.
    /// </summary>
    /// <typeparam name="TSuccess">The success' type.</typeparam>
    /// <typeparam name="TError">The error's type.</typeparam>
    public class Error<TSuccess, TError> : Result<TSuccess, TError>
    {
        private TError _content;

        private Error(TError value)
        {
            if (value is null)
                throw new ArgumentNullException(nameof(value), $"{nameof(Error<TSuccess, TError>)} value shouldn't be null. Consider using {nameof(None<TSuccess>)} to represent an absence of value.");

            _content = value;
        }

        /// <summary>
        /// Create an Error represented by <paramref name="error"/> value.
        /// </summary>
        /// <param name="error">The error's representation.</param>
        public static Result<TSuccess, TError> Value(TError error)
            => new Error<TSuccess, TError>(error);

        public override Result<TNewSuccess, TError> Map<TNewSuccess>(Func<TSuccess, TNewSuccess> map)
        {
            if (map is null)
                throw new ArgumentNullException(nameof(map));

            return new Error<TNewSuccess, TError>(_content);
        }

        public override Result<TSuccess, TError> When(Predicate<TSuccess> predicate, TError error)
        {
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));

            if (error is null)
                throw new ArgumentNullException(nameof(error));

            return this;
        }

        public override Result<TSuccess, TError> When(Predicate<TSuccess> predicate, Func<TSuccess, TError> error)
        {
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));

            if (error is null)
                throw new ArgumentNullException(nameof(error));

            return this;
        }

        public override Result<TSuccess, TNewError> MapError<TNewError>(Func<TError, TNewError> mapError)
        {
            if (mapError is null)
                throw new ArgumentNullException(nameof(mapError));

            return new Error<TSuccess, TNewError>(mapError(_content));
        }

        public override TSuccess Reduce(TSuccess whenError) => whenError;

        public override TSuccess Reduce(Func<TError, TSuccess> whenError)
        {
            if (whenError is null)
                throw new ArgumentNullException(nameof(whenError));

            return whenError(_content);
        }

        public override TError ReduceError(TError whenOk) => _content;

        public override TError ReduceError(Func<TSuccess, TError> whenOk)
        {
            if (whenOk is null)
                throw new ArgumentNullException(nameof(whenOk));

            return _content;
        }

        public static implicit operator TError(Error<TSuccess, TError> error)
            => error._content;
    }
}
