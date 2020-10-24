using System;

namespace FunctionalCSharp.Option
{
    public static class OptionExtension
    {
        /// <summary>
        /// Map the wrapped value if it exists, does nothing if it doesn't.
        /// </summary>
        /// <typeparam name="T">Value's wrapped type before the map operation.</typeparam>
        /// <typeparam name="TResult">Value's wrapped type after the map operation.</typeparam>
        /// <param name="option">The option to map.</param>
        /// <param name="map">The operation to map the value from <typeparamref name="T"/> to <typeparamref name="TResult"/>.</param>
        public static Option<TResult> Map<T, TResult>(this Option<T> option, Func<T, TResult> map) =>
            option is Some<T> some ? (Option<TResult>)map(some) : None.Value;

        /// <summary>
        /// Filter the <paramref name="value"/> with a <paramref name="predicate"/>.
        /// Will return <see cref="Some{T}"/> if the value passes the predicate, <see cref="None{T}"/> otherwise.
        /// </summary>
        /// <typeparam name="T">Value's wrapped type.</typeparam>
        /// <param name="value">The value to filter.</param>
        /// <param name="predicate">The operation to filter the value. If it returns true then <see cref="Some{T}"/> is returned, <see cref="None{T}"/> otherwise.</param>
        public static Option<T> When<T>(this T value, Func<T, bool> predicate) =>
            predicate(value) ? (Option<T>)value : None.Value;

        /// <summary>
        /// Reduce an <see cref="Option{T}"/> to the wrapped type if it exists, to <paramref name="whenNone"/> if it doesn't.
        /// </summary>
        /// <typeparam name="T">Value's wrapped type.</typeparam>
        /// <param name="option">The option to reduce.</param>
        /// <param name="whenNone">The value to return if the option is <see cref="None{T}"/>.</param>
        public static T Reduce<T>(this Option<T> option, T whenNone) =>
            option is Some<T> some ? (T)some : whenNone;

        /// <summary>
        /// Reduce an <see cref="Option{T}"/> to the wrapped type if it exists, to <paramref name="whenNone"/> if it doesn't.
        /// </summary>
        /// <typeparam name="T">Value's wrapped type.</typeparam>
        /// <param name="option">The option to reduce.</param>
        /// <param name="whenNone">The operation returning the value to return if the option is <see cref="None{T}"/>. This operation is executed only if option is <see cref="None{T}"/>.</param>
        public static T Reduce<T>(this Option<T> option, Func<T> whenNone) =>
            option is Some<T> some ? (T)some : whenNone();
    }
}
