using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AgendaMujer.Apps.Mobile.Views.Home
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ArletteContrerasView : ContentPage
    {
        private bool _appeared;

        public ArletteContrerasView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (_appeared)
                return;

            _appeared = true;
            _ = Browser.OpenAsync("http://arlettecontreras.com", new BrowserLaunchOptions
            {
                LaunchMode = BrowserLaunchMode.SystemPreferred,
                TitleMode = BrowserTitleMode.Default,
                PreferredToolbarColor = Color.FromHex("#FF95B1")
            });
        }

        private void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            _ = Browser.OpenAsync("http://arlettecontreras.com", new BrowserLaunchOptions
            {
                LaunchMode = BrowserLaunchMode.SystemPreferred,
                TitleMode = BrowserTitleMode.Default,
                PreferredToolbarColor = Color.FromHex("#FF95B1")
            });
        }
    }
}