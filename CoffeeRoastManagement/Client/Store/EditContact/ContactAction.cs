using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeRoastManagement.Client.Store.EditContact
{
    public class ContactSubmitSuccessAction { }
    
    public class ContactSubmitFailureAction
    {
        public string ErrorMessage { get; }
        public ContactSubmitFailureAction(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }

    public class ContactSubmitAction
    {
        public CoffeeRoastManagement.Shared.Entities.Contact Contact { get; }
        public ContactSubmitAction(CoffeeRoastManagement.Shared.Entities.Contact contact)
        {
            Contact = contact;
        }
    }

    public class ContactEditAction
    {
        public CoffeeRoastManagement.Shared.Entities.Contact Contact { get; }

        public ContactEditAction(CoffeeRoastManagement.Shared.Entities.Contact contact)
        {
            Contact = contact;
        }
    }
}
