using System.Collections.Generic;

namespace CharacterSheetHandler.Models.Vampire
{
    public class Mental : ValueObject<Mental>
    {
        public Level Perception { get; }
        public Level Intelligence { get; }
        public Level Wits { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Perception;
            yield return Intelligence;
            yield return Wits;
        }
    }
}