using System;
using System.Security.Cryptography.X509Certificates;

namespace CharacterSheetHandler.Models.Vampire
{
    public class Level
    {

        public int Max { get; }
        public int Value { get; }

        public Level(int maxLevel, int value)
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
    }

    public abstract class LevelError
    {
        private LevelError()
        { }

        public static NegativeOrZeroMaxLevelError NegativeOrZeroMaxLevel => new NegativeOrZeroMaxLevelError();
        public class NegativeOrZeroMaxLevelError : LevelError
        { }

        public static NegativeOrZeroLevelError NegativeOrZeroLevel => new NegativeOrZeroLevelError();
        public class NegativeOrZeroLevelError : LevelError
        { }

        public static LevelSupperiorToMaxError LevelSupperiorToMax => new LevelSupperiorToMaxError();
        public class LevelSupperiorToMaxError : LevelError
        { }
    }
}