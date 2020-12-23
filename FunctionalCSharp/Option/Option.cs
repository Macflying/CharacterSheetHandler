using System;

namespace FunctionalCSharp.Option
{
    /// <summary>
    /// Wraper that may represent an object if it exists as <see cref="Some{T}"/>, will be <see cref="None{T}"/> if the object doesn't exist.
    /// </summary>
    /// <typeparam name="T">The type of the value if it exists.</typeparam>
    public abstract class Option<T>
    {
        protected Option()
        { }

        /// <summary>
        /// Map the wrapped value if it exists, does nothing if it doesn't.
        /// </summary>
        /// <typeparam name="TResult">Value's wrapped type after the map operation.</typeparam>
        /// <param name="map">The operation to map the value from <typeparamref name="T"/> to <typeparamref name="TResult"/>.</param>
        /// <exception cref="ArgumentNullException"/>
        public abstract Option<TResult> Map<TResult>(Func<T, TResult> map);

        public abstract Option<T> When(Predicate<T> predicate);

        /// <summary>
        /// Execute an operation on wrapped value if <see cref="Option{T}"/> is <see cref="Some{T}"/>. Do nothing otherwise.
        /// </summary>
        /// <param name="doThat">The operation to execute if <see cref="Option{T}"/> is <see cref="Some{T}"/>.</param>
        /// <exception cref="ArgumentNullException"/>
        public abstract void WhenSome(Action<T> doThat);

        /// <summary>
        /// Reduce an <see cref="Option{T}"/> to the wrapped type if it exists, to <paramref name="whenNone"/> if it doesn't.
        /// </summary>
        /// <param name="whenNone">The value to return if the option is <see cref="None{T}"/>.</param>
        public abstract T Reduce(T whenNone);

        /// <summary>
        /// Reduce an <see cref="Option{T}"/> to the wrapped type if it exists, to <paramref name="whenNone"/> if it doesn't.
        /// </summary>
        /// <param name="whenNone">The operation returning the value to return if the option is <see cref="None{T}"/>. This operation is executed only if option is <see cref="None{T}"/>.</param>
        /// <exception cref="ArgumentNullException"/>
        public abstract T Reduce(Func<T> whenNone);

        public static implicit operator Option<T>(T value)
        {
            return Some<T>.Value(value);
        }

#pragma warning disable IDE0060 // Remove unused parameter -> This is synctactic sugar to avoid specifying type when creating None where type should be obvious.

        public static implicit operator Option<T>(None none)
#pragma warning restore IDE0060 // Remove unused parameter
        {
            if (none is null)
                throw new ArgumentNullException(nameof(none));
            return new None<T>();
        }
    }
}