using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeRoastManagement.Shared.Entities;

namespace CoffeeRoastManagement.Client.Features.Contact.Store
{
    public record ContactsState
    {
        public bool Initialized { get; init; }
        public bool Loading { get; init; }
        public CoffeeRoastManagement.Shared.Entities.Contact[] Contacts { get; init; }
    }
}
