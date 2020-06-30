using System.Collections.Generic;

namespace CharacterSheetHandler.Models.Vampire
{
    public class Abilities
    {
        public IEnumerable<Skill> Talents { get; set; }
        public IEnumerable<Skill> Skills { get; set; }
        public IEnumerable<Skill> Knowledges { get; set; }
    }
}