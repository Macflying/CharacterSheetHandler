using CharacterSheetHandler.Models.Vampire;

using FsCheck;

using Microsoft.FSharp.Core;

namespace CharacterSheetHandler.Models.Tests.Vampire.Arbitraries
{
    public static class SkillArbitrary
    {
        public static Arbitrary<Skill> LegalSkill()
        {
            var genLevel = LevelArbitrary.LegalLevel().Generator;
            var genName = NameArbitrary.LegalName().Generator;

            return Gen.
                Map2(ConvertToSkill, genName, genLevel)
                .ToArbitrary();
        }

        private static FSharpFunc<Name, FSharpFunc<Level, Skill>> ConvertToSkill =>
            FSharpFuncHelper.Create<Name, Level, Skill>
            ((name, level) => (Result<Skill, SkillError>.Ok)Skill.New(name, level));
    }
}