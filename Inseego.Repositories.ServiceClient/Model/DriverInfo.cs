using System;
using System.Collections.Generic;
using System.Text;

namespace Inseego.Repositories.ServiceClient.Model
{
    public class ContactInfo
    {
        public string state { get; set; }
        public string city { get; set; }
        public string postalCode { get; set; }
        public string country { get; set; }
        public string mobile { get; set; }
    }

    public class EmergencyContactInfo
    {
        public string email { get; set; }
        public string mobile { get; set; }
        public string relationship { get; set; }
        public string name { get; set; }
    }

    public class Datum
    {
        public string id { get; set; }
        public string createdBy { get; set; }
        public object creation { get; set; }
        public string tenantId { get; set; }
        public bool accountEnabled { get; set; }
        public bool accountLocked { get; set; }
        public bool userPrivacy { get; set; }
        public string driverId { get; set; }
        public string description { get; set; }
        public int invalidPasswordCount { get; set; }
        public string displayName { get; set; }
        public string emailId { get; set; }
        public string givenName { get; set; }
        public string mailNickname { get; set; }
        public string lastInvalidPasswordEntryTime { get; set; }
        public string surname { get; set; }
        public string userName { get; set; }
        public string passwordExpiry { get; set; }
        public string rfid { get; set; }
        public bool isDriver { get; set; }
        public List<object> skillsSet { get; set; }
        public string homeLocation { get; set; }
        public string workLocation { get; set; }
        public string officeLocation { get; set; }
        public string identificationNumber { get; set; }
        public ContactInfo contactInfo { get; set; }
        public EmergencyContactInfo emergencyContactInfo { get; set; }
        public bool taggedOnly { get; set; }
        public string driverTagExpiry { get; set; }
        public string driverTagExpirySchedulerPolicyId { get; set; }
        public string lastUpdatedBy { get; set; }
        public long? lastUpdatedTime { get; set; }
        public string jobTitle { get; set; }
        public string profileImage { get; set; }
    }

    public class DriverInfo
    {
        public int count { get; set; }
        public List<Datum> data { get; set; }
    }
}
