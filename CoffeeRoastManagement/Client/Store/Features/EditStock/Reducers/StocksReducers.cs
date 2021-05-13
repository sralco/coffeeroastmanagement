using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fluxor;
using CoffeeRoastManagement.Client.Store.Features.EditStock.Actions;
using CoffeeRoastManagement.Client.Store.State;

namespace CoffeeRoastManagement.Client.Store.Features.EditStock.Reducers
{
    public static class StocksReducers
    {
        [ReducerMethod]
        public static StocksState OnContactsSet(StocksState state, StocksSetAction action)
        {
            return state with
            {
                Stocks = action.Stocks,
                Loading = false
            };
        }
        
        [ReducerMethod(typeof(StocksInitializedAction))]
        public static StocksState OnContactsInitialized(StocksState state)
        {
            return state with
            {
                Initialized = true
            };
        }

        [ReducerMethod(typeof(StocksLoadAction))]
        public static StocksState StocksLoad(StocksState state)
        {
            return state with
            {
                Loading = true
            };
        }

        [ReducerMethod]
        public static StocksState OnStockDelete(StocksState state, StockDeleteAction action)
        {
            if (state.CurrentStock.Id == action.Stock.Id)
            {
                return state with
                {
                    SelectedContact = new CoffeeRoastManagement.Shared.Entities.Contact(),
                    SelectedGreenBeanInfo = new CoffeeRoastManagement.Shared.Entities.GreenBeanInfo(),
                    CurrentStock = new CoffeeRoastManagement.Shared.Entities.Stock(),
                    StockButtonText = "Create"
                };
            }
            return state with
            {

            };
        }

        [ReducerMethod]
        public static StocksState StocksSaveGreenBean(StocksState state, StocksGreenBeanSaveAction action)
        {
            return state with
            {
                SelectedGreenBeanInfo = state.GreenBeans.FirstOrDefault(x => x.Name == action.GreenBean.Name)
            };
        }

        [ReducerMethod]
        public static StocksState OnEditContact(StocksState state, StockEditAction action)
        {
            return state with
            {
                Submitted = false,
                Submitting = false,
                ShowInputDialog = true,
                StockEditMode = true,
                CurrentStock = action.Stock,
                SelectedContact = action.Stock.SellerContact,
                SelectedGreenBeanInfo = action.Stock.GreenBeanInfo,
                StockButtonText = "Update"
            };
        }

        [ReducerMethod]
        public static StocksState OnSaveStock(StocksState state, StockSaveAction action)
        {
            return state with
            {
                Submitted = false,
                Submitting = true,
                StockButtonText = "Create",
                ShowInputDialog = false,
                StockEditMode = false
            };
        }

        [ReducerMethod]
        public static StocksState SelectedContactChanged(StocksState state, SetSelectedContactAction action)
        {
            return state with
            {
                SelectedContact = action.Contact
            };
        }

        [ReducerMethod]
        public static StocksState SelectedGreenBeanChanged(StocksState state, SelectedGreenBeanChangeAction action)
        {
            return state with
            {
                SelectedGreenBeanInfo = action.GreenBeanInfo
            };
        }
        [ReducerMethod]
        public static StocksState OnAddStock(StocksState state, StocksAddAction action)
        {
            // handle all cases, the last return statement handles the default case
            if (state.ShowInputDialog && state.StockEditMode)
            {
                // we reset everything
                return state with
                {
                    ShowInputDialog = true,
                    StockEditMode = false,
                    CurrentStock = new CoffeeRoastManagement.Shared.Entities.Stock(),
                    SelectedGreenBeanInfo = new CoffeeRoastManagement.Shared.Entities.GreenBeanInfo(),
                    SelectedContact = null,
                    StockButtonText = "Create"
                };
            }
            if (state.ShowInputDialog && !state.StockEditMode)
            {
                if (!AllFieldsEmpty(state)) // TODO: finish
                {
                    return state with
                    {
                        CurrentStock = new CoffeeRoastManagement.Shared.Entities.Stock(),
                        SelectedGreenBeanInfo = new CoffeeRoastManagement.Shared.Entities.GreenBeanInfo(),
                        SelectedContact = null,
                        StockButtonText = "Create",
                    };
                }
                else
                {
                    return state with
                    {
                        StockButtonText = "Create",
                        ShowInputDialog = false,
                    };
                }
            }
            return state with
            {
                ShowInputDialog = true,
            };
        }
        
        private static bool AllStockFieldsEmpty(StocksState state)
        {
            return state.CurrentStock.Amount == 0 && string.IsNullOrEmpty(state.CurrentStock.Note) && (state.SelectedContact == null || state.SelectedContact.Id == 0) && state.CurrentStock.GoodsReceived == DateTime.MinValue;
        }

        private static bool AllBeanFieldsEmpty(StocksState state)
        {
            return state.SelectedGreenBeanInfo.Id == 0 && (string.IsNullOrEmpty(state.SelectedGreenBeanInfo.Farmer) && string.IsNullOrEmpty(state.SelectedGreenBeanInfo.Name)
                && string.IsNullOrEmpty(state.SelectedGreenBeanInfo.Note) && string.IsNullOrEmpty(state.SelectedGreenBeanInfo.Processing) && string.IsNullOrEmpty(state.SelectedGreenBeanInfo.Region)
                && string.IsNullOrEmpty(state.SelectedGreenBeanInfo.Variety) && string.IsNullOrEmpty(state.SelectedGreenBeanInfo.Region) && state.SelectedGreenBeanInfo.OverallCuppingScore == 0.0
                && state.SelectedGreenBeanInfo.Crop == 0 && string.IsNullOrEmpty(state.SelectedGreenBeanInfo.Url) && string.IsNullOrEmpty(state.SelectedGreenBeanInfo.Country));
        }
        private static bool AllFieldsEmpty(StocksState state)
        {
            return AllStockFieldsEmpty(state) && AllBeanFieldsEmpty(state);
        }
    }
}
