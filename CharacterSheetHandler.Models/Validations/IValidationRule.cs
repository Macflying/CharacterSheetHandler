
using FunctionalCSharp.Option;

namespace CharacterSheetHandler.Models.Validations
{
    public interface IValidationRule<in TValue, TError>
    {
        Option<TError> Validate(TValue value);
    }
}
