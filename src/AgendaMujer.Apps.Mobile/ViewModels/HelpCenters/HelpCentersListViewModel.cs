using AgendaMujer.Apps.Mobile.Models;
using AgendaMujer.Apps.Mobile.Services.Business;
using AgendaMujer.Apps.Mobile.Services.Platform;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace AgendaMujer.Apps.Mobile.ViewModels.HelpCenters
{
    public class HelpCentersListViewModel : BaseViewModel
    {
        private readonly HelpCenterDataStore helpCenterDataStore;

        private IEnumerable<CentroAyuda> helpCenters;

        public IEnumerable<CentroAyuda> HelpCenters
        {
            get => helpCenters;
            set { SetProperty(ref helpCenters, value); }
        }

        private Command selectHelpCenterCommand;

        public Command SelectHelpCenterCommand => selectHelpCenterCommand ?? (selectHelpCenterCommand = new Command<CentroAyuda>(SelectHelpCenterExecute));

        public HelpCentersListViewModel(NavigationService navigationService, HelpCenterDataStore helpCenterDataStore) : base(navigationService)
        {
            this.helpCenterDataStore = helpCenterDataStore;
        }

        public override async void Initialize(object data = null)
        {
            base.Initialize(data);
            var helpCenters = await helpCenterDataStore.GetItemsAsync();
            var lastKnownLocation = await Geolocation.GetLastKnownLocationAsync();
            foreach (var helpCenter in helpCenters)
                helpCenter.CurrentDistance = Distance.BetweenPositions(new Position(helpCenter.Latitud, helpCenter.Longitud), new Position(lastKnownLocation.Latitude, lastKnownLocation.Longitude)).Kilometers;
            HelpCenters = helpCenters.OrderBy(x => x.CurrentDistance);
        }

        private void SelectHelpCenterExecute(CentroAyuda helpCenter)
        {
            _ = NavigationService.NavigateToAsync<HelpCentersDetailViewModel>(helpCenter);
        }
    }
}