using System.Collections.Generic;
using System.Windows.Controls;

namespace CharacterSheetHandler
{
    /// <summary>
    /// Logique d'interaction pour Abilities.xaml
    /// </summary>
    public partial class Abilities : UserControl
    {
        public Abilities()
        {
            InitializeComponent();
            DataContext = new List<Skill>()
            {
                new Skill("Alertness", 2),
                new Skill("Crafts", 3),
            };
        }
    }

    public class Skill
    {
        public Skill(string name, int level)
        {
            Name = name;
            Level = level;
        }

        public string Name { get; set; }
        public int Level { get; set; }
    }
}