using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inseego.Repositories.ServiceClient.Model
{
        public class TenantVehicleInfo
        {
            public string nextLink { get; set; }
            public int count { get; set; }
            public IList<TenantVehicleInfoDatum> data { get; set; }
        }
        public class TenantVehicleInfoDatum
        {
            public string id { get; set; }
            public string createdBy { get; set; }
            public object creation { get; set; }
            public string lastUpdatedBy { get; set; }
            public object lastUpdatedTime { get; set; }
            public string tenantId { get; set; }
            public string name { get; set; }
            public IList<TenantVehicleInfoDescription> description { get; set; }
            public string deviceTemplateId { get; set; }
            public TenantVehicleInfoState state { get; set; }
            public TenantVehicleInfoAttributes attributes { get; set; }
            public IList<TenantVehicleInfoSubDevice> subDevices { get; set; }
            public TenantVehicleInfoMetadata metadata { get; set; }
            public string unitType { get; set; }
            public string hardwareType { get; set; }
            public string productType { get; set; }
            public string protocol { get; set; }
            public string templateType { get; set; }
        }
        public class TenantVehicleInfoDescription
        {
            public string lang { get; set; }
            public string text { get; set; }
        }
        public class TenantVehicleInfoMetadata
        {
            public string odometer { get; set; }
            public string iconImage { get; set; }
            public string vehicleImage { get; set; }
            public string displayName { get; set; }
            public string icon { get; set; }
            public string profileImage { get; set; }
            public string type { get; set; }
            public string ImageSelection { get; set; }
            public string fleetNumber { get; set; }
            public string registrationNumber { get; set; }
            public string vehicleIcon { get; set; }
            public string VIN { get; set; }
            public string currentDriver { get; set; }
            public string vehicleType { get; set; }
            public string runningHours { get; set; }
            public string color { get; set; }
            public string year { get; set; }
            public string SerialNumber { get; set; }
            public string model { get; set; }
            public string make { get; set; }
            public string defaultImage { get; set; }
            public string TestKEy { get; set; }
            public string vehicleSkillSet { get; set; }
            public string TestKEyY { get; set; }
            public string serialNumber { get; set; }
            public string operationalStatus { get; set; }

            [JsonProperty("DeviceMetadata.FirmwareVersion")]
            public string FirmwareVersion { get; set; }

            [JsonProperty("DeviceMetadata.Cellnumber")]
            public string Cellnumber { get; set; }
            public string MIT { get; set; }
        }
        public class TenantVehicleInfoSubDevice
        {
            public string deviceId { get; set; }
            public string description { get; set; }
        }
        public class TenantVehicleInfoAttributes
        {
            public IList<TenantVehicleInfoStandard> standard { get; set; }
            public IList<object> custom { get; set; }
        }
        public class TenantVehicleInfoStandard
        {
            public string attributeTypeId { get; set; }
            public string name { get; set; }
            public string type { get; set; }
        }
        public class TenantVehicleInfoState
        {
            public string lifecycleState { get; set; }
            public string operationalState { get; set; }
        }
    }
