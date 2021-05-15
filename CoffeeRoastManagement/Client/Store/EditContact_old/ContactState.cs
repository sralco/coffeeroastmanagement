using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeRoastManagement.Client.Store.EditContact
{
    public record ContactState
    {
        public bool Submitting { get; init; }
        public bool Submitted { get; init; }
        public string ErrorMessage { get; init; }
        public CoffeeRoastManagement.Shared.Entities.Contact Contact { get; init; }
    }
}
