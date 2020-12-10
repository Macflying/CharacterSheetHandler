using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace CharacterSheetHandler.ViewModels.Vampire
{
    public class AttributesViewModel
    {
        public BindingList<SkillViewModel> Physical { get; } = new BindingList<SkillViewModel>();
        public BindingList<SkillViewModel> Social { get; } = new BindingList<SkillViewModel>();
        public BindingList<SkillViewModel> Mental { get; } = new BindingList<SkillViewModel>();

        public AttributesViewModel()
        {
            SetDefaultValues();
        }

        private void SetDefaultValues()
        {
            SetPhysicalDefaultValues();

            SetSocialDefaultValues();

            SetMentalDefaultValues();
        }

        private void SetPhysicalDefaultValues()
        {
            var strength = new SkillViewModel();
            strength.Name.Value = "Strength";
            Physical.Add(strength);

            var dexterity = new SkillViewModel();
            dexterity.Name.Value = "Dexterity";
            Physical.Add(dexterity);

            var stamina = new SkillViewModel();
            stamina.Name.Value = "Stamina";
            Physical.Add(stamina);
        }

        private void SetSocialDefaultValues()
        {
            var charisma = new SkillViewModel();
            charisma.Name.Value = "Charisma";
            Social.Add(charisma);

            var manipulation = new SkillViewModel();
            manipulation.Name.Value = "Manipulation";
            Social.Add(manipulation);

            var appearance = new SkillViewModel();
            appearance.Name.Value = "Appearance";
            Social.Add(appearance);
        }

        private void SetMentalDefaultValues()
        {
            var perception = new SkillViewModel();
            perception.Name.Value = "Perception";
            Mental.Add(perception);

            var intelligence = new SkillViewModel();
            intelligence.Name.Value = "Intelligence";
            Mental.Add(intelligence);

            var wits = new SkillViewModel();
            wits.Name.Value = "Wits";
            Mental.Add(wits);
        }
    }
}