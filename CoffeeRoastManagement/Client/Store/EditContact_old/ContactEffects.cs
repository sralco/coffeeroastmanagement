using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Fluxor;
//using CoffeeRoastManagement.Client.Features.Contact.Store;

namespace CoffeeRoastManagement.Client.Store.EditContact
{
    public class ContactEffects
    {
        private readonly HttpClient _httpClient;
        private readonly IDispatcher _dispatcher;

        public ContactEffects(HttpClient httpClient, IDispatcher dispatcher)
        {
            _httpClient = httpClient;
            _dispatcher = dispatcher;
        }

        [EffectMethod]
        public async Task SubmitContact(ContactSubmitAction action, IDispatcher dispatcher)
        {
            //var respone = await _httpClient.PostAsJsonAsync("api/contact", action.Contact);
            //if (respone.IsSuccessStatusCode)
            //{
            //    dispatcher.Dispatch(new ContactSubmitSuccessAction());
            //    dispatcher.Dispatch(new ContactsLoadAction());
            //}else
            //{
            //    dispatcher.Dispatch(new ContactSubmitFailureAction(respone.ReasonPhrase));
            //}
        }
    }
}
