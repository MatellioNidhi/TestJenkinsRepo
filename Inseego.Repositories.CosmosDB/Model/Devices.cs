using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inseego.Repositories.CosmosDB.Model
{
    //[Document(collection = "CTRIndexFinal")]
    public class Devices //: AbstractRealmScopedResource<ConsolidatedTripRecord>
    {
        public Metadata metadata { get; set; }
        public string type { get; set; }
        public string id { get; set; }
        public string name { get; set; }
    }
    public class Metadata
    {
        public string odometer { get; set; }
        public string color { get; set; }
        public string vehicleImage { get; set; }
        public string year { get; set; }
        public string displayName { get; set; }
        public string vehicleSkillSet { get; set; }
        public string profileImage { get; set; }
        public string type { get; set; }
        public string avgFuelConsumption { get; set; }
        public string fleetNumber { get; set; }
        public string registrationNumber { get; set; }
        public string vehicleIcon { get; set; }
        public string model { get; set; }
        public string VIN { get; set; }
        public string currentDriver { get; set; }
        public string make { get; set; }
        public string runningHours { get; set; }
        public string vehicleType { get; set; }
        public string defaultImage { get; set; }
    }
}


