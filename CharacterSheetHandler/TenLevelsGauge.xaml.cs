using System.Windows;
using System.Windows.Controls;

namespace CharacterSheetHandler
{
    /// <summary>
    /// Interaction logic for TenLevelsGauge.xaml
    /// </summary>
    public partial class TenLevelsGauge : UserControl
    {
        #region Level

        public static readonly DependencyProperty LevelProperty =
            DependencyProperty.Register(
            nameof(Level), typeof(int),
            typeof(TenLevelsGauge));

        public int Level
        {
            get { return (int)GetValue(LevelProperty); }
            set { SetValue(LevelProperty, value); }
        }

        #endregion Level

        public TenLevelsGauge()
        {
            InitializeComponent();
        }
    }
}