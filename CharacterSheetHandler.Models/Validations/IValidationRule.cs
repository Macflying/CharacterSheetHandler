using System;
using System.Collections.Generic;
using System.Text;

namespace CharacterSheetHandler.Models.Validations
{
    public interface IValidationRule<TValue, TError>
    {
        TError Error { get; }
        bool Validate(TValue value);
    }
}
