using FunctionalCSharp.Option;

namespace CharacterSheetHandler.Models.Validations
{
    public class NonNullOrWhiteSpaceStringValidation<TError> : IValidationRule<string, TError>
    {
        private readonly TError _error;

        public NonNullOrWhiteSpaceStringValidation(TError error) => _error = error;

        public Option<TError> Validate(string value)
            => string.IsNullOrWhiteSpace(value)
                .When(b => b)
                .Map(e => _error);
    }
}
