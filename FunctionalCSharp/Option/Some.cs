namespace FunctionalCSharp.Option
{
    public class Some<T> : Option<T>
    {
        public T Content { get; }

        private Some(T content) => Content = content;

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