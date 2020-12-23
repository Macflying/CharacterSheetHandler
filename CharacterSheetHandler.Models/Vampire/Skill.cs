using FunctionalCSharp.Result;

using System.Collections.Generic;
using System.Diagnostics;

namespace CharacterSheetHandler.Models.Vampire
{
    [DebuggerDisplay("{ToString()}")]
    public class Skill : ValueObject<Skill>
    {
        public Name Name { get; }
        public Level Level { get; }

        private Skill(Name name, Level level)
        {
            Name = name;
            Level = level;
        }

        public static Result<Skill, SkillError> New(Name name, Level level)
        {
            if (name == null)
                return Error<Skill, SkillError>.Value(SkillError.EmptyName);

            if (level == null)
                return Error<Skill, SkillError>.Value(SkillError.NoLevel);

            return Ok<Skill, SkillError>.Value(new Skill(name, level));
        }

        public override string ToString()
        {
            return $"{Name.ToString()}: {Level.ToString()}";
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
            yield return Level;
        }
    }

    public abstract class SkillError
    {
        public static EmptyNameError EmptyName =>
            new EmptyNameError();

        public static NoLevelError NoLevel =>
            new NoLevelError();
    }

    public class NoLevelError : SkillError
    { }

    public class EmptyNameError : SkillError
    { }
}