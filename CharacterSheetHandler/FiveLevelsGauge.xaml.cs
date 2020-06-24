using System.Windows;
using System.Windows.Controls;

namespace CharacterSheetHandler
{
    /// <summary>
    /// Logique d'interaction pour FiveLevelsGauge.xaml
    /// </summary>
    public partial class FiveLevelsGauge : UserControl
    {
        #region Level

        public static readonly DependencyProperty LevelProperty =
            DependencyProperty.Register(
            nameof(Level), typeof(int),
            typeof(FiveLevelsGauge));

        public int Level
        {
            get { return (int)GetValue(LevelProperty); }
            set { SetValue(LevelProperty, value); }
        }

        #endregion Level

        public FiveLevelsGauge()
        {
            InitializeComponent();
        }
    }
}