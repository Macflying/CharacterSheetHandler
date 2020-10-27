
using System;

namespace FunctionalCSharp.Result
{
    /// <summary>
    /// Wrap either a success or an error.
    /// </summary>
    /// <typeparam name="TSuccess">The success' type.</typeparam>
    /// <typeparam name="TError">The error's type.</typeparam>
    public abstract class Result<TSuccess, TError>
    {
        internal Result()
        { }

        /// <summary>
        /// Map the wrapped value if it is <see cref="Ok{TSuccess, TError}"/>, does nothing otherwise.
        /// </summary>
        /// <typeparam name="TNewSuccess">Value's wrapped type after the map operation.</typeparam>
        /// <param name="map">The operation to map the value from <typeparamref name="TSuccess"/> to <typeparamref name="TNewSuccess"/>.</param>
        public abstract Result<TNewSuccess, TError> Map<TNewSuccess>(Func<TSuccess, TNewSuccess> map);

        /// <summary>
        /// Will return <see cref="Ok{TSuccess, TError}"/> if current <see cref="Result{TSuccess, TError}"/> is <see cref="Ok{TSuccess, TError}"/> and the wrapped value passes the <paramref name="predicate"/>.
        /// If <see cref="Ok{TSuccess, TError}"/> wrapped value won't pass the <paramref name="predicate"/> then returns an <see cref="Error{TSuccess, TError}"/> with <paramref name="error"/> as a wrapped value.
        /// If <see cref="Result{TSuccess, TError}"/> is <see cref="Error{TSuccess, TError}"/> then returns it.
        /// </summary>
        /// <param name="predicate">The predicate to apply to the wrapped value if <see cref="Result{TSuccess, TError}"/> is <see cref="Ok{TSuccess, TError}"/>.</param>
        /// <param name="error">The error to wrap if <see cref="Ok{TSuccess, TError}"/> wrapped value won't pass the <paramref name="predicate"/>.</param>
        public abstract Result<TSuccess, TError> When(Predicate<TSuccess> predicate, TError error);

        /// <summary>
        /// Will return <see cref="Ok{TSuccess, TError}"/> if current <see cref="Result{TSuccess, TError}"/> is <see cref="Ok{TSuccess, TError}"/> and the wrapped value passes the <paramref name="predicate"/>.
        /// If <see cref="Ok{TSuccess, TError}"/> wrapped value won't pass the <paramref name="predicate"/> then returns an <see cref="Error{TSuccess, TError}"/> with <paramref name="error"/> as a wrapped value.
        /// If <see cref="Result{TSuccess, TError}"/> is <see cref="Error{TSuccess, TError}"/> then returns it.
        /// </summary>
        /// <param name="predicate">The predicate to apply to the wrapped value if <see cref="Result{TSuccess, TError}"/> is <see cref="Ok{TSuccess, TError}"/>.</param>
        /// <param name="error">The error to wrap if <see cref="Ok{TSuccess, TError}"/> wrapped value won't pass the <paramref name="predicate"/>.</param>
        public abstract Result<TSuccess, TError> When(Predicate<TSuccess> predicate, Func<TSuccess, TError> error);

        /// <summary>
        /// Map the wrapped value if it is <see cref="Error{TSuccess, TError}"/>, does nothing otherwise.
        /// </summary>
        /// <typeparam name="TNewError">Error's wrapped type after the map operation.</typeparam>
        /// <param name="mapError">The operation to map the value from <typeparamref name="TError"/> to <typeparamref name="TNewError"/>.</param>
        /// <exception cref="ArgumentNullException"/>
        public abstract Result<TSuccess, TNewError> MapError<TNewError>(Func<TError, TNewError> mapError);

        /// <summary>
        /// Reduce a <see cref="Result{TSuccess, TError}"/> to the wrapped type if it is <see cref="Ok{TSuccess, TError}"/>, to <paramref name="whenError"/> if it is <see cref="Error{TSuccess, TError}"/>.
        /// </summary>
        /// <param name="whenError">The value to return if the result is <see cref="Ok{TSuccess, TError}"/>.</param>
        public abstract TSuccess Reduce(TSuccess whenError);

        /// <summary>
        /// Reduce a <see cref="Result{TSuccess, TError}"/> to the wrapped type if it is <see cref="Ok{TSuccess, TError}"/>, to <paramref name="whenError"/> if it is <see cref="Error{TSuccess, TError}"/>.
        /// </summary>
        /// <param name="whenError">The operation returning the value to return if the result is <see cref="Ok{TSuccess, TError}"/>. This operation is executed only if result is <see cref="Error{TSuccess, TError}"/>.</param>
        /// <exception cref="ArgumentNullException"/>
        public abstract TSuccess Reduce(Func<TError, TSuccess> whenError);

        /// <summary>
        /// Reduce a <see cref="Result{TSuccess, TError}"/> to the wrapped type if it is <see cref="Error{TSuccess, TError}"/>, to <paramref name="whenOk"/> if it is <see cref="Ok{TSuccess, TError}"/>.
        /// </summary>
        /// <param name="whenError">The value to return if the result is <see cref="Error{TSuccess, TError}"/>.</param>
        public abstract TError ReduceError(TError whenOk);

        /// <summary>
        /// Reduce a <see cref="Result{TSuccess, TError}"/> to the wrapped type if it is <see cref="Error{TSuccess, TError}"/>, to <paramref name="whenOk"/> if it is <see cref="Ok{TSuccess, TError}"/>.
        /// </summary>
        /// <param name="whenOk">The operation returning the value to return if the result is <see cref="Ok{TSuccess, TError}"/>. This operation is executed only if result is <see cref="Ok{TSuccess, TError}"/>.</param>
        /// <exception cref="ArgumentNullException"/>
        public abstract TError ReduceError(Func<TSuccess, TError> whenOk);

        public static implicit operator Result<TSuccess, TError>(TSuccess ok)
        {
            return Ok<TSuccess, TError>.Value(ok);
        }

        public static implicit operator Result<TSuccess, TError>(TError error)
        {
            return Error<TSuccess, TError>.Value(error);
        }
    }
}
