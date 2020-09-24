using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inseego.Repositories.CosmosDB.Model
{
    //[Document(collection = "CTRIndexFinal")]
    public class Users //: AbstractRealmScopedResource<ConsolidatedTripRecord>
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        public string Name { get; set; }

    }
}


