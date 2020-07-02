using CharacterSheetHandler.Models.Vampire;

using FsCheck;
using FsCheck.Xunit;

using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

using Xunit;
using Xunit.Sdk;

namespace CharacterSheetHandler.Models.Tests.Vampire
{
    public class NameTests
    {
        [Fact]
        public void EmptyString_Gives_EmptyNameError()
        {
            var result = Name.New(string.Empty);

            Assert.IsType<Result<Name, NameError>.Error>(result);
            _ = result is Result<Name, NameError>.Error er
                ? (NameError.EmptyName)er
                : throw new TestFailedException("Should be NameError.EmptyName");
        }

        [Fact]
        public void NullString_Gives_EmptyNameError()
        {
            var result = Name.New(null);

            Assert.IsType<Result<Name, NameError>.Error>(result);
            _ = result is Result<Name, NameError>.Error er
                ? (NameError.EmptyName)er
                : throw new TestFailedException("Should be NameError.EmptyName");
        }

        [Fact]
        public void WhiteSpaceOnlyString_Gives_EmptyNameError()
        {
            var result = Name.New("    ");

            Assert.IsType<Result<Name, NameError>.Error>(result);
            _ = result is Result<Name, NameError>.Error er
                ? (NameError.EmptyName)er
                : throw new TestFailedException("Should be NameError.EmptyName");
        }

        [Fact]
        public void TooLongString_Gives_TooLongNameError()
        {
            var result = Name.New("Some veeeeeeeeery looooooooooong name");

            Assert.IsType<Result<Name, NameError>.Error>(result);
            _ = result is Result<Name, NameError>.Error er
                ? (NameError.TooLongName)er
                : throw new TestFailedException("Should be NameError.TooLongName");
        }

        [Property(Arbitrary = new[] { typeof(StringArbitrary)})]
        public Property GoodString_Gives_NameWithValue(NonNullOrWhiteSpacesStringMaxWithMaxLength value)
        {
            var result = Name.New(value.Get);

            Assert.IsType<Result<Name, NameError>.Ok>(result);
            var name = result is Result<Name, NameError>.Ok ok
                ? (Name)ok
                : throw new TestFailedException("Should be Name");

            return (name.Value.Equals(value.Get)).ToProperty();
        }
    }
}
