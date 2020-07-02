using FsCheck;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CharacterSheetHandler.Models.Tests
{
    public class StringArbitrary
    {
        public static Arbitrary<NonNullOrWhiteSpacesStringMaxWithMaxLength> NonNullOrWhiteSpacesStringWithMaxLength()
        {
            return Arb.Default.NonEmptyString()
                .Filter(s => !string.IsNullOrWhiteSpace(s.Get) && s.Get.Length <= 20)
                .Convert(s => new NonNullOrWhiteSpacesStringMaxWithMaxLength(s.Get), nnows => NonEmptyString.NewNonEmptyString(nnows.Get));
        }
    }

    public class NonNullOrWhiteSpacesStringMaxWithMaxLength
    {
        public string Get { get; }
        public NonNullOrWhiteSpacesStringMaxWithMaxLength(string value) => Get = value;
    }
}
