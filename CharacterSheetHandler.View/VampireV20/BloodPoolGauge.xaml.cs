using System.Windows;
using System.Windows.Controls;

namespace CharacterSheetHandler.VampireV20
{
    /// <summary>
    /// Interaction logic for BloodPoolGauge.xaml
    /// </summary>
    public partial class BloodPoolGauge : UserControl
    {
        #region Level

        public static readonly DependencyProperty LevelProperty =
            DependencyProperty.Register(
            nameof(Level), typeof(int),
            typeof(BloodPoolGauge));

        public int Level
        {
            get { return (int)GetValue(LevelProperty); }
            set { SetValue(LevelProperty, value); }
        }

        #endregion Level

        public BloodPoolGauge()
        {
            InitializeComponent();
        }
    }
}