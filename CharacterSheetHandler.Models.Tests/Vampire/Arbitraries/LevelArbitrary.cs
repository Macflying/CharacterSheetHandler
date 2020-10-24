using CharacterSheetHandler.Models.Vampire;

using FsCheck;
using FunctionalCSharp.Result;
using Microsoft.FSharp.Core;

using System;

namespace CharacterSheetHandler.Models.Tests.Vampire.Arbitraries
{
    public static class LevelArbitrary
    {
        public static Arbitrary<Level> LegalLevel()
        {
            return Arb.Default.PositiveInt()
                .Generator.Two()
                .ToArbitrary()
                .Convert(ConvertToLevel, ConvertFromLevel);
        }

        private static Level ConvertToLevel(Tuple<PositiveInt, PositiveInt> value)
        {
            int max;
            int level;
            if (value.Item1.Get <= value.Item2.Get)
            {
                max = value.Item2.Get;
                level = value.Item1.Get;
            }
            else
            {
                max = value.Item1.Get;
                level = value.Item2.Get;
            }
            return (Ok<Level, LevelError>)Level.New(max, level);
        }

        private static Tuple<PositiveInt, PositiveInt> ConvertFromLevel(Level level) =>
            Tuple.Create(PositiveInt.NewPositiveInt(level.Max), PositiveInt.NewPositiveInt(level.Value));
    }
}
