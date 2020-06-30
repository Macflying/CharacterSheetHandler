using FsCheck;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CharacterSheetHandler.Models.Tests
{
    public class StringArbitrary
    {
        public static Arbitrary<NonNullOrWhiteSpacesStringMaxLength20> NonNullOrWhiteSpacesString()
        {
            return Arb.Default.NonEmptyString()
                .Filter(s => !string.IsNullOrWhiteSpace(s.Get) && s.Get.Length <= 20)
                .Convert(s => new NonNullOrWhiteSpacesStringMaxLength20(s.Get), nnows => NonEmptyString.NewNonEmptyString(nnows.Get));
        }
    }

    public class NonNullOrWhiteSpacesStringMaxLength20
    {
        public string Get { get; }
        public NonNullOrWhiteSpacesStringMaxLength20(string value) => Get = value;
    }
}
