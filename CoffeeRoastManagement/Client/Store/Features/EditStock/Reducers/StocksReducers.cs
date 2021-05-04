using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fluxor;
using CoffeeRoastManagement.Client.Store.Features.EditContact.Actions;
using CoffeeRoastManagement.Client.Store.State;

namespace CoffeeRoastManagement.Client.Store.Features.EditContact.Reducers
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

        //    [ReducerMethod]
        //    public static ContactsState OnContactsDelete(ContactsState state, ContactsDeleteAction action)
        //    {
        //        if (state.CurrentContact.Id == action.Contact.Id)
        //        {
        //            return state with
        //            {
        //                CurrentContact = new CoffeeRoastManagement.Shared.Entities.Contact(),
        //                ContactButtonText = "Create"
        //            };
        //        }
        //        return state with
        //        {

        //        };
        //    }

        //    [ReducerMethod(typeof(ContactSubmitAction))]

        //    public static ContactsState OnSubmit(ContactsState state)
        //    {
        //        return state with
        //        {
        //            Submitting = true
        //        };
        //    }

        //    [ReducerMethod(typeof(ContactCreateSuccessAction))]
        //    public static ContactsState OnCreateSuccess(ContactsState state)
        //    {
        //        return state with
        //        {
        //            Submitting = false,
        //            Submitted = true
        //        };
        //    }

        //    [ReducerMethod]
        //    public static ContactsState OnCreateFailure(ContactsState state, ContactCreateFailureAction action)
        //    {
        //        return state with
        //        {
        //            Submitting = false,
        //            ErrorMessage = action.ErrorMessage
        //        };
        //    }

        //    [ReducerMethod(typeof(ContactUpdateSuccessAction))]
        //    public static ContactsState OnUpdateSuccess(ContactsState state)
        //    {
        //        return state with
        //        {
        //            Submitting = false,
        //            Submitted = true
        //        };
        //    }

        //    [ReducerMethod]
        //    public static ContactsState OnUpdateFailure(ContactsState state, ContactUpdateFailureAction action)
        //    {
        //        return state with
        //        {
        //            Submitting = false,
        //            ErrorMessage = action.ErrorMessage
        //        };
        //    }



        //    [ReducerMethod]
        //    public static ContactsState OnEditContact(ContactsState state, ContactEditAction action)
        //    {
        //        return state with
        //        {
        //            Submitted = false,
        //            Submitting = false,
        //            ShowInputDialog = true,
        //            CurrentContact = action.Contact,
        //            ContactButtonText = "Update"
        //        };
        //    }

        //    [ReducerMethod]
        //    public static ContactsState OnSaveContact(ContactsState state, ContactsSaveAction action)
        //    {
        //        return state with
        //        {
        //            Submitted = false,
        //            Submitting = true,
        //            CurrentContact = new CoffeeRoastManagement.Shared.Entities.Contact(),
        //            ContactButtonText = "Create",
        //            ShowInputDialog = false,
        //            ContactEditMode = false
        //        };
        //    }

        //    [ReducerMethod]
        //    public static ContactsState OnStopEditContact(ContactsState state, ContactStopEditAction action)
        //    {
        //        return state with
        //        {
        //            CurrentContact = action.Contact,
        //            ContactButtonText = "Create",
        //        };
        //    }

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
                    StockButtonText = "Create"
                };
            }
            if (state.ShowInputDialog && !state.StockEditMode)
            {
                if (!string.IsNullOrEmpty(state.CurrentStock.Note)) // TODO: finish
                {
                    return state with
                    {
                        CurrentStock = new CoffeeRoastManagement.Shared.Entities.Stock(),
                        StockButtonText = "Create",
                    };
                }
                else
                {
                    return state with
                    {
                        CurrentStock = new CoffeeRoastManagement.Shared.Entities.Stock(),
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
    }
}
