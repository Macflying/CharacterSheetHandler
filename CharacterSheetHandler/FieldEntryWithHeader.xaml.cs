using System.Windows;
using System.Windows.Controls;

namespace CharacterSheetHandler
{
    /// <summary>
    /// Logique d'interaction pour FieldEntryWithHeader.xaml
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
            nameof(Text), typeof(string),
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