using System.Windows;
using System.Windows.Controls;

namespace CharacterSheetHandler
{
    /// <summary>
    /// Interaction logic for PathGauge.xaml
    /// </summary>
    public partial class PathGauge : UserControl
    {
        #region Level

        public static readonly DependencyProperty LevelProperty =
            DependencyProperty.Register(
            nameof(Level), typeof(int),
            typeof(PathGauge));

        public int Level
        {
            get { return (int)GetValue(LevelProperty); }
            set { SetValue(LevelProperty, value); }
        }

        #endregion Level

        public PathGauge() : base()
        {
            InitializeComponent();
        }
    }
}