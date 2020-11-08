namespace CharacterSheetHandler.ViewModels.Vampire
{
    public class SkillViewModel
    {
        public string Name { get; } = "Academics";
        public ValidatableValue<int> Level { get; } = ValidatableValue<int>.AutoValidatingValue();
        public int MaxLevel { get; } = 5;
    }
}