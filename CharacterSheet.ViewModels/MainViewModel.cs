using CharacterSheetHandler.ViewModels.Vampire;

namespace CharacterSheetHandler.ViewModels
{
    public class MainViewModel
    {
        public VampireSheetViewModel Context { get; set; } = new VampireSheetViewModel();
    }
}
