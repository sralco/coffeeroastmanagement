using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using Fluxor;
using CoffeeRoastManagement.Client.Store.Features.EditStock.Actions;
using CoffeeRoastManagement.Client.Store.Features.EditGreenBean.Actions;
using CoffeeRoastManagement.Client.Store.State;
using System.Threading;

namespace CoffeeRoastManagement.Client.Store.Features.EditStock.Effects
{
    public class StocksEffects
    {
        private readonly HttpClient _httpClient;
        private readonly IState<GreenBeansState> _greenBeanState;

        public StocksEffects(HttpClient httpClient, IState<GreenBeansState> greenBeanState)
        {
            _httpClient = httpClient;
            _greenBeanState = greenBeanState;
        }

        [EffectMethod(typeof(StocksLoadAction))]
        public async Task LoadStocks(IDispatcher dispatcher)
        {
            var stocks = await _httpClient.GetFromJsonAsync<CoffeeRoastManagement.Shared.Entities.Stock[]>("api/stock");
            dispatcher.Dispatch(new StocksSetAction(stocks));
        }

        [EffectMethod]
        public async Task DeleteStock(StockDeleteAction action, IDispatcher dispatcher)
        {
            var result = await _httpClient.DeleteAsync($"api/stock/{action.Stock.Id}");
            if (result.IsSuccessStatusCode)
            {
                dispatcher.Dispatch(new StockDeleteSuccessAction());
            }
            else
            {
                dispatcher.Dispatch(new StockDeleteFailureAction(result.ReasonPhrase));
            }
            dispatcher.Dispatch(new StocksLoadAction());
        }

        // TODO: Look for a better solution
        [EffectMethod]
        public async Task SaveStock(StockSaveAction action, IDispatcher dispatcher)
        {
            var selectedGreenBean = action.GreenBean;
            if (action.GreenBean.Id == 0)
            {
                var result = await _httpClient.PostAsJsonAsync("api/greenbeaninfo", action.GreenBean);
                if (!result.IsSuccessStatusCode)
                {
                    dispatcher.Dispatch(new StockCreateFailureAction(result.ReasonPhrase));
                    return;
                }
                var greenbeans = await _httpClient.GetFromJsonAsync<CoffeeRoastManagement.Shared.Entities.GreenBeanInfo[]>("api/greenbeaninfo");
                selectedGreenBean = greenbeans.FirstOrDefault(x => x.Name == action.GreenBean.Name);
            }
            if (action.Stock.Id == 0)
            {
                action.Stock.SellerContact = action.Contact;
                action.Stock.GreenBeanInfo = selectedGreenBean;

                var result = await _httpClient.PostAsJsonAsync("api/stock", action.Stock);
                if (!result.IsSuccessStatusCode)
                {
                    dispatcher.Dispatch(new StockCreateFailureAction(result.ReasonPhrase));
                }
                else
                {
                    dispatcher.Dispatch(new StockCreateSuccessAction());
                }
            }
            else
            {
                action.Stock.SellerContact = action.Contact;
                action.Stock.GreenBeanInfo = action.GreenBean; 
                var result = await _httpClient.PutAsJsonAsync("api/stock", action.Stock);
                if (!result.IsSuccessStatusCode)
                {
                    dispatcher.Dispatch(new StockUpdateFailureAction(result.ReasonPhrase));
                }
                else
                {
                    dispatcher.Dispatch(new StockUpdateSuccessAction());
                }
            }
            dispatcher.Dispatch(new StocksLoadAction());
            dispatcher.Dispatch(new GreenBeansLoadAction());
        }
    }
}
