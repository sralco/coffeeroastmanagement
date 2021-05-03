using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeRoastManagement.Client.Store.Features.EditContact.Actions
{
    public class ContactsInitializedAction { }
    public class ContactsLoadAction { }

    public class ContactsSetAction
    {
        public CoffeeRoastManagement.Shared.Entities.Contact[] Contacts { get; }

        public ContactsSetAction(CoffeeRoastManagement.Shared.Entities.Contact[] contacts)
        {
            Contacts = contacts;
        }
    }

    public class ContactsDeleteAction
    {
        public CoffeeRoastManagement.Shared.Entities.Contact Contact { get; }

        public ContactsDeleteAction(CoffeeRoastManagement.Shared.Entities.Contact contact)
        {
            Contact = contact;
        }
    }

    public class ContactDeleteSuccessAction { }
    public class ContactDeleteFailureAction
    {
        public string ErrorMessage { get; }
        public ContactDeleteFailureAction(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
    
    public class ContactsSaveAction
    {
        public CoffeeRoastManagement.Shared.Entities.Contact Contact { get; }

        public ContactsSaveAction(CoffeeRoastManagement.Shared.Entities.Contact contact)
        {
            Contact = contact;
        }
    }

    public class ContactCreateSuccessAction { }

    public class ContactCreateFailureAction
    {
        public string ErrorMessage { get; }
        public ContactCreateFailureAction(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }

    public class ContactUpdateSuccessAction { }
    public class ContactUpdateFailureAction
    {
        public string ErrorMessage { get; }
        public ContactUpdateFailureAction(string errorMessage)
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

    public class ContactStopEditAction
    {
        public CoffeeRoastManagement.Shared.Entities.Contact Contact { get; }

        public ContactStopEditAction()
        {
            Contact = new CoffeeRoastManagement.Shared.Entities.Contact();
        }
    }

    public class ContactAddAction { }
}
