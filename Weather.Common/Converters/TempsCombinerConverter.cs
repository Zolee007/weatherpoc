using System;
using System.Globalization;
using MvvmCross.Converters;

namespace Weather.Converters
{
    public class TempsCombinerConverter : MvxValueConverter<Models.Weather, string>
    {
        public const string TempSign = "°";
        public const string NoData = "n/a";

        protected override string Convert(Models.Weather value, Type targetType, object parameter, CultureInfo culture)
        {
            var sign = parameter?.ToString() ?? TempSign;
            var minTemp = ((int)value?.TemperatureMin).ToString() ?? NoData;
            var maxTemp = ((int)value?.TemperatureMax).ToString() ?? NoData;
            return $"{minTemp}{sign}/{maxTemp}{sign}";
        }
    }
}
