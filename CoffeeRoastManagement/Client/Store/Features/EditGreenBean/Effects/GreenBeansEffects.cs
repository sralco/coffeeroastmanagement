using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using Fluxor;
using CoffeeRoastManagement.Client.Store.Features.EditGreenBean.Actions;

namespace CoffeeRoastManagement.Client.Store.Features.EditGreenBean.Effects
{
    public class GreenBeansEffects
    {
        private readonly HttpClient _httpClient;

        public GreenBeansEffects(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [EffectMethod(typeof(GreenBeansLoadAction))]
        public async Task LoadGreenBeans(IDispatcher dispatcher)
        {
            var greenbeans = await _httpClient.GetFromJsonAsync<CoffeeRoastManagement.Shared.Entities.GreenBeanInfo[]>("api/greenbeaninfo");
            dispatcher.Dispatch(new GreenBeansSetAction(greenbeans));
        }

        [EffectMethod]
        public async Task DeleteGreenBean(GreenBeansDeleteAction action, IDispatcher dispatcher)
        {
            var result = await _httpClient.DeleteAsync($"api/greenbeaninfo/{action.GreenBeanInfo.Id}");
            if (result.IsSuccessStatusCode)
            {
                dispatcher.Dispatch(new GreenBeansDeleteSuccessAction());
            }else
            {
                dispatcher.Dispatch(new GreenBeansDeleteFailureAction(result.ReasonPhrase));
            }
            dispatcher.Dispatch(new GreenBeansLoadAction());
        }

        [EffectMethod]
        public async Task SaveGreenBean(GreenBeansSaveAction action, IDispatcher dispatcher)
        {
            if (action.GreenBeanInfo.Id == 0)
            {
                var result = await _httpClient.PostAsJsonAsync("api/greenbeaninfo", action.GreenBeanInfo);
                if (!result.IsSuccessStatusCode)
                {
                    dispatcher.Dispatch(new GreenBeanCreateFailureAction(result.ReasonPhrase));
                }else
                {
                    dispatcher.Dispatch(new GreenBeanCreateSuccessAction());
                }
            }
            else
            {
                var result = await _httpClient.PutAsJsonAsync("api/greenbeaninfo", action.GreenBeanInfo);
                if (!result.IsSuccessStatusCode)
                {
                    dispatcher.Dispatch(new GreenBeanUpdateFailureAction(result.ReasonPhrase));
                }
                else
                {
                    dispatcher.Dispatch(new GreenBeanUpdateSuccessAction());
                }
            }
            dispatcher.Dispatch(new GreenBeansLoadAction());
        }
    }
}
