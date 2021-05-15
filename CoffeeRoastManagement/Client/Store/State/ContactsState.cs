using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeRoastManagement.Shared.Entities;

namespace CoffeeRoastManagement.Client.Store.State
{
    public record ContactsState
    {
        public bool Initialized { get; init; }
        public bool Loading { get; init; }
        public bool Submitting { get; init; }
        public bool Submitted { get; init; }
        public string ContactButtonText { get; init; }
        public bool ContactEditMode { get; init; }
        public string ErrorMessage { get; init; }
        public bool ShowInputDialog { get; init; }
        public Contact[] Contacts { get; init; }
        public Contact CurrentContact { get; init; }
    }
}
