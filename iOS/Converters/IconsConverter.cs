using System;
using System.Globalization;
using MvvmCross.Converters;
using UIKit;
using Weather.Models;

namespace Weather.iOS.Converters
{
    public class IconsConverter : MvxValueConverter<Models.Icons, UIImage>
    {
        protected override UIImage Convert(Icons value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value)
            {
                case Icons.Sunny:
                    return UIImage.FromBundle("Sunny");
                case Icons.Cloudy:
                    return UIImage.FromBundle("Cloudy");
                case Icons.Rainy:
                    return UIImage.FromBundle("Rainy");
                case Icons.Other:
                default:
                    return UIImage.FromBundle("Other");
            }
        }
    }
}
