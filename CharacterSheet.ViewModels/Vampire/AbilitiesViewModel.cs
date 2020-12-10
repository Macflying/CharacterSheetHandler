using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace CharacterSheetHandler.ViewModels.Vampire
{
    public class AbilitiesViewModel
    {
        public BindingList<SkillViewModel> Talents { get; } = new BindingList<SkillViewModel>();
        public BindingList<SkillViewModel> Skills { get; } = new BindingList<SkillViewModel>();
        public BindingList<SkillViewModel> Knowledges { get; } = new BindingList<SkillViewModel>();

        public AbilitiesViewModel()
        {
        }
    }
}