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
        public void Some_Is_Option()
        {
            Assert.IsAssignableFrom<Option<Guid>>(Some<Guid>.Value(new Guid()));
        }

        [Fact]
        public void None_Is_Option()
        {
            Assert.IsAssignableFrom<Option<int>>(None.Value);
        }

        [Fact]
        public void NullValueToSomeValue_Returns_None()
        {
            Assert.IsType<None<string>>(Some<string>.Value(null));
        }

        [Property]
        public Property NotNullValueToSome_AlwaysResultIn_Some(decimal value)
        {
            return (Some<decimal?>.Value(value) is Some<decimal?>).ToProperty();
        }

        [Property]
        public Property IfOptionHoldsAValue_CanRetrieveIt(DateTime value)
        {
            Option<DateTime> opt = Some<DateTime>.Value(value);
            return (opt is Some<DateTime> some && some == value).ToProperty();
        }

        [Property]
        public Property OptionHasSyntacticSugar_WorksLike_SomeValue(string value)
        {
            Option<string> opt = value;
            return (value != null && opt is Some<string>)
                .Or(value == null && opt is None<string>);
        }
    }
}