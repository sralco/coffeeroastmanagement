using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using Fluxor;
using CoffeeRoastManagement.Client.Store.Features.EditRoast.Actions;

namespace CoffeeRoastManagement.Client.Store.Features.EditRoast.Effects
{
    public class RoastsEffects
    {
        private readonly HttpClient _httpClient;

        public RoastsEffects(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [EffectMethod(typeof(RoastsLoadAction))]
        public async Task LoadRoasts(IDispatcher dispatcher)
        {
            var roasts = await _httpClient.GetFromJsonAsync<CoffeeRoastManagement.Shared.Entities.Roast[]>("api/roast");
            Console.WriteLine($"roasts: {roasts.Length}");
            dispatcher.Dispatch(new RoastsSetAction(roasts));
            var stocks = await _httpClient.GetFromJsonAsync<CoffeeRoastManagement.Shared.Entities.Stock[]>("api/stock");
            Console.WriteLine($"stocks: {stocks.Length}");
            dispatcher.Dispatch(new RoastsSetStocksAction(stocks));
            dispatcher.Dispatch(new RoastsInitializedAction());
        }

        [EffectMethod]
        public async Task SaveRoast(RoastsSaveRoastAction action, IDispatcher dispatcher)
        {
            foreach (var gb in action.Roast.Beans)
            {
                if (gb.Id == 0)
                {
                    var result = await _httpClient.PostAsJsonAsync<CoffeeRoastManagement.Shared.Entities.GreenBlend>("api/greenblend", gb);
                    gb.Id = int.Parse(await result.Content.ReadAsStringAsync());
                }else
                {
                    var result = await _httpClient.PutAsJsonAsync("api/greenblend", gb);
                }
            }
            if (action.Roast.Id == 0)
            {
                var result = await _httpClient.PostAsJsonAsync("api/roast", action.Roast);
                if (!result.IsSuccessStatusCode)
                {
                    dispatcher.Dispatch(new RoastCreateFailureAction(result.ReasonPhrase));
                }else
                {
                    dispatcher.Dispatch(new RoastCreateSuccessAction());
                }
            }else
            {
                var result = await _httpClient.PutAsJsonAsync("api/roast", action.Roast);
                if (!result.IsSuccessStatusCode)
                {
                    dispatcher.Dispatch(new RoastUpdateFailureAction(result.ReasonPhrase));
                }
                else
                {
                    dispatcher.Dispatch(new RoastUpdateSuccessAction());
                }
            }
            dispatcher.Dispatch(new RoastsLoadAction());
        }

        [EffectMethod] 
        public async Task OnRoastDelete(RoastsRoastDeleteAction action, IDispatcher dispatcher)
        {
            var result = await _httpClient.DeleteAsync($"api/roast/{action.Roast.Id}");
            if (result.IsSuccessStatusCode)
            {
                dispatcher.Dispatch(new RoastDeleteSuccessAction());
            }else
            {
                dispatcher.Dispatch(new RoastDeleteFailureAction(result.ReasonPhrase));
            }
            dispatcher.Dispatch(new RoastsLoadAction());
        }
    }
}
