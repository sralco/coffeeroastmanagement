using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using Fluxor;
using CoffeeRoastManagement.Shared.Entities;

namespace CoffeeRoastManagement.Client.Features.Contact.Store
{
    public class ContactsEffects
    {
        private readonly HttpClient _httpClient;

        public ContactsEffects(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [EffectMethod(typeof(ContactsLoadAction))]
        public async Task LoadContacts(IDispatcher dispatcher)
        {
            var contacts = await _httpClient.GetFromJsonAsync<CoffeeRoastManagement.Shared.Entities.Contact[]>("api/contact");
            dispatcher.Dispatch(new ContactsSetAction(contacts));
        }

        [EffectMethod]
        public async Task DeleteContact(ContactsDeleteAction action, IDispatcher dispatcher)
        {
            await _httpClient.DeleteAsync($"api/contact/{action.Contact.Id}");
            dispatcher.Dispatch(new ContactsLoadAction());
        }

        [EffectMethod]
        public async Task SaveContact(ContactsSaveAction action, IDispatcher dispatcher)
        {
            if (action.Contact.Id == 0)
            {
                await _httpClient.PostAsJsonAsync("api/contact", action.Contact);
                //snackbar.Add("Contact saved.", Severity.Success);
            }
            else
            {
                await _httpClient.PutAsJsonAsync("api/contact", action.Contact);
                //snackbar.Add("Contact updated.", Severity.Success
            }
            dispatcher.Dispatch(new ContactsLoadAction());
        }
    }
}
