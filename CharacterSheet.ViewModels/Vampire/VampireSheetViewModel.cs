using CharacterSheet.ViewModels;

namespace CharacterSheetHandler.ViewModels.Vampire
{
    public class VampireSheetViewModel : ViewModelBase
    {
        public SheetHeaderViewModel SheetHeader { get; } = new SheetHeaderViewModel();
        public AbilitiesViewModel Abilities { get; } = new AbilitiesViewModel();
        public AttributesViewModel Attributes { get; } = new AttributesViewModel();
    }
}
