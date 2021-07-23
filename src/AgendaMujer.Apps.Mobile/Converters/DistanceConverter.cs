using AgendaMujer.Apps.Mobile.Models;
using System;
using System.Globalization;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace AgendaMujer.Apps.Mobile.Converters
{
    public class DistanceConverter : IValueConverter
    {
        //public static Location _lastKnownLocation;
        //public static DateTime _lastKnownLocationDateTime;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is CentroAyuda helpCenter)
            {
                var location = Geolocation.GetLastKnownLocationAsync().Result;
                var distance = Distance.BetweenPositions(new Position(helpCenter.Latitud, helpCenter.Longitud), new Position(location.Latitude, location.Longitude));
                return $"{distance.Kilometers.ToString("0.00")} KM";
                //if (_lastKnownLocation is null or ) {
                //    _lastKnownLocationDateTime = DateTime.UtcNow
                //}
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}