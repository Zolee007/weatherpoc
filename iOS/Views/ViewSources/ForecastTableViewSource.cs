using Foundation;
using MvvmCross.Platforms.Ios.Binding.Views;
using UIKit;
using Weather.iOS.Views.Cells;

namespace Weather.iOS.Views.ViewSources
{
    public class ForecastTableViewSource : MvxTableViewSource
    {
        public ForecastTableViewSource(UITableView tableView) : base(tableView)
        {
        }

        protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
        {
            return tableView.DequeueReusableCell(ForecastCell.CellId);
        }
    }
}
