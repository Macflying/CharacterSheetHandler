using System.Windows;
using System.Windows.Controls;

namespace CharacterSheetHandler.VampireV20
{
    /// <summary>
    /// Interaction logic for WillpowerGauge.xaml
    /// </summary>
    public partial class WillpowerGauge : UserControl
    {
        #region MaxLevel

        public static readonly DependencyProperty MaxLevelProperty =
            DependencyProperty.Register(
            nameof(MaxLevel), typeof(int),
            typeof(WillpowerGauge));

        public int MaxLevel
        {
            get { return (int)GetValue(MaxLevelProperty); }
            set { SetValue(MaxLevelProperty, value); }
        }

        #endregion MaxLevel

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