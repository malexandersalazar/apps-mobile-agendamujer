using AgendaMujer.Apps.Mobile.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AgendaMujer.Apps.Mobile.Services.Business
{
    public class HelpCenterDataStore : IDataStore<CentroAyuda>
    {
        private static HttpClient _httpClient = new HttpClient();
        private List<CentroAyuda> _items;

        public Task<bool> AddItemAsync(CentroAyuda item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<CentroAyuda> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CentroAyuda>> GetItemsAsync(bool forceRefresh = false)
        {
            if (_items is object)
                return _items;

            string jsonResponse = await _httpClient.GetStringAsync("https://starlettecontreras001.z20.web.core.windows.net/data/directorio.json");
            _items = JsonConvert.DeserializeObject<List<CentroAyuda>>(jsonResponse);
            foreach (var item in _items)
                if (item.Tipo == "CEM_COMISARIA" && item.Nombre.IndexOf("CEM COMISARIA") == -1)
                    item.Nombre = item.Nombre.Replace("COMISARIA", "CEM COMISARIA");
                else if (item.Tipo == "CEM" && item.Nombre.IndexOf("CEM") == -1)
                    item.Nombre = item.Nombre.Insert(0, "CEM ");
                else if (item.Tipo == "MAD")
                    item.Nombre = item.Nombre.Insert(0, "DEFENSORÍA ");

            return _items;
        }

        public Task<bool> UpdateItemAsync(CentroAyuda item)
        {
            throw new NotImplementedException();
        }
    }
}