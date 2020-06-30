using FsCheck;
using FsCheck.Xunit;

using System;

using Xunit;

namespace CharacterSheetHandler.Models.Tests
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
            Assert.IsAssignableFrom<Option<int>>(None<int>.Value);
        }

        [Fact]
        public void NullValueToSomeValue_Returns_None()
        {
            Assert.IsType<Option<string>.None>(Some<string>.Value(null));
        }

        [Property]
        public Property NotNullValueToSome_AlwaysResultIn_Some(decimal value)
        {
            return (Some<decimal?>.Value(value) is Option<decimal?>.Some).ToProperty();
        }

        [Property]
        public Property IfOptionHoldsAValue_CanRetrieveIt(DateTime value)
        {
            Option<DateTime> opt = Some<DateTime>.Value(value);
            return (opt is Option<DateTime>.Some some && some == value).ToProperty();
        }

        [Property]
        public Property OptionHasSyntacticSugar_WorksLike_SomeValue(string value)
        {
            Option<string> opt = value;
            return (value != null && opt is Option<string>.Some)
                .Or(value == null && opt is Option<string>.None);
        }
    }
}