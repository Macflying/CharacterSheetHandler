namespace CharacterSheetHandler.Models.Vampire
{
    public class Name
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