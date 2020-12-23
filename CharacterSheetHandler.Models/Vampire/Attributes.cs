using System.Collections.Generic;

namespace CharacterSheetHandler.Models.Vampire
{
    public class Attributes : ValueObject<Attributes>
    {
        public Physical Physical { get; }
        public Social Social { get; }
        public Mental Mental { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Physical;
            yield return Social;
            yield return Mental;
        }
    }
}