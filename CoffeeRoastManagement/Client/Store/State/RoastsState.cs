using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeRoastManagement.Shared.Entities;

namespace CoffeeRoastManagement.Client.Store.State
{
    public record RoastsState
    {
        public bool Initialized { get; init; }
        public bool Loading { get; init; }
        public bool Submitting { get; init; }
        public bool Submitted { get; init; }

        public string RoastButtonText { get; init; }
        public bool RoastEditMode { get; init; }
        public string ErrorMessage { get; init; }
        public bool ShowInputDialog { get; init; }

        public Roast CurrentRoast { get; init; }
        public string Photo { get; init; }
        public string RoastProfile { get; init; }
        public string Equipment { get; init; }

        public Roast[] Roasts { get; init; }
        public Stock[] Stocks { get; init; }
        public GreenBlend[] GreenBlends { get; init; }

        public string Name { get; init; }
        public string ShortInfo { get; init; }
        public string Note { get; init; }
        public DateTime? Date { get; init; }
        public TimeSpan? Time { get; init; }
    }
}
