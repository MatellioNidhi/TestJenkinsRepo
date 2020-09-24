using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inseego.Repositories.CosmosDB.Model
{
    //[Document(collection = "CTRIndexFinal")]
    public class ConsolidatedTripRecord //: AbstractRealmScopedResource<ConsolidatedTripRecord>
    {
        //[ProtoMember(2)]

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        public string VehicleId { get; set; }
        public string DriverId { get; set; }
        public string DriverTag { get; set; }
        public string TenantId { get; set; }
        public int? DriverScore { get; set; }
        public string CurrentBPFlag { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public long? TripStartTime { get; set; }
        public long? TripEndTime { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string StartPos { get; set; }
        public string EndPos { get; set; }
        public string TripStartLatitude { get; set; }
        public string TripStartLongitude { get; set; }
        public string TripEndLatitude { get; set; }
        public string TripEndLongitude { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public Address StartAddress { get; set; }
        public Address EndAddress { get; set; }
        public long? Duration { get; set; }
        public double? Distance { get; set; }
        public long? DrivingTime { get; set; }
        public long? StopTime { get; set; }
        public long? IdleTime { get; set; }
        public int? MaxSpeed { get; set; }
        public int? MaxRPM { get; set; }
        public int? ExcessIdleCount { get; set; }
        public int? OverRevCount { get; set; }
        public double? Mpg { get; set; }
        public int? StopsCount { get; set; }
        [JsonProperty("speedViolationCount")]
        public int speedViolationsCount { get; set; }
        [JsonProperty("harshBrakeCount")]
        public int harshBrakingViolationsCount { get; set; }
        [JsonProperty("harshAccelerationCount")]
        public int harshAccelarationsCount { get; set; }
        [JsonProperty("harshCornerCount")]
        public int harshCorneringCount { get; set; }
        [JsonProperty("severeGForceCount")]
        public int SevereGForceCount { get; set; }
        [JsonProperty("harshBumpCount")]
        public int HarshBumpCount { get; set; }
        [JsonProperty("highGForceCount")]
        public int HighGForceCount { get; set; }
        [JsonProperty("incidentCount")]
        public int IncidentCount { get; set; }
        public int tripStartFlags { get; set; }
        public int tripEndFlag { get; set; }

        public int? TripSource { get; set; }
        public string TripComplete { get; set; }
        public string EventSummaryPath { get; set; }
        [JsonIgnore()]
        List<Event> eventSummary { get; set; }
        [JsonIgnore()]
        public List<LocationSummary> LocationSummary { get; set; }
        public string LocationSummaryId { get; set; }
        public string LocationSummaryPath { get; set; }
        public string CurrentBPComment { get; set; }
        public List<BPComment> BPComments { get; set; }
        [JsonProperty("newStopLocation")]
        public Address NewStopLocation { get; set; }
        public long? NewStartTime { get; set; }
        public double? RunningDistance { get; set; }
        public long? RunningDuration { get; set; }

        //public String getStartDate()
        //{
        //    Date date = null{ get; set; }
        //    String dateStr = null{ get; set; }
        //    if ((startTime != null))
        //    {
        //        try
        //        {
        //            date = Constants.CTR_SIMPLEDATE_FORMATER.parse(startTime){ get; set; }
        //            dateStr = Constants.ONLY_DATE_FORMAT.format(date){ get; set; }
        //        }
        //        catch (Exception e)
        //        {
        //            LOG.error("Error while parsing the date from dateTime"){ get; set; }
        //        }

        //    }

        //    return dateStr{ get; set; }
        //}

        [JsonProperty("dbriefNotes")]
        public DBriefNotes dbriefNotes { get; set; }
    }

    public class DBriefNotes
    {
        [JsonProperty("comment")]
        String comment { get; set; }
    }
    public class Address
    {
        [JsonProperty("serialversionuid")]
        public   long serialversionuid = 1l;
        [JsonProperty("country")]
        public String Country;
        [JsonProperty("state")]
        public String State;
        [JsonProperty("county")]
        public String County;
        [JsonProperty("city")]
        public String City;
        //[JsonProperty("suburb")]
        //public String Suburb; // need to remove
        [JsonProperty("street")]
        public String Street;
        //[JsonProperty("zipCode")]
        //public String ZipCode; // need to remove
        [JsonProperty("housenumber")]
        public String Housenumber;
        [JsonProperty("postalcode")]
        public String Postalcode;
        [JsonProperty("district")]
        public String District;
        [JsonProperty("streetlimit")]
        public int? Streetlimit;

        //"functionalclass": "5",

    }
    public class BPComment
    {
        [JsonProperty("changeFrom")]
        public String ChangeFrom { get; set; }
        [JsonProperty("changeTo")]
        public String ChangeTo { get; set; }
        [JsonProperty("dateTime")]
        public long? DateTime { get; set; }
        [JsonProperty("validComments")]
        public String ValidComments { get; set; }
        [JsonProperty("commentBy")]
        public String CommentBy { get; set; }
        [JsonProperty("newStopLocation")]
        public Address NewStopLocation { get; set; }
        [JsonProperty("newStartTime")]
        public long? NewStartTime { get; set; }
    }
    public class Event
    {

    }
    public class LocationSummary
    {

    }
}


