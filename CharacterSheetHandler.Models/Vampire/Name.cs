using FunctionalCSharp.Result;

using System.Collections.Generic;
using System.Diagnostics;

namespace CharacterSheetHandler.Models.Vampire
{
    [DebuggerDisplay("{ToString()}")]
    public class Name : ValueObject<Name>
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

        public override string ToString()
        {
            return Value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }

    public abstract class NameError
    {
        internal static EmptyName Empty => new EmptyName();
        internal static TooLongName TooLong => new TooLongName();
    }

    public class EmptyName : NameError
    { }

    public class TooLongName : NameError
    { }
}