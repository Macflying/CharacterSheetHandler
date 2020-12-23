using System.Collections.Generic;

namespace CharacterSheetHandler.Models.Vampire
{
    public class Social : ValueObject<Social>
    {
        public Level Charisma { get; }
        public Level Manipulation { get; }
        public Level Appearance { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Charisma;
            yield return Manipulation;
            yield return Appearance;
        }
    }
}