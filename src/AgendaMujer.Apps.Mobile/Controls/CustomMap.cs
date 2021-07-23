using System;
using System.Timers;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace AgendaMujer.Apps.Mobile.Controls
{
    public class CustomMap : Map
    {
        public event EventHandler Load;

        private Timer _moveTimer;

        public event EventHandler MoveEnd;

        public CustomMap()
        {
            PropertyChanged += CustomMap_PropertyChanged;
        }

        private void CustomMap_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(VisibleRegion) && Region is object)
                VisibleRegionChanged();
        }

        private void VisibleRegionChanged()
        {
            _moveTimer?.Stop();
            _moveTimer = new Timer(500);
            _moveTimer.AutoReset = false;
            _moveTimer.Elapsed += (s, e) =>
            {
                Region = VisibleRegion;
                MoveEnd?.Invoke(this, EventArgs.Empty);
            };
            _moveTimer.Start();
        }

        public MapSpan Region
        {
            get { return (MapSpan)GetValue(RegionProperty); }
            set { SetValue(RegionProperty, value); }
        }

        public static readonly BindableProperty RegionProperty = BindableProperty.Create(
            propertyName: nameof(Region),
            returnType: typeof(MapSpan),
            declaringType: typeof(CustomMap),
            propertyChanged: RegionPropertyChanged);

        private static void RegionPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var map = (CustomMap)bindable;
            map.MoveToRegion((MapSpan)newValue);
        }

        public void InvokeLoad()
        {
            Load?.Invoke(this, EventArgs.Empty);
        }
    }
}