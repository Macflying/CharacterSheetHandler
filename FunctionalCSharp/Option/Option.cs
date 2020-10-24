namespace FunctionalCSharp.Option
{
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
