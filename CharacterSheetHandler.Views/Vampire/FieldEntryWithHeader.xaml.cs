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
    /// Interaction logic for FieldEntryWithHeader.xaml
    /// </summary>
    public partial class FieldEntryWithHeader : UserControl
    {
        #region Header

        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register(
            nameof(Header), typeof(string),
            typeof(FieldEntryWithHeader));

        public string Header
        {
            get { return (string)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        #endregion Header

        #region Text

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(
            nameof(Text),
            typeof(string),
            typeof(FieldEntryWithHeader));

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        #endregion Text

        public FieldEntryWithHeader()
        {
            InitializeComponent();
        }
    }
}
