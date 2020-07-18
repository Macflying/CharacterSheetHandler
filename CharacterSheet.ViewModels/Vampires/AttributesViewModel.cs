using System.Collections.ObjectModel;

namespace CharacterSheetHandler.ViewModels.Vampires
{
    public class AttributesViewModel
    {
        public ObservableCollection<SkillViewModel> Physical { get; }
        public ObservableCollection<SkillViewModel> Social { get; }
        public ObservableCollection<SkillViewModel> Mental { get; }

        public AttributesViewModel()
        {
            Physical = new ObservableCollection<SkillViewModel>()
            {
                new SkillViewModel(),
            };
        }
    }
}