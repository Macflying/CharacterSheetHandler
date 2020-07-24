using System;
using System.Globalization;
using System.Windows.Data;

namespace CharacterSheetHandler.Views.Converters
{
    [ValueConversion(typeof(int), typeof(bool), ParameterType = typeof(int))]
    public class NumberToBoolConverter : BaseValueConverter
    {
        public static NumberToBoolConverter SuperiorToTrue { get; }
        public static NumberToBoolConverter StrictlySuperiorToTrue { get; }
        public static NumberToBoolConverter InferiorToTrue { get; }
        public static NumberToBoolConverter StrictlyInferiorToTrue { get; }

        private readonly Func<int, int, bool> _comparison;

        static NumberToBoolConverter()
        {
            SuperiorToTrue = new NumberToBoolConverter((test, refe) => test >= refe);
            StrictlySuperiorToTrue = new NumberToBoolConverter((test, refe) => test > refe);
            InferiorToTrue = new NumberToBoolConverter((test, refe) => test <= refe);
            StrictlyInferiorToTrue = new NumberToBoolConverter((test, refe) => test < refe);
        }

        private NumberToBoolConverter(Func<int, int, bool> comparison)
        {
            _comparison = comparison;
        }

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || parameter == null)
                return false;

            if (!int.TryParse(value.ToString(), out int testedValue) || !int.TryParse(parameter.ToString(), out int referenceValue))
                return false;

            return _comparison(testedValue, referenceValue);
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return int.Parse(parameter.ToString());
        }
    }
}