using CharacterSheetHandler.Models.Tests.Vampire.Arbitraries;
using CharacterSheetHandler.Models.Vampire;

using FsCheck;
using FsCheck.Xunit;

using FunctionalCSharp.Result;

namespace CharacterSheetHandler.Models.Tests.Vampire
{
    public class SkillTests
    {
        [Property(Arbitrary = new[] { typeof(NameArbitrary), typeof(LevelArbitrary) })]
        public Property CanCreate_Skill_From_LevelAndName(Name name, Level level)
        {
            var skill = Skill.New(name, level);

            return (skill is Ok<Skill, SkillError> ok
                && ((Skill)ok).Name == name
                && ((Skill)ok).Level == level)
                .ToProperty();
        }

        [Property(Arbitrary = new[] { typeof(LevelArbitrary) })]
        public Property NullName_To_EmptyNameError(Level level)
        {
            var skill = Skill.New(null, level);

            return (skill is Error<Skill, SkillError> error
                && (SkillError)error is EmptyNameError)
                .ToProperty();
        }

        [Property(Arbitrary = new[] { typeof(NameArbitrary) })]
        public Property NullLevel_To_NoLevelError(Name name)
        {
            var skill = Skill.New(name, null);

            return (skill is Error<Skill, SkillError> error
                && (SkillError)error is NoLevelError)
                .ToProperty();
        }
    }
}