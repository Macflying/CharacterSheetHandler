using FunctionalCSharp.Option;

using System;

namespace CharacterSheetHandler.Models.Validations
{
    public class ErrorToStringValidationDecorator<TValue, TError, TNewError> : IValidationRule<TValue, TNewError>
    {
        private readonly Func<TError, TNewError> _mapError;
        private readonly IValidationRule<TValue, TError> _validationRule;

        public ErrorToStringValidationDecorator(Func<TError, TNewError> mapError, IValidationRule<TValue, TError> validationRule)
        {
            _mapError = mapError;
            _validationRule = validationRule;
        }

        public Option<TNewError> Validate(TValue value)
            => _validationRule
            .Validate(value)
            .Map(_mapError);
    }
}
