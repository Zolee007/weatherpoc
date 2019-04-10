// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace Weather.iOS.Views
{
	[Register ("HomeView")]
	partial class HomeView
	{
		[Outlet]
		UIKit.UIButton ChangeCity { get; set; }

		[Outlet]
		UIKit.UIBarButtonItem ChangeCityBarButton { get; set; }

		[Outlet]
		UIKit.UILabel CurrentTemp { get; set; }

		[Outlet]
		UIKit.UILabel CurrentWeatherCondition { get; set; }

		[Outlet]
		UIKit.UIImageView CurrentWeatherImage { get; set; }

		[Outlet]
		UIKit.UITableView ForecastTable { get; set; }

		[Outlet]
		UIKit.UISwitch IsMockSwitch { get; set; }

		[Outlet]
		UIKit.UILabel LocationName { get; set; }

		[Outlet]
		UIKit.UILabel MaxTemp { get; set; }

		[Outlet]
		UIKit.UILabel MinTemp { get; set; }

		[Outlet]
		UIKit.UILabel PoweredBy { get; set; }

		[Outlet]
		UIKit.UIButton ReloadButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (ChangeCity != null) {
				ChangeCity.Dispose ();
				ChangeCity = null;
			}

			if (CurrentTemp != null) {
				CurrentTemp.Dispose ();
				CurrentTemp = null;
			}

			if (CurrentWeatherCondition != null) {
				CurrentWeatherCondition.Dispose ();
				CurrentWeatherCondition = null;
			}

			if (CurrentWeatherImage != null) {
				CurrentWeatherImage.Dispose ();
				CurrentWeatherImage = null;
			}

			if (ForecastTable != null) {
				ForecastTable.Dispose ();
				ForecastTable = null;
			}

			if (IsMockSwitch != null) {
				IsMockSwitch.Dispose ();
				IsMockSwitch = null;
			}

			if (LocationName != null) {
				LocationName.Dispose ();
				LocationName = null;
			}

			if (MaxTemp != null) {
				MaxTemp.Dispose ();
				MaxTemp = null;
			}

			if (MinTemp != null) {
				MinTemp.Dispose ();
				MinTemp = null;
			}

			if (PoweredBy != null) {
				PoweredBy.Dispose ();
				PoweredBy = null;
			}

			if (ReloadButton != null) {
				ReloadButton.Dispose ();
				ReloadButton = null;
			}

			if (ChangeCityBarButton != null) {
				ChangeCityBarButton.Dispose ();
				ChangeCityBarButton = null;
			}
		}
	}
}
