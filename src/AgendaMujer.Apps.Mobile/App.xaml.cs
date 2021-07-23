using AgendaMujer.Apps.Mobile.Services.Business;
using AgendaMujer.Apps.Mobile.Services.Platform;
using TinyIoC;
using Xamarin.Forms;

namespace AgendaMujer.Apps.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            ConfigureServices();
            InitializeComponent();

            MainPage = new AppShell();
        }

        private void ConfigureServices()
        {
            NavigationService.Init(this);
            TinyIoCContainer.Current.Register<NavigationService>().AsSingleton();
            TinyIoCContainer.Current.Register<HelpCenterDataStore>().AsSingleton();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}