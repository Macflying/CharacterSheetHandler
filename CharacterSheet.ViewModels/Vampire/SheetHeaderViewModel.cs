using CharacterSheetHandler.Models;
using CharacterSheetHandler.Models.CollectionExtensions;
using CharacterSheetHandler.Models.Validations;
using CharacterSheetHandler.Models.Vampire;

using System;
using System.Collections.Generic;

namespace CharacterSheetHandler.ViewModels.Vampire
{
    public class SheetHeaderViewModel
    {
        public ValidatableValue<string> Name { get; } = ValidatableValue<string>.AutoValidatingValue();
        public ValidatableValue<string> Player { get; } = ValidatableValue<string>.AutoValidatingValue();
        public ValidatableValue<string> Chronicle { get; } = ValidatableValue<string>.AutoValidatingValue();

        public ValidatableValue<string> Nature { get; } = ValidatableValue<string>.AutoValidatingValue();
        public ValidatableValue<string> Demeanor { get; } = ValidatableValue<string>.AutoValidatingValue();
        public ValidatableValue<string> Concept { get; } = ValidatableValue<string>.AutoValidatingValue();

        public ValidatableValue<string> Clan { get; } = ValidatableValue<string>.AutoValidatingValue();
        public ValidatableValue<string> Sire { get; } = ValidatableValue<string>.AutoValidatingValue();
        public ValidatableValue<string> Generation { get; } = ValidatableValue<string>.AutoValidatingValue();

        public SheetHeaderViewModel()
        {
            SetDefaultValidationRules();

            SetDefaultValues();
        }

        private void SetDefaultValidationRules()
        {
            var nameValidations = new ErrorToStringValidationDecorator<string, NameError, string>(
                    MapNameError,
                    new StringToNameValidation());

            var nonNullOrWhiteSpaceStringValidation = new NonNullOrWhiteSpaceStringValidation<string>(
                    ErrorsMessages.NullOrWhiteSpaceStringError);

            Name.ValidationRules.Add(nameValidations);
            Player.ValidationRules.Add(nameValidations);
            Chronicle.ValidationRules.Add(nonNullOrWhiteSpaceStringValidation);

            Nature.ValidationRules.Add(nonNullOrWhiteSpaceStringValidation);
            Demeanor.ValidationRules.Add(nonNullOrWhiteSpaceStringValidation);
            Concept.ValidationRules.Add(nonNullOrWhiteSpaceStringValidation);

            Clan.ValidationRules.Add(nonNullOrWhiteSpaceStringValidation);
            Generation.ValidationRules.Add(nonNullOrWhiteSpaceStringValidation);
            Sire.ValidationRules.Add(nonNullOrWhiteSpaceStringValidation);
        }

        private static string MapNameError(NameError error)
        {
            if (error is EmptyName)
                return ErrorsMessages.EmptyNameError;

            if (error is TooLongName)
                return ErrorsMessages.TooLongNameError;

            return ErrorsMessages.UnknownError;
        }

        private void SetDefaultValues()
        {
            Name.Value = "Jean Bartishe";
            Player.Value = "Léo";
            Chronicle.Value = string.Empty;

            Nature.Value = string.Empty;
            Demeanor.Value = string.Empty;
            Concept.Value = string.Empty;

            Clan.Value = string.Empty;
            Generation.Value = string.Empty;
            Sire.Value = string.Empty;
        }
    }
}