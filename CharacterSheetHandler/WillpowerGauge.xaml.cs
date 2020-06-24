using System.Windows;
using System.Windows.Controls;

namespace CharacterSheetHandler
{
    /// <summary>
    /// Interaction logic for WillpowerGauge.xaml
    /// </summary>
    public partial class WillpowerGauge : UserControl
    {
        #region Level

        public static readonly DependencyProperty LevelProperty =
            DependencyProperty.Register(
            nameof(Level), typeof(int),
            typeof(WillpowerGauge));

        public int Level
        {
            get { return (int)GetValue(LevelProperty); }
            set { SetValue(LevelProperty, value); }
        }

        #endregion Level

        public WillpowerGauge()
        {
            InitializeComponent();
        }
    }
}