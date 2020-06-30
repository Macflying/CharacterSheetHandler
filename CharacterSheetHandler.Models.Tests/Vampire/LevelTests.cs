
using CharacterSheetHandler.Models.Vampire;

using FsCheck;
using FsCheck.Xunit;

using System.Reflection;

using Xunit;

namespace CharacterSheetHandler.Models.Tests.Vampire
{
    public class LevelTests
    {
        [Property]
        public Property MaxValue_CannotBe_NegativeOrZero(NonNegativeInt maxLevel)
        {
            var result = Level.New(-maxLevel.Get, 0);

            return (result is Result<Level, LevelError>.Error error && ((LevelError)error) is LevelError.NegativeOrZeroMaxLevelError)
                .ToProperty();
        }

        [Property]
        public Property Level_CannotBe_NegativeOrZero(NonNegativeInt level)
        {
            var result = Level.New(5, -level.Get);

            return (result is Result<Level, LevelError>.Error error && ((LevelError)error) is LevelError.NegativeOrZeroLevelError)
                .ToProperty();
        }

        [Property]
        public Property Level_CannotBe_StrictlySupperiorToMaxLevel(PositiveInt maxLevel, PositiveInt level)
        {
            var result = Level.New(maxLevel.Get, level.Get);

            return (level.Get > maxLevel.Get && result is Result<Level, LevelError>.Error error && ((LevelError)error) is LevelError.LevelSupperiorToMaxError)
                .Or(result is Result<Level, LevelError>.Ok ok && ((Level)ok).Max == maxLevel.Get && ((Level)ok).Value == level.Get);
        }
    }
}
