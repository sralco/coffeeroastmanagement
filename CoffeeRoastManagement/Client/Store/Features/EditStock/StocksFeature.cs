using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fluxor;
using CoffeeRoastManagement.Client.Store.State;
using CoffeeRoastManagement.Shared.Entities;

namespace CoffeeRoastManagement.Client.Store.Features.EditStock
{
    public class RoastsFeature : Feature<StocksState>
    {
        public override string GetName()
        {
            return "Stocks";
        }

        protected override StocksState GetInitialState()
        {
            return new StocksState
            {
                Initialized = false,
                Loading = false,
                Submitting = false,
                Submitted = false,
                ShowInputDialog = false,
                ErrorMessage = String.Empty,
                StockButtonText = "Create",
                StockEditMode = false,
                CurrentStock = new Stock(),
                SelectedGreenBeanInfo = new GreenBeanInfo(),
                GreenBeans = Array.Empty<GreenBeanInfo>(),
                Stocks = Array.Empty<Stock>(),
                SelectedContact = new Contact(),
                Contacts = Array.Empty<Contact>()
            };
        }
    }
}
