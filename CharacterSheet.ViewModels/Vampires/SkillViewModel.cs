namespace CharacterSheetHandler.ViewModels.Vampires
{
    public class SkillViewModel
    {
        ValidatableValue<int> Level { get; } = ValidatableValue<int>.AutoValidatingValue();
    }
}