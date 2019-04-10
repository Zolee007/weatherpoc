using System;
using System.Threading.Tasks;
using Acr.UserDialogs;
using AutoMapper;
using MvvmCross.ViewModels;
using Plugin.Connectivity.Abstractions;
using Refit;
using Weather.Models.Exceptions;

namespace Weather.ViewModels
{
    public abstract class BaseViewModel : MvxViewModel
    {
        protected BaseViewModel(
            IConnectivity connectivity,
            IUserDialogs dialogs,
            IMapper mapper)
        {
            Connectivity = connectivity ?? throw new ArgumentNullException(nameof(connectivity));
            DialogService = dialogs ?? throw new ArgumentNullException(nameof(dialogs));
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }
            set
            {
                this.SetProperty(ref _isBusy, value);
            }
        }

        protected IConnectivity Connectivity { get; }
        protected IUserDialogs DialogService { get; }
        protected IMapper Mapper { get; }

        protected async Task ExecuteWithLoading(Func<Task> loader)
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;

            try
            {
                await loader();
            }
            catch (Exception ex)
            {
                DialogService.HideLoading();
                DialogService.Alert(ex.Message, "Error");
            }
            finally
            {
                DialogService.HideLoading();
                await this.RaiseAllPropertiesChanged();
                IsBusy = false;
            }
        }

        protected async Task TryExecuteNetworkRequest(Func<Task> request, bool overrideNetCheck)
        {
            try
            {
                if (Connectivity.IsConnected || overrideNetCheck)
                {
                    await request();
                }
                else
                {
                    throw new NoInternetException();
                }
            }
            catch (ApiException ae)
            {
                DialogService.Alert(ae.ReasonPhrase, $"{ae.StatusCode}");
            }
            catch (TimeoutException)
            {
                DialogService.Alert("Request timed out", "Timout");
            }
            catch (NoInternetException)
            {
                DialogService.Alert("No internet connection!", "Network Error");
            }
            catch (Exception ex)
            {
                DialogService.Alert(ex.Message, "Other Error");
            }
        }
    }
}
