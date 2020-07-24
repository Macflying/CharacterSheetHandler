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
    /// Interaction logic for SkillGaugeWithHeader.xaml
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
