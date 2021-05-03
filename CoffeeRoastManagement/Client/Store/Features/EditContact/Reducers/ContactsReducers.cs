using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fluxor;
using CoffeeRoastManagement.Client.Store.Features.EditContact.Actions;
using CoffeeRoastManagement.Client.Store.State;

namespace CoffeeRoastManagement.Client.Store.Features.EditContact.Reducers
{
    public static class GreenBeansReducers
    {
        [ReducerMethod]
        public static ContactsState OnContactsSet(ContactsState state, ContactsSetAction action)
        {
            return state with
            {
                Contacts = action.Contacts,
                Loading = false
            };
        }
        
        [ReducerMethod(typeof(ContactsInitializedAction))]
        public static ContactsState OnContactsInitialized(ContactsState state)
        {
            return state with
            {
                Initialized = true
            };
        }

        [ReducerMethod(typeof(ContactsLoadAction))]
        public static ContactsState OnContactsLoad(ContactsState state)
        {
            return state with
            {
                Loading = true
            };
        }

        [ReducerMethod]
        public static ContactsState OnContactsDelete(ContactsState state, ContactsDeleteAction action)
        {
            if (state.CurrentContact.Id == action.Contact.Id)
            {
                return state with
                {
                    CurrentContact = new CoffeeRoastManagement.Shared.Entities.Contact(),
                    ContactButtonText = "Create"
                };
            }
            return state with
            {
                
            };
        }

        [ReducerMethod(typeof(ContactSubmitAction))]
        
        public static ContactsState OnSubmit(ContactsState state)
        {
            return state with
            {
                Submitting = true
            };
        }

        [ReducerMethod(typeof(ContactCreateSuccessAction))]
        public static ContactsState OnCreateSuccess(ContactsState state)
        {
            return state with
            {
                Submitting = false,
                Submitted = true
            };
        }

        [ReducerMethod]
        public static ContactsState OnCreateFailure(ContactsState state, ContactCreateFailureAction action)
        {
            return state with
            {
                Submitting = false,
                ErrorMessage = action.ErrorMessage
            };
        }

        [ReducerMethod(typeof(ContactUpdateSuccessAction))]
        public static ContactsState OnUpdateSuccess(ContactsState state)
        {
            return state with
            {
                Submitting = false,
                Submitted = true
            };
        }

        [ReducerMethod]
        public static ContactsState OnUpdateFailure(ContactsState state, ContactUpdateFailureAction action)
        {
            return state with
            {
                Submitting = false,
                ErrorMessage = action.ErrorMessage
            };
        }



        [ReducerMethod]
        public static ContactsState OnEditContact(ContactsState state, ContactEditAction action)
        {
            return state with
            {
                Submitted = false,
                Submitting = false,
                ShowInputDialog = true,
                CurrentContact = action.Contact,
                ContactButtonText = "Update"
            };
        }

        [ReducerMethod]
        public static ContactsState OnSaveContact(ContactsState state, ContactsSaveAction action)
        {
            return state with
            {
                Submitted = false,
                Submitting = true,
                CurrentContact = new CoffeeRoastManagement.Shared.Entities.Contact(),
                ContactButtonText = "Create",
                ShowInputDialog = false,
                ContactEditMode = false
            };
        }

        [ReducerMethod]
        public static ContactsState OnStopEditContact(ContactsState state, ContactStopEditAction action)
        {
            return state with
            {
                CurrentContact = action.Contact,
                ContactButtonText = "Create",
            };
        }

        [ReducerMethod]
        public static ContactsState OnAddContact(ContactsState state, ContactAddAction action)
        {
            // handle all cases, the last return statement handles the default case
            if (state.ShowInputDialog && state.ContactEditMode)
            {
                // we reset everything
                return state with
                {
                    ShowInputDialog = true,
                    ContactEditMode = false,
                    CurrentContact = new CoffeeRoastManagement.Shared.Entities.Contact(),
                    ContactButtonText = "Create"
                };
            }
            if (state.ShowInputDialog && !state.ContactEditMode)
            {
                if (!string.IsNullOrEmpty(state.CurrentContact.Name) || !string.IsNullOrEmpty(state.CurrentContact.Note) || !string.IsNullOrEmpty(state.CurrentContact.Url))
                {
                    return state with
                    {
                        CurrentContact = new CoffeeRoastManagement.Shared.Entities.Contact(),
                        ContactButtonText = "Create",
                    };
                }else
                {
                    return state with
                    {
                        CurrentContact = new CoffeeRoastManagement.Shared.Entities.Contact(),
                        ContactButtonText = "Create",
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
