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
    public class HelpCentersMapViewModel : BaseViewModel
    {
        private readonly HelpCenterDataStore helpCenterDataStore;

        private MapSpan region;

        public MapSpan Region
        {
            get => region;
            set => SetProperty(ref region, value);
        }

        private IEnumerable<CentroAyuda> helpCenters;

        public IEnumerable<CentroAyuda> HelpCenters
        {
            get => helpCenters;
            set { SetProperty(ref helpCenters, value); }
        }

        private bool skipRefresh;

        public bool SkipRefresh
        {
            get => skipRefresh;
            set => SetProperty(ref skipRefresh, value);
        }

        private Command loadCommand;
        public Command LoadCommand => loadCommand ?? (loadCommand = new Command(LoadExecute));

        private Command moveEndCommand;
        public Command MoveEndCommand => moveEndCommand ?? (moveEndCommand = new Command(MoveEndExecute));

        public HelpCentersMapViewModel(NavigationService navigationService, HelpCenterDataStore helpCenterDataStore) : base(navigationService)
        {
            this.helpCenterDataStore = helpCenterDataStore;
        }

        private async void LoadExecute(object obj)
        {
            var location = await Geolocation.GetLastKnownLocationAsync();
            Region = MapSpan.FromCenterAndRadius(new Position(location.Latitude, location.Longitude), Distance.FromKilometers(3));
        }

        private async void MoveEndExecute()
        {
            if (SkipRefresh)
            {
                SkipRefresh = false;
                return;
            }

            var allHelpCenters = await helpCenterDataStore.GetItemsAsync();
            HelpCenters = allHelpCenters.Where(x => Distance.BetweenPositions(new Position(x.Latitud, x.Longitud), Region.Center).Kilometers <= Distance.FromKilometers(15).Kilometers);
        }

        public void SelectHelpCenterExecute(CentroAyuda helpCenter)
        {
            _ = NavigationService.NavigateToAsync<HelpCentersDetailViewModel>(helpCenter);
        }
    }
}