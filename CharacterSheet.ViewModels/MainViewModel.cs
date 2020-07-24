using CharacterSheetHandler.ViewModels.Vampire;

using System;
using System.Collections.Generic;
using System.Text;

namespace CharacterSheetHandler.ViewModels
{
    public class MainViewModel
    {
        public VampireSheetViewModel Context { get; set; } = new VampireSheetViewModel();
    }
}
