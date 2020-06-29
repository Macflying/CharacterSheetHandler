using System;

namespace CharacterSheetHandler.Models
{
    public abstract class Option<T>
    {
        private Option()
        { }

        public static implicit operator Option<T>(T value) =>
            Some<T>.Value(value);

        public class Some : Option<T>
        {
            private T _content;
            public Some(T value) => _content = value;

            public static implicit operator T(Some some) => some._content;
        }

        public class None : Option<T>
        { }
    }

    public static class Some<T>
    {
        public static Option<T> Value(T value)
        {
            if (value != null)
                return new Option<T>.Some(value);
            return new Option<T>.None();
        }
    }

    public static class None<T>
    {
        public static Option<T>.None Value => new Option<T>.None();
    }
}
