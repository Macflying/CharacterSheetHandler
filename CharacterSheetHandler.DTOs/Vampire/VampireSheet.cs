using System;
using System.Net.Http.Headers;

namespace CharacterSheetHandler.DTOs.Vampire
{
    public class VampireSheet
    {
        public Header Header { get; set; }
        public Attributes Attributes { get; set; }
        public Abilities Abilities { get; set; }
        public Advantages Advantages { get; set; }
        public Status Status { get; set; }
    }
}
