using System;
using System.Globalization;
using MvvmCross.Converters;

namespace Weather.Converters
{
    public class DayOfMonthConverter : MvxValueConverter<DateTime, string>
    {
        public const string Format = "m";
        public const string NoData = "n/a";

        protected override string Convert(DateTime value, Type targetType, object parameter, CultureInfo culture)
        {
            return value != DateTime.MinValue ? value.ToString(Format) : NoData;
        }
    }
}
