
using FunctionalCSharp.Option;

namespace CharacterSheetHandler.Models.Validations
{
    public interface IValidationRule<TValue, TError>
    {
        Option<TError> Validate(TValue value);
    }
}
