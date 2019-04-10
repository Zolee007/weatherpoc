// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace Weather.iOS.Views.Cells
{
    [Register(ForecastCell.CellId)]
    partial class ForecastCell
    {
        [Outlet]
        UIKit.UILabel DayName { get; set; }

        [Outlet]
        UIKit.UILabel Temps { get; set; }

        [Outlet]
        UIKit.UIImageView WeatherIcon { get; set; }

        void ReleaseDesignerOutlets()
        {
            if (DayName != null)
            {
                DayName.Dispose();
                DayName = null;
            }

            if (Temps != null)
            {
                Temps.Dispose();
                Temps = null;
            }

            if (WeatherIcon != null)
            {
                WeatherIcon.Dispose();
                WeatherIcon = null;
            }
        }
    }
}