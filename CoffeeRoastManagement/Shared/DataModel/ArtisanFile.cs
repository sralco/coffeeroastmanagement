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
        public string Title { get; set; }
        public List<double> TimeX { get; set; }
        public List<double> Temp1 { get; set; }
        public List<double> Temp2 { get; set; }
        public List<double> TimeIndex { get; set; }
        public List<double> SpecialEvents { get; set; }
        public string RoastUuid { get; set; }
        public string RoastingNotes { get; set; }
        public string CuppingNotes { get; set; }
    }
}
