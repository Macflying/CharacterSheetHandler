using System;
using System.Collections.Generic;
using System.Diagnostics;

using FunctionalCSharp.Result;

namespace CharacterSheetHandler.Models.Vampire
{
    [DebuggerDisplay("{ToString()}")]
    public class Level : ValueObject<Level>
    {
        public int Max { get; }
        public int Value { get; }

        private Level(int maxLevel, int value)
        {
            Max = maxLevel;
            Value = value;
        }

        public static Result<Level, LevelError> New(int max, int value)
        {
            if (max <= 0)
                return Error<Level, LevelError>.Value(LevelError.NegativeOrZeroMaxLevel);

            if (value <= 0)
                return Error<Level, LevelError>.Value(LevelError.NegativeOrZeroLevel);

            if (value > max)
                return Error<Level, LevelError>.Value(LevelError.LevelSupperiorToMax);

            return Ok<Level, LevelError>.Value(new Level(max, value));
        }

        public override string ToString() =>
            $"{Value}/{Max}";

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Max;
            yield return Value;
        }
    }

    public abstract class LevelError
    {
        private LevelError()
        { }

        public static NegativeOrZeroMaxLevelError NegativeOrZeroMaxLevel =>
            new NegativeOrZeroMaxLevelError();

        public class NegativeOrZeroMaxLevelError : LevelError
        { }

        public static NegativeOrZeroLevelError NegativeOrZeroLevel =>
            new NegativeOrZeroLevelError();

        public class NegativeOrZeroLevelError : LevelError
        { }

        public static LevelSupperiorToMaxError LevelSupperiorToMax =>
            new LevelSupperiorToMaxError();

        public class LevelSupperiorToMaxError : LevelError
        { }
    }
}