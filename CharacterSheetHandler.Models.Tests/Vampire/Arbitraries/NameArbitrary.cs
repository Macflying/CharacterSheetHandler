using CharacterSheetHandler.Models.Vampire;

using FsCheck;
using FunctionalCSharp.Result;

namespace CharacterSheetHandler.Models.Tests.Vampire.Arbitraries
{
    public class NameArbitrary
    {
        public static Arbitrary<Name> LegalName()
        {
            return StringArbitrary.NonNullOrWhiteSpacesStringWithMaxLength()
                .Convert(ConvertToName, ConvertToString);
        }

        private static Name ConvertToName(NonNullOrWhiteSpacesStringMaxWithMaxLength name) =>
            (Ok<Name, NameError>)Name.New(name.Get);

        private static NonNullOrWhiteSpacesStringMaxWithMaxLength ConvertToString(Name name) =>
            new NonNullOrWhiteSpacesStringMaxWithMaxLength(name.Value);
    }
}
