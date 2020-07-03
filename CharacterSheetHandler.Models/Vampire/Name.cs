using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CharacterSheetHandler.Models.Vampire
{
    [DebuggerDisplay("Name: {Value}")]
    public class Name : IEquatable<Name>
    {
        public string Value { get; }
        private Name(string name) => Value = name;

        public static Result<Name, NameError> New(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return Error.Value<Name, NameError>(NameError.Empty);

            if (name.Length > Constants.NameLength)
                return Error.Value<Name, NameError>(NameError.TooLong);

            return Ok.Value<Name, NameError>(new Name(name));
        }

        public override bool Equals(object obj) =>
            Equals(obj as Name);

        public bool Equals(Name other) =>
            other != null
            && Value == other.Value;

        public override int GetHashCode() =>
            HashCode.Combine(Value);

        public override string ToString() =>
            $"{Value}";

        public static bool operator ==(Name left, Name right) =>
            EqualityComparer<Name>.Default.Equals(left, right);

        public static bool operator !=(Name left, Name right) =>
            !(left == right);
    }

    public abstract class NameError
    {
        private NameError()
        { }

        public static EmptyName Empty => new EmptyName();
        public static TooLongName TooLong => new TooLongName();
        public class EmptyName : NameError
        { }
        public class TooLongName : NameError
        { }
    }
}