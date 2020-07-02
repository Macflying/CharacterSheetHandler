using System;
using System.Collections.Generic;
using System.Text;

namespace CharacterSheetHandler.Models.Vampire
{
    public class VampireSheet
    {
        public Header Header { get; }
        public Attributes Attributes { get; }
        public Abilities Abilities { get; }
        public Advantages Advantages { get; }
        public Status Status { get; }

        public object ToDTO()
        {
            throw new NotImplementedException();
        }

        public static object FromDTO(DTOs.Vampire.VampireSheet dto)
        {
            throw new NotImplementedException();
        }
    }
}
