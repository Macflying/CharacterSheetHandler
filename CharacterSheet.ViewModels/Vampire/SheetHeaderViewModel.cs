using CharacterSheetHandler.Models.Validations;
using CharacterSheetHandler.Models.Vampire;

using System.Collections.Generic;

namespace CharacterSheetHandler.ViewModels.Vampire
{
    public class SheetHeaderViewModel
    {
        public ValidatableValue<string> Name { get; set; }
        public ValidatableValue<string> Player { get; set; }

        public SheetHeaderViewModel()
        {
            var nameValidations = new List<IValidationRule<string, string>>();
            nameValidations.Add(new StringToNameValidation(MapNameError));

            Name = ValidatableValue<string>.AutoValidatingValue(nameValidations);
            Name.Value = "Jean Bartishe";

            Player = ValidatableValue<string>.AutoValidatingValue(nameValidations);
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