using AgendaMujer.Apps.Mobile.Services.Platform;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.ObjectModel;

namespace AgendaMujer.Apps.Mobile.ViewModels
{
    public abstract class BaseViewModel : ObservableObject
    {
        public NavigationService NavigationService { get; }

        public BaseViewModel(NavigationService navigationService)
        {
            NavigationService = navigationService;
            EnsureInitializationAsync();
        }

        private async void EnsureInitializationAsync()
        {
            await Task.Delay(1500);
            if (!Initialized)
                Initialize();
        }

        private bool isBusy;

        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                SetProperty(ref isBusy, value);
                OnPropertyChanged(nameof(IsIdle));
            }
        }

        public bool IsIdle => !isBusy;

        private string title;

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        private bool initialized;

        public bool Initialized
        {
            get { return initialized; }
            set { SetProperty(ref initialized, value); }
        }

        public virtual void Initialize(object data = null)
        {
            Initialized = true;
        }
    }
}