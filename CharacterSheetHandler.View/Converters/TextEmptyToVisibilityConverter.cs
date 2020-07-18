using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace CharacterSheetHandler.Converters
{
    [ValueConversion(typeof(string), typeof(Visibility), ParameterType = typeof(Visibility))]
    public class TextEmptyToVisibilityConverter : IValueConverter
    {
        public static TextEmptyToVisibilityConverter NullOrEmptyToVisible { get; }
        public static TextEmptyToVisibilityConverter NullOrEmptyToHidden { get; }
        public static TextEmptyToVisibilityConverter NullOrEmptyToCollapsed { get; }

        public static TextEmptyToVisibilityConverter NullOrWhiteSpacesToVisible { get; }
        public static TextEmptyToVisibilityConverter NullOrWhiteSpacesToHidden { get; }
        public static TextEmptyToVisibilityConverter NullOrWhiteSpacesToCollapsed { get; }

        private readonly Predicate<string> _predicate;
        private readonly Visibility _visibility;

        private TextEmptyToVisibilityConverter(Predicate<string> predicate, Visibility visibility)
        {
            _predicate = predicate;
            _visibility = visibility;
        }

        static TextEmptyToVisibilityConverter()
        {
            NullOrEmptyToVisible = new TextEmptyToVisibilityConverter(string.IsNullOrEmpty, Visibility.Visible);
            NullOrEmptyToHidden = new TextEmptyToVisibilityConverter(string.IsNullOrEmpty, Visibility.Hidden);
            NullOrEmptyToCollapsed = new TextEmptyToVisibilityConverter(string.IsNullOrEmpty, Visibility.Collapsed);

            NullOrWhiteSpacesToVisible = new TextEmptyToVisibilityConverter(string.IsNullOrWhiteSpace, Visibility.Visible);
            NullOrWhiteSpacesToHidden = new TextEmptyToVisibilityConverter(string.IsNullOrWhiteSpace, Visibility.Hidden);
            NullOrWhiteSpacesToCollapsed = new TextEmptyToVisibilityConverter(string.IsNullOrWhiteSpace, Visibility.Collapsed);
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return Visibility.Visible;

            if (parameter == null || !Enum.TryParse(parameter.ToString(), out Visibility fallBackVisibility))
                fallBackVisibility = Visibility.Collapsed;

            return _predicate(value.ToString())
                       ? _visibility
                       : fallBackVisibility;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}