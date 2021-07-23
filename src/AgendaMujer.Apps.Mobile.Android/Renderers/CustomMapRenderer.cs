using AgendaMujer.Apps.Mobile.Controls;
using AgendaMujer.Apps.Mobile.Droid.Renderers;
using AgendaMujer.Apps.Mobile.Models;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Android;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomMap), typeof(CustomMapRenderer))]

namespace AgendaMujer.Apps.Mobile.Droid.Renderers
{
    public class CustomMapRenderer : MapRenderer
    {
        private CustomMap _customMap;

        public CustomMapRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Map> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement is object)
                _customMap = (CustomMap)e.NewElement;
        }

        protected override MarkerOptions CreateMarker(Pin pin)
        {
            var customPin = (CustomPin)pin;

            var marker = new MarkerOptions();
            marker.SetPosition(new LatLng(customPin.Position.Latitude, customPin.Position.Longitude));
            marker.SetTitle(customPin.Label);
            marker.SetSnippet(customPin.Address);

            if (customPin.BindingContext is CentroAyuda helpCenter)
            {
                if (helpCenter.Tipo == "CEM_COMISARIA")
                    marker.SetIcon(BitmapDescriptorFactory.FromResource(Resource.Drawable.pin_cem_comisaria));
                else if (helpCenter.Tipo == "CEM")
                    marker.SetIcon(BitmapDescriptorFactory.FromResource(Resource.Drawable.pin_cem));
                else if (helpCenter.Tipo == "MAD")
                    marker.SetIcon(BitmapDescriptorFactory.FromResource(Resource.Drawable.pin_mad));
                else
                    throw new KeyNotFoundException();
            }

            return marker;
        }

        protected override void OnMapReady(GoogleMap map)
        {
            base.OnMapReady(map);
            _customMap.InvokeLoad();
        }
    }
}