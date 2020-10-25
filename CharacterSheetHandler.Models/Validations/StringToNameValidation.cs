using CharacterSheetHandler.Models.Vampire;

using FunctionalCSharp.Option;
using FunctionalCSharp.Result;

using System;

namespace CharacterSheetHandler.Models.Validations
{
    public class StringToNameValidation : IValidationRule<string, string>
    {
        private readonly Func<NameError, string> _mapError;

        public StringToNameValidation(Func<NameError, string> mapError) => _mapError = mapError;

        public Option<string> Validate(string value)
            => Name
            .New(value)
            .MapError(e => Some<NameError>.Value(e))
            .ReduceError(None.Value)
            .Map(_mapError);
    }
}
