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
        public T Content { get; }

        private Some(T content) => Content = content;

        /// <summary>
        /// Create Some if the value exists, will returns None if it dopesn't.
        /// </summary>
        /// <param name="value">The value to wrap.</param>
        public static Option<T> Value(T value)
        {
            if (value != null)
                return new Some<T>(value);
            return None.Value;
        }

        public static implicit operator T(Some<T> value) =>
            value.Content;
    }
}