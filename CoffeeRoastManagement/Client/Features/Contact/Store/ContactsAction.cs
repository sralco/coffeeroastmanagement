using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeRoastManagement.Client.Features.Contact.Store
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

    public class ContactsSaveAction
    {
        public CoffeeRoastManagement.Shared.Entities.Contact Contact { get; }

        public ContactsSaveAction(CoffeeRoastManagement.Shared.Entities.Contact contact)
        {
            Contact = contact;
        }
    }
}
