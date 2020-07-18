using CharacterSheet.ViewModels;

namespace CharacterSheetHandler.ViewModels.Vampires
{
    public class VampireSheetViewModel : ViewModelBase
    {
        public SheetHeaderViewModel SheetHeader { get; }
        public AbilitiesViewModel Abilities { get; }
        public AttributesViewModel Attributes { get; }
    }
}
