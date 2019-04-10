using System;
using System.Globalization;
using MvvmCross.Converters;

namespace Weather.Converters
{
    public class TempConverter : MvxValueConverter<double, string>
    {
        public const string TempSign = "°";

        protected override string Convert(double value, Type targetType, object parameter, CultureInfo culture)
        {
            var sign = parameter?.ToString() ?? TempSign;
            return $"{(int)value}{sign}";
        }
    }
}
