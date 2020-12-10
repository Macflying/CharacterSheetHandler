using CharacterSheetHandler.Models;
using CharacterSheetHandler.Models.Validations;
using CharacterSheetHandler.Models.Vampire;

using System;
using System.Collections.Generic;

namespace CharacterSheetHandler.ViewModels.Vampire
{
    public class SheetHeaderViewModel
    {
        private readonly string _nullOrWhiteSpaceStringError = "Field shouldn't be left empty or consisting of only white spaces.";

        public ValidatableValue<string> Name { get; private set; }
        public ValidatableValue<string> Player { get; private set; }
        public ValidatableValue<string> Chronicle { get; private set; }

        public ValidatableValue<string> Nature { get; private set; }
        public ValidatableValue<string> Demeanor { get; private set; }
        public ValidatableValue<string> Concept { get; private set; }

        public ValidatableValue<string> Clan { get; private set; }
        public ValidatableValue<string> Sire { get; private set; }
        public ValidatableValue<string> Generation { get; private set; }

        public SheetHeaderViewModel()
        {
            SetDefaultValidationRules();

            SetDefaultValue();
        }

        private void SetDefaultValidationRules()
        {
            var nameValidations = new List<IValidationRule<string, string>>();
            nameValidations.Add(
                new ErrorToStringValidationDecorator<string, NameError, string>
                (
                    MapNameError,
                    new StringToNameValidation()
                ));

            var nonNullOrWhiteSpaceStringValidation = new List<IValidationRule<string, string>>();
            nonNullOrWhiteSpaceStringValidation.Add(
                new NonNullOrWhiteSpaceStringValidation<string>(
                    _nullOrWhiteSpaceStringError));

            Name = ValidatableValue<string>.AutoValidatingValue(nameValidations);
            Player = ValidatableValue<string>.AutoValidatingValue(nameValidations);
            Chronicle = ValidatableValue<string>.AutoValidatingValue(nonNullOrWhiteSpaceStringValidation);

            Nature = ValidatableValue<string>.AutoValidatingValue(nonNullOrWhiteSpaceStringValidation);
            Demeanor = ValidatableValue<string>.AutoValidatingValue(nonNullOrWhiteSpaceStringValidation);
            Concept = ValidatableValue<string>.AutoValidatingValue(nonNullOrWhiteSpaceStringValidation);

            Clan = ValidatableValue<string>.AutoValidatingValue(nonNullOrWhiteSpaceStringValidation);
            Generation = ValidatableValue<string>.AutoValidatingValue(nonNullOrWhiteSpaceStringValidation);
            Sire = ValidatableValue<string>.AutoValidatingValue(nonNullOrWhiteSpaceStringValidation);
        }

        private void SetDefaultValue()
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

        private static string MapNameError(NameError error)
        {
            if (error is NameError.EmptyName)
                return "Name shouldn't be empty.";

            if (error is NameError.TooLongName)
                return $"Name shouldn't exceed {Constants.NameLength} characters";

            return "Unknown error while setting the name.";
        }
    }
}