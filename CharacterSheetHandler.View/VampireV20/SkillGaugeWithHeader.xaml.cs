using System.Windows;
using System.Windows.Controls;

namespace CharacterSheetHandler.VampireV20
{
    /// <summary>
    /// Logique d'interaction pour SkillGaugeWithHeader.xaml
    /// </summary>
    public partial class SkillGaugeWithHeader : UserControl
    {
        #region Header

        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register(
            nameof(Header), typeof(string),
            typeof(SkillGaugeWithHeader));

        public string Header
        {
            get { return (string)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        #endregion Header

        #region Level

        public static readonly DependencyProperty LevelProperty =
            DependencyProperty.Register(
            nameof(Level), typeof(int),
            typeof(SkillGaugeWithHeader));

        public int Level
        {
            get { return (int)GetValue(LevelProperty); }
            set { SetValue(LevelProperty, value); }
        }

        #endregion Level

        public SkillGaugeWithHeader()
        {
            InitializeComponent();
        }
    }
}