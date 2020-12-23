using System.Collections.Generic;

namespace CharacterSheetHandler.Models.Vampire
{
    public class Abilities
    {
        public IReadOnlyList<Skill> Talents { get; }
        public IReadOnlyList<Skill> Skills { get; }
        public IReadOnlyList<Skill> Knowledges { get; }
    }
}