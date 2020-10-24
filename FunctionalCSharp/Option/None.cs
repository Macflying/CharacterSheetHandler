namespace FunctionalCSharp.Option
{
    public class None<T> : Option<T>
    {
    }

    public class None
    {
        public static None Value { get; } = new None();
        private None() { }
    }
}