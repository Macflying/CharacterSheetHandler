using System;
using System.Collections.Generic;
using System.Text;

using CharacterSheetHandler.Models;

namespace CharacterSheetHandler.ViewModels.Vampire
{
    internal static class ErrorsMessages
    {
        public static string UnknownError => "Unknown error.";

        public static string NullOrWhiteSpaceStringError => "Field shouldn't be left empty or consisting of only white spaces.";
        public static string NoExperienceError => "You need to fill in experience points.";
        public static string NoWeaknessError => "A vampire always has a weakness.";

        #region Name errors
        public static string EmptyNameError => "Name shouldn't be empty.";
        public static string TooLongNameError => $"Name shouldn't exceed {Constants.NameLength} characters";
        #endregion Name errors

        #region Level errors
        public static string LevelSuperiorToMaxError => "Level is exceeding maximum autorized.";
        public static string NegativeOrZeroLevelError => "Level cannot be negative or zero.";
        #endregion Level errors
    }
}
