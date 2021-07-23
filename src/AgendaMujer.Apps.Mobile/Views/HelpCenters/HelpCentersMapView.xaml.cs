using AgendaMujer.Apps.Mobile.Controls;
using AgendaMujer.Apps.Mobile.Models;
using AgendaMujer.Apps.Mobile.ViewModels.HelpCenters;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AgendaMujer.Apps.Mobile.Views.HelpCenters
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HelpCentersMapView : ContentPage
    {
        public HelpCentersMapView()
        {
            InitializeComponent();
        }

        private void CustomPin_MarkerClicked(object sender, Xamarin.Forms.Maps.PinClickedEventArgs e)
        {
            var vm = (HelpCentersMapViewModel)BindingContext;
            vm.SkipRefresh = true;
        }

        private void CustomPin_InfoWindowClicked(object sender, Xamarin.Forms.Maps.PinClickedEventArgs e)
        {
            var vm = (HelpCentersMapViewModel)BindingContext;
            vm.SelectHelpCenterExecute((CentroAyuda)((CustomPin)sender).BindingContext);
        }
    }
}