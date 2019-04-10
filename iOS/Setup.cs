using MvvmCross;
using MvvmCross.Platforms.Ios.Core;
using Weather.Settings;

namespace Weather.iOS
{
    public class Setup : MvxIosSetup<App>
    {
        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();

            Mvx.IoCProvider.RegisterSingleton<ISettings>(Mvx.IoCProvider.IoCConstruct<Settings.Settings>());
        }
    }
}
