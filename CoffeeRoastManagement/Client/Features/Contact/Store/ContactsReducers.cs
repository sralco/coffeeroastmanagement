using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fluxor;

namespace CoffeeRoastManagement.Client.Features.Contact.Store
{
    public static class ContactsReducers
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
            return state with
            {
                Contacts = state.Contacts.Where(x => x.Id != action.Contact.Id).ToArray()
            };
        }
    }
}
