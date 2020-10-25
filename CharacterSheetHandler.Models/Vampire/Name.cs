using FunctionalCSharp.Result;
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
                return Error<Name, NameError>.Value(NameError.Empty);

            if (name.Length > Constants.NameLength)
                return Error<Name, NameError>.Value(NameError.TooLong);

            return Ok<Name, NameError>.Value(new Name(name));
        }

        #region Equals
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
        #endregion Equals
    }

    public abstract class NameError
    {
        private NameError()
        { }

        internal static EmptyName Empty => new EmptyName();
        internal static TooLongName TooLong => new TooLongName();
        public class EmptyName : NameError
        { }
        public class TooLongName : NameError
        { }
    }
}