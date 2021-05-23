using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CoffeeRoastManagement.Shared.DataModel
{
    public class ArtisanFile
    {
        public string Title { get; set; }
        public string Version { get; set; }
        public string Revision { get; set; }
        [JsonProperty("artisan_os")]
        public string ArtisanOS { get; set; }
        [JsonProperty("artisan_os_version")]
        public string ArtisanOSVersion { get; set; }
        public string RoasterType { get; set; }
        public string MachineSetup { get; set; }
        public int RoastEpoch { get; set; }
        public int RoastTZOffset { get; set; }
        public string Beans { get; set; }
        //public int Weight { get; set; }
        //public int Density { get; set; }
        //public int DensityRoasted { get; set; }
        public List<string> FlavorLabels { get; set; }
        public List<double> Flavors { get; set; }

        public List<double> TimeX { get; set; }
        public List<List<double>> ExtraTimeX { get; set; }
        public List<double> Temp1 { get; set; }
        public List<double> Temp2 { get; set; }
        public List<List<double>> ExtraTemp1 { get; set; }
        public List<List<double>> ExtraTemp2 { get; set; }
        [JsonProperty("computed")]
        public Computed ComputedValues { get; set; }
        public List<double> TimeIndex { get; set; }
        public List<double> SpecialEvents { get; set; }
        public List<int> SpecialEventsType { get; set; }
        public List<int> SpecialEventsValue { get; set; }
        public List<string> SpecialEventsStrings { get; set; }
        public string RoastUuid { get; set; }
        public string RoastingNotes { get; set; }
        public string CuppingNotes { get; set; }
    }

    public class Computed
    {
        [JsonProperty("CHARGE_ET")]
        public double ChargeET { get; set; }
        [JsonProperty("CHARGE_BT")]
        public double ChargeBT { get; set; }
        [JsonProperty("TP_idx")]
        public double TurningPointIndex { get; set; }
        [JsonProperty("TP_time")]
        public double TurningPointTime { get; set; }
        [JsonProperty("TP_ET")]
        public double TurningPointEnvTemp { get; set; }
        [JsonProperty("TP_BT")]
        public double TurningPointBeanTemp { get; set; }
        [JsonProperty("MET")]
        public double MET { get; set; }
        [JsonProperty("DRY_time")]
        public double DryTime { get; set; }
        [JsonProperty("DRY_ET")]
        public double DryEnvTemp { get; set; }
        [JsonProperty("DRY_BT")]
        public double DryBeanTemp { get; set; }
        [JsonProperty("FCs_time")]
        public double FirstCrackStartTime { get; set; }
        [JsonProperty("FCs_ET")]
        public double FirstCrackStartEnvTemp { get; set; }
        [JsonProperty("FCs_BT")]
        public double FirstCrackStartBeanTemp { get; set; }
        [JsonProperty("FCe_time")]
        public double FirstCrackEndTime { get; set; }
        [JsonProperty("FCe_ET")]
        public double FirstCrackEndEnvTemp { get; set; }
        [JsonProperty("FCe_BT")]
        public double FirstCrackEndBeanTemp { get; set; }

        [JsonProperty("SCs_time")]
        public double SecondCrackStartTime { get; set; }
        [JsonProperty("SCs_ET")]
        public double SecondCrackStartEnvTemp { get; set; }
        [JsonProperty("SCs_BT")]
        public double SecondCrackStartBeanTemp { get; set; }
        [JsonProperty("SCe_time")]
        public double SecondCrackEndTime { get; set; }
        [JsonProperty("SCe_ET")]
        public double SecondCrackEndEnvTemp { get; set; }
        [JsonProperty("SCe_BT")]
        public double SecondCrackEndBeanTemp { get; set; }

        [JsonProperty("DROP_time")]
        public double DropTime { get; set; }
        [JsonProperty("DROP_ET")]
        public double DropEnvTemp { get; set; }
        [JsonProperty("DROP_BT")]
        public double DropBeanTemp { get; set; }

        public double TotalTime { get; set; }
        public double DryPhaseTime { get; set; }
        public double MidPhaseTime { get; set; }
        public double FinishPhaseTime { get; set; }
        
        [JsonProperty("dry_phase_ror")]
        public double DryPhaseROR { get; set; }
        [JsonProperty("mid_phase_ror")]
        public double MidPhaseROR { get; set; }
        [JsonProperty("finish_phase_ror")]
        public double FinishPhaseROR { get; set; }

        [JsonProperty("total_ror")]
        public double TotalROR { get; set; }
    }
}
