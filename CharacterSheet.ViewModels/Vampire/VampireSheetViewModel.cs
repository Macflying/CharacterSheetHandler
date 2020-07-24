using CharacterSheet.ViewModels;

namespace CharacterSheetHandler.ViewModels.Vampire
{
    public class VampireSheetViewModel : ViewModelBase
    {
        public SheetHeaderViewModel SheetHeader { get; } = new SheetHeaderViewModel();
        public AttributesViewModel Attributes { get; } = new AttributesViewModel();
        public AbilitiesViewModel Abilities { get; } = new AbilitiesViewModel();
        public AdvantagesViewModel Advantages { get; } = new AdvantagesViewModel();
        public StatusViewModel Status { get; } = new StatusViewModel();
    }
}
