using CharacterSheetHandler.Models.Vampire;

using FunctionalCSharp.Option;
using FunctionalCSharp.Result;

namespace CharacterSheetHandler.Models.Validations
{
    public class StringToNameValidation : IValidationRule<string, NameError>
    {
        public Option<NameError> Validate(string value)
            => Name
            .New(value)
            .MapError(e => Some<NameError>.Value(e))
            .ReduceError(None.Value);
    }
}
