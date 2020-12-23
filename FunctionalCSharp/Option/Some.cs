using System;

namespace FunctionalCSharp.Option
{
    /// <summary>
    /// Wrap an existing value.
    /// </summary>
    /// <typeparam name="T">The value's type.</typeparam>
    public class Some<T> : Option<T>
    {
        /// <summary>
        /// The contained value.
        /// </summary>
        private readonly T _content;

        private Some(T content) => _content = content;

        /// <summary>
        /// Create Some if the <paramref name="value"/> is not null, will returns None if it dopesn't.
        /// </summary>
        /// <param name="value">The value to wrap.</param>
        public static Option<T> Value(T value)
        {
            if (value is null)
                return None.Value;

            return new Some<T>(value);
        }

        public override Option<TResult> Map<TResult>(Func<T, TResult> map)
        {
            if (map is null)
                throw new ArgumentNullException(nameof(map));

            return Some<TResult>.Value(map(_content));
        }

        public override void WhenSome(Action<T> doThat)
        {
            if (doThat is null)
                throw new ArgumentNullException(nameof(doThat));

            doThat(_content);
        }

        public override T Reduce(T whenNone) => _content;

        public override T Reduce(Func<T> whenNone)
        {
            if (whenNone is null)
                throw new ArgumentNullException(nameof(whenNone));

            return _content;
        }

        public override Option<T> When(Predicate<T> predicate)
        {
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));

            if (predicate(_content))
                return this;
            return None.Value;
        }

        public static implicit operator T(Some<T> value) =>
            value._content;
    }
}