using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalCSharp.Result
{
    public static class ResultExtension
    {
        /// <summary>
        /// Map the wrapped value if it is <see cref="Ok{TSuccess, TError}"/>, does nothing otherwise.
        /// </summary>
        /// <typeparam name="TSuccess">Value's type before the map operation.</typeparam>
        /// <typeparam name="TError">Error's wrapped type.</typeparam>
        /// <typeparam name="TNewSuccess">Value's wrapped type after the map operation.</typeparam>
        /// <param name="result">The result to map.</param>
        /// <param name="map">The operation to map the value from <typeparamref name="TSuccess"/> to <typeparamref name="TNewSuccess"/>.</param>
        public static Result<TNewSuccess, TError> Map<TSuccess, TError, TNewSuccess>(this Result<TSuccess, TError> result, Func<TSuccess, TNewSuccess> map) =>
            result is Ok<TSuccess, TError> ok ? map(ok) : Error<TNewSuccess, TError>.Value((Error<TSuccess, TError>)result);

        /// <summary>
        /// Map the wrapped value if it is <see cref="Error{TSuccess, TError}"/>, does nothing otherwise.
        /// </summary>
        /// <typeparam name="TSuccess">Value's type before the map operation.</typeparam>
        /// <typeparam name="TError">Error's wrapped type.</typeparam>
        /// <typeparam name="TNewError">Error's wrapped type after the map operation.</typeparam>
        /// <param name="result">The result to map.</param>
        /// <param name="mapError">The operation to map the value from <typeparamref name="TError"/> to <typeparamref name="TNewError"/>.</param>
        public static Result<TSuccess, TNewError> MapError<TSuccess, TError, TNewError>(this Result<TSuccess, TError> result, Func<TError, TNewError> mapError) =>
            result is Error<TSuccess, TError> error ? mapError(error) : Ok<TSuccess, TNewError>.Value((Ok<TSuccess, TError>)result);

        /// <summary>
        /// Filter the <paramref name="value"/> with a <paramref name="predicate"/>.
        /// Will return <see cref="Ok{TSuccess, TError}"/> if the value passes the predicate, <see cref="Error{TSuccess, TError}"/> wrapping <paramref name="error"/> otherwise.
        /// </summary>
        /// <typeparam name="TSuccess">Value's wrapped type.</typeparam>
        /// <typeparam name="TError">Error's wrapped type.</typeparam>
        /// <param name="value">The value to filter.</param>
        /// <param name="predicate">The operation to filter the value. If it returns true then <see cref="Ok{TSuccess, TError}"/> is returned, <see cref="Error{TSuccess, TError}"/> otherwise.</param>
        /// <param name="error">The error to wrap if the <paramref name="value"/> doesn't pass the <paramref name="predicate"/>.</param>
        public static Result<TSuccess, TError> When<TSuccess, TError>(this TSuccess value, Func<TSuccess, bool> predicate, TError error) =>
            predicate(value) ? value : Error<TSuccess, TError>.Value(error);

        /// <summary>
        /// Filter the <paramref name="value"/> with a <paramref name="predicate"/>.
        /// Will return <see cref="Ok{TSuccess, TError}"/> if the value passes the predicate, <see cref="Error{TSuccess, TError}"/> wrapping <paramref name="error"/> otherwise.
        /// </summary>
        /// <typeparam name="TSuccess">Value's wrapped type.</typeparam>
        /// <typeparam name="TError">Error's wrapped type.</typeparam>
        /// <param name="value">The value to filter.</param>
        /// <param name="predicate">The operation to filter the value. If it returns true then <see cref="Ok{TSuccess, TError}"/> is returned, <see cref="Error{TSuccess, TError}"/> otherwise.</param>
        /// <param name="error">The operation returning he error to wrap if the <paramref name="value"/> doesn't pass the <paramref name="predicate"/>.</param>
        public static Result<TSuccess, TError> When<TSuccess, TError>(this TSuccess value, Func<TSuccess, bool> predicate, Func<TSuccess, TError> error) =>
            predicate(value) ? value : Error<TSuccess, TError>.Value(error(value));

        /// <summary>
        /// Reduce a <see cref="Result{TSuccess, TError}"/> to the wrapped type if it is <see cref="Ok{TSuccess, TError}"/>, to <paramref name="whenError"/> if it is <see cref="Error{TSuccess, TError}"/>.
        /// </summary>
        /// <typeparam name="TSuccess">Value's wrapped type.</typeparam>
        /// <typeparam name="TError">Error's wrapped type.</typeparam>
        /// <param name="result">The result to reduce.</param>
        /// <param name="whenError">The value to return if the result is <see cref="Ok{TSuccess, TError}"/>.</param>
        public static TSuccess Reduce<TSuccess, TError>(this Result<TSuccess, TError> result, TSuccess whenError) =>
            result is Ok<TSuccess, TError> ok ? ok : whenError;

        /// <summary>
        /// Reduce a <see cref="Result{TSuccess, TError}"/> to the wrapped type if it is <see cref="Ok{TSuccess, TError}"/>, to <paramref name="whenError"/> if it is <see cref="Error{TSuccess, TError}"/>.
        /// </summary>
        /// <typeparam name="TSuccess">Value's wrapped type.</typeparam>
        /// <typeparam name="TError">Error's wrapped type.</typeparam>
        /// <param name="result">The result to reduce.</param>
        /// <param name="whenError">The operation returning the value to return if the result is <see cref="Ok{TSuccess, TError}"/>. This operation is executed only if result is <see cref="Error{TSuccess, TError}"/>.</param>
        public static TSuccess Reduce<TSuccess, TError>(this Result<TSuccess, TError> result, Func<TError, TSuccess> whenError) =>
            result is Ok<TSuccess, TError> ok ? ok : whenError((Error<TSuccess, TError>)result);

        /// <summary>
        /// Reduce a <see cref="Result{TSuccess, TError}"/> to the wrapped type if it is <see cref="Error{TSuccess, TError}"/>, to <paramref name="whenOk"/> if it is <see cref="Ok{TSuccess, TError}"/>.
        /// </summary>
        /// <typeparam name="TSuccess">Value's wrapped type.</typeparam>
        /// <typeparam name="TError">Error's wrapped type.</typeparam>
        /// <param name="result">The result to reduce.</param>
        /// <param name="whenError">The value to return if the result is <see cref="Error{TSuccess, TError}"/>.</param>
        public static TError ReduceError<TSuccess, TError>(this Result<TSuccess, TError> result, TError whenOk) =>
            result is Error<TSuccess, TError> error ? error : whenOk;

        /// <summary>
        /// Reduce a <see cref="Result{TSuccess, TError}"/> to the wrapped type if it is <see cref="Error{TSuccess, TError}"/>, to <paramref name="whenOk"/> if it is <see cref="Ok{TSuccess, TError}"/>.
        /// </summary>
        /// <typeparam name="TSuccess">Value's wrapped type.</typeparam>
        /// <typeparam name="TError">Error's wrapped type.</typeparam>
        /// <param name="result">The result to reduce.</param>
        /// <param name="whenOk">The operation returning the value to return if the result is <see cref="Ok{TSuccess, TError}"/>. This operation is executed only if result is <see cref="Ok{TSuccess, TError}"/>.</param>
        public static TError ReduceError<TSuccess, TError>(this Result<TSuccess, TError> result, Func<TSuccess, TError> whenOk) =>
            result is Error<TSuccess, TError> error ? error : whenOk((Ok<TSuccess, TError>)result);
    }
}
