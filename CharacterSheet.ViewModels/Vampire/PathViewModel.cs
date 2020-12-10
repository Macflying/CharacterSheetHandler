namespace CharacterSheetHandler.ViewModels.Vampire
{
    public class PathViewModel
    {
        public int Max => 10;
        public ValidatableValue<string> Bearing { get; } = ValidatableValue<string>.AutoValidatingValue();
        public ValidatableValue<int> Level { get; } = ValidatableValue<int>.AutoValidatingValue();

        public PathViewModel()
        {
        }
    }
}