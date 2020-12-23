using System;
using System.Collections.Generic;
using System.Text;

using FunctionalCSharp.Result;

namespace CharacterSheetHandler.Models.Vampire
{
    public class VampireSheet : Entity
    {
        private VampireSheet(Guid id, Header header, Attributes attributes, Abilities abilities, Advantages advantages, Status status)
            : base(id)
        {
            Header = header;
            Attributes = attributes;
            Abilities = abilities;
            Advantages = advantages;
            Status = status;
        }

        public static Result<VampireSheet, VampireSheetError> New(Guid id, Header header, Attributes attributes, Abilities abilities, Advantages advantages, Status status)
        {
            return new VampireSheet(id, header, attributes, abilities, advantages, status);
        }

        public Header Header { get; set; }
        public Attributes Attributes { get; }
        public Abilities Abilities { get; }
        public Advantages Advantages { get; }
        public Status Status { get; }
    }

    public class VampireSheetError
    { }
}