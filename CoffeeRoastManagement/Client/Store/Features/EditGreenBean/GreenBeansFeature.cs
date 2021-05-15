using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fluxor;
using CoffeeRoastManagement.Client.Store.State;
using CoffeeRoastManagement.Shared.Entities;

namespace CoffeeRoastManagement.Client.Store.Features.EditGreenBean
{
    public class GreenBeansFeature : Feature<GreenBeansState>
    {
        public override string GetName()
        {
            return "GreenBeans";
        }

        protected override GreenBeansState GetInitialState()
        {
            return new GreenBeansState
            {
                Initialized = false,
                Loading = false,
                GreenBeanButtonText = "Create",
                GreenBeanEditMode = false,
                CurrentGreenBean = new GreenBeanInfo(),
                ShowInputDialog = false,
                GreenBeans = Array.Empty<GreenBeanInfo>()
            };
        }
    }
}
