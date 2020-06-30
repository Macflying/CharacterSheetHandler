using System;
using System.Collections.Generic;
using System.Text;

namespace CharacterSheetHandler.Models.Vampire
{
    public class VampireSheet
    {
        public Header Header { get; set; }
        public Attributes Attributes { get; set; }
        public Abilities Abilities { get; set; }
        public Advantages Advantages { get; set; }

        public object ToDTO()
        {
            throw new NotImplementedException();
        }

        public Status Status { get; set; }

        public static object FromDTO(DTOs.Vampire.VampireSheet dto)
        {
            throw new NotImplementedException();
        }
    }
}
