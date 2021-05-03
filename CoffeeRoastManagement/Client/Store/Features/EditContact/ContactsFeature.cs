using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fluxor;
using CoffeeRoastManagement.Client.Store.State;
using CoffeeRoastManagement.Shared.Entities;

namespace CoffeeRoastManagement.Client.Store.Features.EditContact
{
    public class ContactsFeature : Feature<ContactsState>
    {
        public override string GetName()
        {
            return "Contacts";
        }

        protected override ContactsState GetInitialState()
        {
            return new ContactsState
            {
                Initialized = false,
                Loading = false,
                ContactButtonText = "Create",
                ContactEditMode = false,
                CurrentContact = new Contact(),
                ShowInputDialog = false,
                Contacts = Array.Empty<Contact>()
            };
        }
    }
}
