using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fluxor;
using CoffeeRoastManagement.Client.Store.State;
using CoffeeRoastManagement.Shared.Entities;

namespace CoffeeRoastManagement.Client.Store.Features.EditRoast
{
    public class RoastsFeature : Feature<RoastsState>
    {
        public override string GetName()
        {
            return "Roasts";
        }

        protected override RoastsState GetInitialState()
        {
            return new RoastsState
            {
                Initialized = false,
                Loading = false,
                Submitting = false,
                Submitted = false,
                ShowInputDialog = false,
                ErrorMessage = String.Empty,
                RoastButtonText = "Create",
                RoastEditMode = false,
                CurrentRoast = new Roast(),
                Photo = String.Empty,
                RoastProfile = String.Empty,
                Roasts = Array.Empty<Roast>(),
                GreenBlends = Array.Empty<GreenBlend>(),
                Equipment = String.Empty,
                Name = String.Empty,
                ShortInfo = String.Empty,
                Note = String.Empty,
                Date = null,
                Time = null,
                Stocks = Array.Empty<Stock>()
            };
        }
    }
}
