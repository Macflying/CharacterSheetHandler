namespace FunctionalCSharp.Option
{
    /// <summary>
    /// Represent the absence of a value.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class None<T> : Option<T>
    {
    }

    /// <summary>
    /// Helper class to create None value.
    /// </summary>
    public class None
    {
        /// <summary>
        /// None value that can implicitly be converted to <see cref="None{T}"/>.
        /// </summary>
        public static None Value { get; } = new None();
        private None() { }
    }
}