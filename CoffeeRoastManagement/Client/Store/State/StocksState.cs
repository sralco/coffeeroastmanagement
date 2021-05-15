using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeRoastManagement.Shared.Entities;

namespace CoffeeRoastManagement.Client.Store.State
{
    public record StocksState
    {
        public bool Initialized { get; init; }
        public bool Loading { get; init; }
        public bool Submitting { get; init; }
        public bool Submitted { get; init; }

        public string StockButtonText { get; init; }
        public bool StockEditMode { get; init; }
        public string ErrorMessage { get; init; }
        public bool ShowInputDialog { get; init; }

        public GreenBeanInfo SelectedGreenBeanInfo { get; init; }
        public GreenBeanInfo[] GreenBeans { get; init; }
        public Contact[] Contacts { get; init; }
        public Contact SelectedContact { get; init; }
        public Stock CurrentStock { get; init; }
        public Stock[] Stocks { get; init; }
    }
}
