namespace CharacterSheetHandler.ViewModels.Vampire
{
    public class SkillViewModel
    {
        ValidatableValue<int> Level { get; } = ValidatableValue<int>.AutoValidatingValue();
    }
}