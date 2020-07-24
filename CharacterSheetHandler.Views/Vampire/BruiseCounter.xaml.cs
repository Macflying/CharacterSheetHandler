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
    /// Interaction logic for BruiseCounter.xaml
    /// </summary>
    public partial class BruiseCounter : UserControl
    {
        #region Header

        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register(
            nameof(Header), typeof(string),
            typeof(BruiseCounter));

        public string Header
        {
            get { return (string)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        #endregion Header

        #region Malus

        public static readonly DependencyProperty MalusProperty =
            DependencyProperty.Register(
            nameof(Malus), typeof(string),
            typeof(BruiseCounter));

        public string Malus
        {
            get { return (string)GetValue(MalusProperty); }
            set { SetValue(MalusProperty, value); }
        }

        #endregion Malus

        public BruiseCounter()
        {
            InitializeComponent();
        }
    }
}
