using System;
using System.Globalization;
using System.Windows.Data;

namespace CharacterSheetHandler.Views.Converters
{
    [ValueConversion(typeof(int), typeof(int), ParameterType = typeof(int))]
    internal class GetMaxNumberValueConverter : BaseValueConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || parameter == null)
                return false;

            if (!int.TryParse(value.ToString(), out int testedValue) || !int.TryParse(parameter.ToString(), out int referenceValue))
                return false;

            return Math.Max(testedValue, referenceValue);
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}