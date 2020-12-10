using System;

using CharacterSheetHandler.Models.Validations;
using CharacterSheetHandler.Models.Vampire;

namespace CharacterSheetHandler.ViewModels.Vampire
{
    public class SkillViewModel
    {
        public ValidatableValue<string> Name { get; } = ValidatableValue<string>.AutoValidatingValue();
        public ValidatableValue<int> Level { get; } = ValidatableValue<int>.AutoValidatingValue();
        public int MaxLevel { get; } = 5;

        public SkillViewModel()
        {
            SetDefaultValidationRules();

            SetDefaultValues();
        }

        private void SetDefaultValidationRules()
        {
            var nonNullOrWhiteSpaceStringValidation = new NonNullOrWhiteSpaceStringValidation<string>(
                    ErrorsMessages.NullOrWhiteSpaceStringError);
            Name.ValidationRules.Add(nonNullOrWhiteSpaceStringValidation);

            var levelValidation = new ErrorToStringValidationDecorator<int, LevelError, string>(
                MapLevelError,
                new IntToLevelValidation(MaxLevel));
            Level.ValidationRules.Add(levelValidation);
        }

        private string MapLevelError(LevelError error)
        {
            if (error is LevelError.LevelSupperiorToMaxError)
                return ErrorsMessages.LevelSuperiorToMaxError;

            if (error is LevelError.NegativeOrZeroLevelError)
                return ErrorsMessages.NegativeOrZeroLevelError;

            return ErrorsMessages.UnknownError;
        }

        private void SetDefaultValues()
        {
            Level.Value = 1;
        }
    }
}