using System.Collections.Generic;

namespace CharacterSheetHandler.Models.Vampire
{
    public class Abilities
    {
        public IEnumerable<Skill> Talents { get; }
        public IEnumerable<Skill> Skills { get;  }
        public IEnumerable<Skill> Knowledges { get; }
    }
}