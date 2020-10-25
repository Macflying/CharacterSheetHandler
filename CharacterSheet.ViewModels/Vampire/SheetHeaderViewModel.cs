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

        public ValidatableValue<string> Name { get; set; }
        public ValidatableValue<string> Player { get; set; }
        public ValidatableValue<string> Chronicle { get; set; }

        public ValidatableValue<string> Nature { get; set; }
        public ValidatableValue<string> Demeanor { get; set; }
        public ValidatableValue<string> Concept { get; set; }

        public ValidatableValue<string> Clan { get; set; }
        public ValidatableValue<string> Sire { get; set; }
        public ValidatableValue<string> Generation { get; set; }

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

            var nonNullOrWhiteSpaceStrinValidation = new List<IValidationRule<string, string>>();
            nonNullOrWhiteSpaceStrinValidation.Add(
                new NonNullOrWhiteSpaceStringValidation<string>(
                    _nullOrWhiteSpaceStringError));

            Name = ValidatableValue<string>.AutoValidatingValue(nameValidations);
            Player = ValidatableValue<string>.AutoValidatingValue(nameValidations);
            Chronicle = ValidatableValue<string>.AutoValidatingValue(nonNullOrWhiteSpaceStrinValidation);

            Nature = ValidatableValue<string>.AutoValidatingValue(nonNullOrWhiteSpaceStrinValidation);
            Demeanor = ValidatableValue<string>.AutoValidatingValue(nonNullOrWhiteSpaceStrinValidation);
            Concept = ValidatableValue<string>.AutoValidatingValue(nonNullOrWhiteSpaceStrinValidation);

            Clan = ValidatableValue<string>.AutoValidatingValue(nonNullOrWhiteSpaceStrinValidation);
            Generation = ValidatableValue<string>.AutoValidatingValue(nonNullOrWhiteSpaceStrinValidation);
            Sire = ValidatableValue<string>.AutoValidatingValue(nonNullOrWhiteSpaceStrinValidation);
        }

        private void SetDefaultValue()
        {
            Name.Value = "Jean Bartishe";
            Player.Value = "Léo";
        }

        private static string MapNameError(NameError error)
        {
            if (error is NameError.EmptyName)
                return "Name shouldn't be empty.";

            if (error is NameError.TooLongName)
                return $"Name shouldn't exceed {Constants.NameLength}";

            return "Unknown error while setting the name.";
        }
    }
}