using Inseego.Models.Enumerators;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Inseego.Models.Request
{
    /// <summary>
    /// Request Model for service plan
    /// </summary>
    public class ServicePlanRequest
    {
        [JsonProperty(PropertyName = "id")]
        public string id { get; set; }
        [JsonProperty(PropertyName = "servicePlanName")]
        public string ServicePlanName { get; set; }
        [JsonProperty(PropertyName = "serviceTypeId")]
        public int ServiceTypeId { get; set; }
        [JsonProperty(PropertyName = "vehicleId")]
        public int VehicleId { get; set; }
        [JsonProperty(PropertyName = "workShopDetail")]
        public WorkShopDetail WorkShopDetail { get; set; }
        [JsonProperty(PropertyName = "serviceInterval")]
        public ServiceInterval ServiceInterval { get; set; }
        [JsonProperty(PropertyName = "scheduleService")]
        public ScheduleService ScheduleService { get; set; }
        [JsonProperty(PropertyName = "notify")]
        public Notify Notify { get; set; }
        [JsonProperty(PropertyName = "createdOn")]
        public DateTime CreatedOn { get; set; }
        [JsonProperty(PropertyName = "createdBy")]
        public string CreatedBy { get; set; }
        [JsonProperty(PropertyName = "modifiedOn")]
        public DateTime ModifiedOn { get; set; }
        [JsonProperty(PropertyName = "modifiedBy")]
        public string ModifiedBy { get; set; }
        [JsonProperty(PropertyName = "isDeleted")]
        public bool IsDeleted { get; set; }
        [JsonProperty(PropertyName = "isActive")]
        public bool IsActive { get; set; }
        [JsonProperty(PropertyName = "tenantId")]
        public string tenantId { get; set; }
        [JsonProperty(PropertyName = "servicePlanStatus")]
        public ServicePlanStatus ServicePlanStatus { get; set; }

    }

    public class WorkShopDetail
    {
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
    }
    public class ServiceInterval
    {
        public int ServiceIntervalTypeId { get; set; }
        public decimal Distance { get; set; }
        public bool IsServiceIntervalTimeLapse { get; set; }
        public int Days { get; set; }
        public int ReminderForDays { get; set; }
        public int ReminderForTimeElapse { get; set; }
        public DateTime LastServiceDate { get; set; }
        public decimal LastServiceOdometer { get; set; }

    }

    public class ScheduleService
    {
        public int NoOfDailyServiceSchedule { get; set; }
        public List<string> ServiceScheduleTime { get; set; }
    }

    public class Notify
    {
        public int NoOfAlerts { get; set; }
        public int GapBetweenAlerts { get; set; }
        public string NotifiedWay { get; set; }
        public string NotificationType { get; set; }
        public List<NotifyContacts> NotifyContacts { get; set; }
    }

    public class NotifyContacts
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string NotificationType { get; set; }
    }
    public class ServicePlanListRequest
    {
        public string ServicePlanId { get; set; }
        public string ServicePlanName { get; set; }
        public string VehicleId { get; set; }
        public string ServiceType { get; set; }
        public string Status { get; set; }
        public string LastServiceDate { get; set; }
        public string DistanceTravelled { get; set; }
        public string NextService { get; set; }
    }
}
