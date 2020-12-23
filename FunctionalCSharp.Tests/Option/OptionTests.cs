using FsCheck;
using FsCheck.Xunit;

using FunctionalCSharp.Option;

using System;

using Xunit;

namespace FunctionalCSharp.Tests.Option
{
    public class OptionTests
    {
        [Fact]
        public void Null_value_to_some_returns_none()
        {
            Assert.IsType<None<string>>(Some<string>.Value(null));
        }

        [Property]
        public Property NonNull_value_to_some_returns_some(decimal value)
        {
            return (Some<decimal?>.Value(value) is Some<decimal?>).ToProperty();
        }

        [Property]
        public Property If_option_holds_value_can_retrieve_it(DateTime value)
        {
            Option<DateTime> opt = Some<DateTime>.Value(value);
            return (opt is Some<DateTime> some && some == value).ToProperty();
        }

        [Property]
        public Property Option_can_map_to_other_value(int value)
        {
            int whenSome = value + 1;
            int whenNone = value - 1;
            var result = Some<int>.Value(value)
                     .When(num => num % 2 == 0)
                     .Map(num => num + 1)
                     .Reduce(value - 1);

            return (value % 2 == 0 && result == whenSome)
                .Or(result == whenNone);
        }

        [Property]
        public Property Option_can_do_action_when_is_some(int value)
        {
            string whenNone = "none";
            string whenSome = "some";
            string result = whenNone;
            Some<int>.Value(value)
                     .When(num => num % 2 == 0)
                     .WhenSome(num => result = whenSome);

            return (value % 2 == 0 && result == whenSome)
                .Or(result == whenNone);
        }
    }
}