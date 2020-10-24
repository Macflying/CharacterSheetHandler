namespace FunctionalCSharp.Option
{
    /// <summary>
    /// Wraper that may represent an object if it exists as <see cref="Some{T}"/>, will be <see cref="None{T}"/> if the object doesn't exist.
    /// </summary>
    /// <typeparam name="T">The type of the value if it exists.</typeparam>
    public abstract class Option<T>
    {
        internal Option()
        { }

        public static implicit operator Option<T>(T value) =>
            Some<T>.Value(value);

        public static implicit operator Option<T>(None none) =>
            new None<T>();
    }
}
