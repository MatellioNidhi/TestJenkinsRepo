using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inseego.Repositories.CosmosDB.Model
{
    //[Document(collection = "DriverBehaviour")]
    public class DriverBehaviourRecord //: AbstractRealmScopedResource<ConsolidatedTripRecord>
    {

        public DriverBehaviourRecord() { }
        public string Name { get; set; }
        public string ToolTip { get; set; }
        public string Icon { get; set; }
        public string Polarities { get; set; }
        public HWData HWData { get; set; }
    }

    public class HWData
    {
        public HWData() { }
        public string Unit { get; set; }
        public string Data { get; set; }
    }
}

