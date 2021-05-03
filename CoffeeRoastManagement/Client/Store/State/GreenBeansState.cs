using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeRoastManagement.Shared.Entities;

namespace CoffeeRoastManagement.Client.Store.State
{
    public record GreenBeansState
    {
        public bool Initialized { get; init; }
        public bool Loading { get; init; }
        public bool Submitting { get; init; }
        public bool Submitted { get; init; }
        public string GreenBeanButtonText { get; init; }
        public bool GreenBeanEditMode { get; init; }
        public string ErrorMessage { get; init; }
        public bool ShowInputDialog { get; init; }
        public GreenBeanInfo[] GreenBeans { get; init; }
        public GreenBeanInfo CurrentGreenBean { get; init; }
    }
}
