using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace CharacterSheetHandler.Models.Vampire
{
    [DebuggerDisplay("Level: {Value}/{Max}")]
    public class Level : IEquatable<Level>
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
                return Error.Value<Level, LevelError>(LevelError.NegativeOrZeroMaxLevel);

            if (value <= 0)
                return Error.Value<Level, LevelError>(LevelError.NegativeOrZeroLevel);

            if (value > max)
                return Error.Value<Level, LevelError>(LevelError.LevelSupperiorToMax);

            return Ok.Value<Level, LevelError>(new Level(max, value));
        }

        public override bool Equals(object obj) =>
            Equals(obj as Level);

        public bool Equals(Level other)
        {
            return other != null &&
                   Max == other.Max &&
                   Value == other.Value;
        }

        public override int GetHashCode() =>
            HashCode.Combine(Max, Value);

        public override string ToString()
        {
            return $"{Value}/{Max}";
        }

        public static bool operator ==(Level left, Level right) =>
            EqualityComparer<Level>.Default.Equals(left, right);

        public static bool operator !=(Level left, Level right) =>
            !(left == right);
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