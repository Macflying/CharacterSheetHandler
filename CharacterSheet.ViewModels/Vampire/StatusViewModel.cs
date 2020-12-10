using System;
using System.Collections.Generic;

using CharacterSheetHandler.Models.CollectionExtensions;
using CharacterSheetHandler.Models.Validations;

namespace CharacterSheetHandler.ViewModels.Vampire
{
    public class StatusViewModel
    {
        public ValidatableValue<string> Experince { get; } = ValidatableValue<string>.AutoValidatingValue();
        public ValidatableValue<string> Weakness { get; } = ValidatableValue<string>.AutoValidatingValue();

        public PathViewModel Path { get; } = new PathViewModel();

        public StatusViewModel()
        {
            SetDefaultValidationRules();
        }

        private void SetDefaultValidationRules()
        {
            Experince.ValidationRules.Add(
                new NonNullOrWhiteSpaceStringValidation<string>(
                    ErrorsMessages.NoExperienceError));

            Weakness.ValidationRules.Add(
                new NonNullOrWhiteSpaceStringValidation<string>(
                    ErrorsMessages.NoWeaknessError));
        }
    }
}