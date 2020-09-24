using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Inseego.Repositories.CosmosDB.Model
{
    /// <summary>
    /// Request Model for service plan
    /// </summary>
    public class ServicePlanModel
    {
        public string Id { get; set; }
        public string ServicePlanName { get; set; }
        public int ServiceTypeId { get; set; }
        public int VehicleId { get; set; }
        public WorkShopDetail WorkShopDetail { get; set; }
        public ServiceInterval ServiceInterval { get; set; }
        public ScheduleService ScheduleService { get; set; }
        public Notify Notify { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsACtive { get; set; }
        public string TenantId { get; set; }

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
        public bool IsServiceIntervalTimeELapse { get; set; }
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
}
