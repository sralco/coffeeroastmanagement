using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fluxor;

namespace CoffeeRoastManagement.Client.Store.EditContact
{
    public static class ContactReducers
    {

        [ReducerMethod(typeof(ContactSubmitAction))]
        public static ContactState OnSubmit(ContactState state)
        {
            return state with
            {
                Submitting = true
            };
        }

        [ReducerMethod(typeof(ContactSubmitSuccessAction))]
        public static ContactState OnSubmitSuccess(ContactState state)
        {
            return state with
            {
                Submitting = false,
                Submitted = true
            };
        }

        [ReducerMethod]
        public static ContactState OnSubmitFailure(ContactState state, ContactSubmitFailureAction action)
        {
            return state with
            {
                Submitting = false,
                ErrorMessage = action.ErrorMessage
            };
        }
    }
}
