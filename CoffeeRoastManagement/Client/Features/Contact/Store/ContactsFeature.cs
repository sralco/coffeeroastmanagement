using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fluxor;

namespace CoffeeRoastManagement.Client.Features.Contact.Store
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
                Contacts = Array.Empty<CoffeeRoastManagement.Shared.Entities.Contact>()
            };
        }
    }
}
