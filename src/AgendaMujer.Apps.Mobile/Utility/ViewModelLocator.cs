using AgendaMujer.Apps.Mobile.ViewModels;
using System;
using System.Globalization;
using System.Reflection;
using TinyIoC;
using Xamarin.Forms;

namespace AgendaMujer.Apps.Mobile.Utility
{
    public class ViewModelLocator
    {
        public static readonly BindableProperty AutoWireViewModelProperty =
            BindableProperty.CreateAttached("AutoWireViewModel", typeof(bool),
                typeof(ViewModelLocator), default(bool),
                propertyChanged: OnAutoWireViewModelChanged);

        public static bool GetAutoWireViewModel(BindableObject bindable)
        {
            return (bool)bindable.GetValue(AutoWireViewModelProperty);
        }

        public static void SetAutoWireViewModel(BindableObject bindable, bool value)
        {
            bindable.SetValue(AutoWireViewModelProperty, value);
        }

        private static void OnAutoWireViewModelChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is Element view))
                return;

            var viewType = view.GetType();
            if (viewType.FullName is object)
            {
                var viewModelName = viewType.FullName.Replace("View", "ViewModel");
                var viewModelType = Type.GetType(viewModelName);
                if (viewModelType is null)
                    return;
                var viewModel = TinyIoCContainer.Current.Resolve(viewModelType);
                view.BindingContext = viewModel;
            }
        }
    }
}