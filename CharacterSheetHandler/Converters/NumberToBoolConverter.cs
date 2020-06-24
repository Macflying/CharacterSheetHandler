using System;
using System.Globalization;
using System.Windows.Data;

namespace CharacterSheetHandler.Converters
{
    [ValueConversion(typeof(int), typeof(bool), ParameterType = typeof(int))]
    public class NumberToBoolConverter : BaseValueConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || parameter == null)
                return false;

            if (!int.TryParse(value.ToString(), out int testedValue) || !int.TryParse(parameter.ToString(), out int referenceValue))
                return false;

            return testedValue >= referenceValue;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return int.Parse(parameter.ToString());
        }
    }
}