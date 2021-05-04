using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using Fluxor;
using CoffeeRoastManagement.Client.Store.Features.EditContact.Actions;

namespace CoffeeRoastManagement.Client.Store.Features.EditContact.Effects
{
    public class StocksEffects
    {
        private readonly HttpClient _httpClient;

        public StocksEffects(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [EffectMethod(typeof(ContactsLoadAction))]
        public async Task LoadStocks(IDispatcher dispatcher)
        {
            var stocks = await _httpClient.GetFromJsonAsync<CoffeeRoastManagement.Shared.Entities.Stock[]>("api/stock");
            dispatcher.Dispatch(new StocksSetAction(stocks));
        }

        //[EffectMethod]
        //public async Task DeleteContact(StocksDeleteAction action, IDispatcher dispatcher)
        //{
        //    var result = await _httpClient.DeleteAsync($"api/contact/{action.Contact.Id}");
        //    if (result.IsSuccessStatusCode)
        //    {
        //        dispatcher.Dispatch(new ContactDeleteSuccessAction());
        //    }else
        //    {
        //        dispatcher.Dispatch(new ContactDeleteFailureAction(result.ReasonPhrase));
        //    }
        //    dispatcher.Dispatch(new ContactsLoadAction());
        //}

        //[EffectMethod]
        //public async Task SaveContact(ContactsSaveAction action, IDispatcher dispatcher)
        //{
        //    if (action.Contact.Id == 0)
        //    {
        //        var result = await _httpClient.PostAsJsonAsync("api/contact", action.Contact);
        //        if (!result.IsSuccessStatusCode)
        //        {
        //            dispatcher.Dispatch(new ContactCreateFailureAction(result.ReasonPhrase));
        //        }else
        //        {
        //            dispatcher.Dispatch(new ContactCreateSuccessAction());
        //        }
        //    }
        //    else
        //    {
        //        var result = await _httpClient.PutAsJsonAsync("api/contact", action.Contact);
        //        if (!result.IsSuccessStatusCode)
        //        {
        //            dispatcher.Dispatch(new ContactUpdateFailureAction(result.ReasonPhrase));
        //        }
        //        else
        //        {
        //            dispatcher.Dispatch(new ContactUpdateSuccessAction());
        //        }
        //    }
        //    dispatcher.Dispatch(new ContactsLoadAction());
        //}
    }
}
