using FunctionalCSharp.Result;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CharacterSheetHandler.Models.Vampire
{
    [DebuggerDisplay("{ToString()}")]
    public class Skill : IEquatable<Skill>
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

        public override bool Equals(object obj)
        {
            return Equals(obj as Skill);
        }

        public bool Equals(Skill other)
        {
            return other != null &&
                   EqualityComparer<Name>.Default.Equals(Name, other.Name) &&
                   EqualityComparer<Level>.Default.Equals(Level, other.Level);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Level);
        }

        public override string ToString()
        {
            return $"{Name.ToString()} {Level.ToString()}";
        }

        public static bool operator ==(Skill left, Skill right)
        {
            return EqualityComparer<Skill>.Default.Equals(left, right);
        }

        public static bool operator !=(Skill left, Skill right)
        {
            return !(left == right);
        }
    }

    public abstract class SkillError
    { 
        private SkillError()
        { }

        public static EmptyNameError EmptyName =>
            new EmptyNameError();
        public class EmptyNameError : SkillError
        { }

        public static NoLevelError NoLevel =>
            new NoLevelError();
        public class NoLevelError : SkillError
        { }
    }
}