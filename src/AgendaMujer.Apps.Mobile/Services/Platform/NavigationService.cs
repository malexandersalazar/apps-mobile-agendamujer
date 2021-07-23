using AgendaMujer.Apps.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using TinyIoC;
using Xamarin.Forms;

namespace AgendaMujer.Apps.Mobile.Services.Platform
{
    public class NavigationService
    {
        public static void Init(object obj) => Init(obj.GetType());

        public static void Init(Type type)
        {
            var assemblyTypes = Assembly.GetAssembly(type).GetTypes();
            foreach (var assemblyType in assemblyTypes)
            {
                if (assemblyType.IsSubclassOf(typeof(BaseViewModel)))
                {
                    var viewModelName = assemblyType.Name;
                    var viewType = GetPageTypeForViewModel(assemblyType);
                    Routing.RegisterRoute(viewModelName, viewType);
                }
            }
        }

        private static Type GetPageTypeForViewModel(Type viewModelType)
        {
            if (viewModelType.FullName is object)
            {
                var viewFullName = viewModelType.FullName.Replace(".ViewModels.", ".Views.").Replace("ViewModel", "View");
                var viewType = Type.GetType(viewFullName);
                if (viewType is object)
                    return viewType;
            }

            throw new KeyNotFoundException($"No map for ${viewModelType} was found on navigation mappings");
        }

        public async Task NavigateToAsync<T>(object data = null) where T : BaseViewModel
        {
            await Shell.Current.GoToAsync(typeof(T).Name);
            (Shell.Current.CurrentPage.BindingContext as BaseViewModel)?.Initialize(data);
        }
    }
}