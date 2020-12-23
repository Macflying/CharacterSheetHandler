using System;
using System.Threading;

namespace FunctionalCSharp.Option
{
    /// <summary>
    /// Represent the absence of a value.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class None<T> : Option<T>
    {
        internal None()
        { }

        public override Option<TResult> Map<TResult>(Func<T, TResult> map)
        {
            if (map is null)
                throw new ArgumentNullException(nameof(map));

            return None.Value;
        }

        public override void WhenSome(Action<T> doThat)
        {
            if (doThat is null)
                throw new ArgumentNullException(nameof(doThat));
        }

        public override T Reduce(T whenNone) => whenNone;

        public override T Reduce(Func<T> whenNone)
        {
            if (whenNone is null)
                throw new ArgumentNullException(nameof(whenNone));

            return whenNone();
        }

        public override Option<T> When(Predicate<T> predicate)
        {
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));

            return this;
        }
    }

    /// <summary>
    /// Helper class to create None value whithout having to specify type.
    /// </summary>
    public class None
    {
        /// <summary>
        /// None value that can implicitly be converted to <see cref="None{T}"/>.
        /// </summary>
        public static None Value { get; } = new None();

        private None()
        {
        }
    }
}