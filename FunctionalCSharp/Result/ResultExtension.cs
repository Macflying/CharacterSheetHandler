using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalCSharp.Result
{
    public static class ResultExtension
    {
        /// <summary>
        /// Filter the <paramref name="value"/> with a <paramref name="predicate"/>.
        /// Will return <see cref="Ok{TSuccess, TError}"/> if the value passes the predicate, <see cref="Error{TSuccess, TError}"/> wrapping <paramref name="error"/> otherwise.
        /// </summary>
        /// <typeparam name="TSuccess">Value's wrapped type.</typeparam>
        /// <typeparam name="TError">Error's wrapped type.</typeparam>
        /// <param name="value">The value to filter.</param>
        /// <param name="predicate">The operation to filter the value. If it returns true then <see cref="Ok{TSuccess, TError}"/> is returned, <see cref="Error{TSuccess, TError}"/> otherwise.</param>
        /// <param name="error">The error to wrap if the <paramref name="value"/> doesn't pass the <paramref name="predicate"/>.</param>
        public static Result<TSuccess, TError> OkWhen<TSuccess, TError>(this TSuccess value, Predicate<TSuccess> predicate, TError error)
        {
            if (value is null)
                throw new ArgumentNullException(nameof(value));

            if (error is null)
                throw new ArgumentNullException(nameof(error));

            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));

            return predicate(value) ? value : Error<TSuccess, TError>.Value(error);
        }

        /// <summary>
        /// Filter the <paramref name="value"/> with a <paramref name="predicate"/>.
        /// Will return <see cref="Ok{TSuccess, TError}"/> if the value passes the predicate, <see cref="Error{TSuccess, TError}"/> wrapping <paramref name="error"/> otherwise.
        /// </summary>
        /// <typeparam name="TSuccess">Value's wrapped type.</typeparam>
        /// <typeparam name="TError">Error's wrapped type.</typeparam>
        /// <param name="value">The value to filter.</param>
        /// <param name="predicate">The operation to filter the value. If it returns true then <see cref="Ok{TSuccess, TError}"/> is returned, <see cref="Error{TSuccess, TError}"/> otherwise.</param>
        /// <param name="error">The operation returning he error to wrap if the <paramref name="value"/> doesn't pass the <paramref name="predicate"/>.</param>
        public static Result<TSuccess, TError> OkWhen<TSuccess, TError>(this TSuccess value, Predicate<TSuccess> predicate, Func<TSuccess, TError> error)
        {
            if (value is null)
                throw new ArgumentNullException(nameof(value));

            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));

            if (error is null)
                throw new ArgumentNullException(nameof(error));

            return predicate(value) ? value : Error<TSuccess, TError>.Value(error(value));
        }
    }
}
