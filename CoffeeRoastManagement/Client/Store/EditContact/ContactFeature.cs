using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fluxor;

namespace CoffeeRoastManagement.Client.Store.EditContact
{
    public class ContactFeature : Feature<ContactState>
    {
        public override string GetName() => "Contact";

        protected override ContactState GetInitialState()
        {
            return new ContactState
            {
                Submitting = false,
                Submitted = false,
                ErrorMessage = String.Empty,
                Contact = new CoffeeRoastManagement.Shared.Entities.Contact()
            };
        }
    }
}
