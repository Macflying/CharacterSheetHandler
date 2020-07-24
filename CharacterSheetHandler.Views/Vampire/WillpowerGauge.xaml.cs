using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CharacterSheetHandler.Views.Vampire
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
