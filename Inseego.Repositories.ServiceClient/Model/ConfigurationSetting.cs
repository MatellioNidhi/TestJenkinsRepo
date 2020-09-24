using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inseego.Repositories.ServiceClient.Model
{
    public class ConfigurationSetting
    {
        public string id { get; set; }
        public ConfigSetting configProperties { get; set; }
        public string name { get; set; }
    }

    public class ConfigSetting
    {
        public int zoomLevel { get; set; }
        public string country { get; set; }
        public string distanceUnit { get; set; }
        public string dateFormat { get; set; }
        public double speedUnit1 { get; set; }
        public string distanceMesurementUnit { get; set; }
        //public int Green band driving { get; set; }
        public IList<SpeedViolationCategoryList> speedViolationCategoryList { get; set; }
        public string unKnownSwitch { get; set; }
        public int bpEditMaxDays { get; set; }
        public string fromSundayLunchHour { get; set; }
        public string officeLocation { get; set; }
        public string fromLunchHour { get; set; }
        public string defaultVehicleId { get; set; }
        public string fromWorkingHour { get; set; }
        public string fuelMileageUnit { get; set; }
        public string toSaturdayLunchHour { get; set; }
        public string defaultVehicleSkillSetList { get; set; }
        public string bpPrecedence { get; set; }
        public IList<VehicleCheckList> vehicleCheckLists { get; set; }
        public string toLunchHour { get; set; }
        public double longitude { get; set; }
        //public int Over Revving { get; set; }
        public string defaultVehicleChecklist { get; set; }
        public IList<PasswordPolicy> passwordPolicy { get; set; }
        public IList<AllowedNotificationList> allowedNotificationList { get; set; }
        //public int Over Speeding { get; set; }
        public IList<ColumnConfig> columnConfig { get; set; }
        //public int Harsh Braking { get; set; }
        public string timeZone { get; set; }
        public bool firebaseEnabled { get; set; }
        public string driverInfoFormat { get; set; }
        public IList<VehicleSkillSetList> vehicleSkillSetLists { get; set; }
        public IList<DriverSkillSetList> driverSkillSetLists { get; set; }
        public string statusFlagDetails { get; set; }
        //public int Harsh Acceleration { get; set; }
        public bool isPasswordExpiryUnlimited { get; set; }
        public int businessTripCommentNotificationDays { get; set; }
        //public int Harsh Cornering { get; set; }
        public IList<DefaultDriverWorkingHour> defaultDriverWorkingHour { get; set; }
        public string tripStartTimeinWH { get; set; }
        public string tripEndTimeinWH { get; set; }
        public IList<OverSpeedCategoryList> overSpeedCategoryList { get; set; }
        public string switchType { get; set; }
        public string pagination { get; set; }
        //public int Excessive Idle { get; set; }
        public string toWorkingHour { get; set; }
        public IList<DefaultVehicleWorkingHour> defaultVehicleWorkingHour { get; set; }
        public string allowedNotification { get; set; }
        public string statusFlagDisplay { get; set; }
        //public IList<Role> roles { get; set; }
        public double latitude { get; set; }
        public bool electronicLogbook { get; set; }
        public string supportedLanguage { get; set; }
        public bool privacy { get; set; }
        public bool groupPolicy { get; set; }
        public string defaultDriverSkillSetList { get; set; }
        public bool displayVehicleFlagStatus { get; set; }
        public double speed { get; set; }
        public string driverDisplayName { get; set; }
        public string speedMesurementUnit { get; set; }
        public int lastWarningNotificationPeriod { get; set; }
        public string toSundayWorkingHour { get; set; }
        public string currency { get; set; }
        public string fromSaturdayLunchHour { get; set; }
        public string baseMapLayer { get; set; }
        public int passwordExpiry { get; set; }
        public string fromSundayWorkingHour { get; set; }
        public IList<UserSetting> userSetting { get; set; }
        public IList<CompanyInfo> companyInfo { get; set; }
        public string landingPage { get; set; }
        public string coordinateFormat { get; set; }
        public string toSaturdayWorkingHour { get; set; }
        public string defaultTrip { get; set; }
        public string fromSaturdayWorkingHour { get; set; }
        public string speedUnit { get; set; }
        public string speedLimitInfractions { get; set; }
        public string fuelMeasurementUnit { get; set; }
        public string timeFormat { get; set; }
        public string toSundayLunchHour { get; set; }
        public int CTRGenerationDelayTime { get; set; }
        public string userDisclaimer { get; set; }
        public IList<GyrRangeSetting> gyrRange { get; set; }
        public bool is2FactorAuthenticationEnabled { get; set; }
    }
    public class CompanyInfo
    {
        public string zipCode { get; set; }
        public string address { get; set; }
        public string phoneNumber { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string address1 { get; set; }
        public string companyName { get; set; }
    }

    public class GyrRangeSetting
    {
        public string red { get; set; }
        public string green { get; set; }
        public string yellow { get; set; }
    }

    public class UserSetting
    {
        //public string M-securityQuestion1 { get; set; }
        //public string O-securityQuestion2 { get; set; }
        //public string O-securityQuestion1 { get; set; }
        public bool lockoutPasswordReuse { get; set; }
        public int invalidPasswordEntryThresholdTimeInMins { get; set; }
        public bool isAccountLockoutPolicyEnabled { get; set; }
        public int maxAllowedRetryCount { get; set; }
        public int accountLockoutTimeInMins { get; set; }
    }
    //public class Role
    //{
    //    public string 1 { get; set; }
    //    public string 2 { get; set; }
    //    public string 3 { get; set; }
    //    public string 4 { get; set; }
    //    public string 5 { get; set; }
    //}
    public class DefaultVehicleWorkingHour
    {
        public string toWorkingHour { get; set; }
        public string fromSundayWorkingHour { get; set; }
        public bool enableLunch { get; set; }
        public bool includeSunday { get; set; }
        public string toSaturdayWorkingHour { get; set; }
        public string fromSaturdayWorkingHour { get; set; }
        public string fromSundayLunchHour { get; set; }
        public bool includeSaturday { get; set; }
        public string fromLunchHour { get; set; }
        public string fromWorkingHour { get; set; }
        public string toSundayWorkingHour { get; set; }
        public string toSundayLunchHour { get; set; }
        public string fromSaturdayLunchHour { get; set; }
        public bool enableSaturdayLunch { get; set; }
        public string toSaturdayLunchHour { get; set; }
        public bool enableSundayLunch { get; set; }
        public string toLunchHour { get; set; }
    }
    public class OverSpeedCategoryList
    {
        public string cat2 { get; set; }
        public string cat3 { get; set; }
        public string cat1 { get; set; }
    }
    public class DefaultDriverWorkingHour
    {
        public string toWorkingHour { get; set; }
        public string fromSundayWorkingHour { get; set; }
        public string timeZone { get; set; }
        public bool enableLunch { get; set; }
        public bool includeSunday { get; set; }
        public string toSaturdayWorkingHour { get; set; }
        public string fromSaturdayWorkingHour { get; set; }
        public string fromSundayLunchHour { get; set; }
        public bool includeSaturday { get; set; }
        public string fromLunchHour { get; set; }
        public string fromWorkingHour { get; set; }
        public string toSundayWorkingHour { get; set; }
        public string toSundayLunchHour { get; set; }
        public string fromSaturdayLunchHour { get; set; }
        public bool enableSaturdayLunch { get; set; }
        public string toSaturdayLunchHour { get; set; }
        public bool enableSundayLunch { get; set; }
        public string toLunchHour { get; set; }
    }
    public class DriverSkillSetList
    {
        public string skills { get; set; }
        public string name { get; set; }
    }
    public class VehicleSkillSetList
    {
        public string skills { get; set; }
        public string name { get; set; }
    }

    public class ColumnConfig
    {
    }
    public class AllowedNotificationList
    {
        public string name { get; set; }
        public bool selected { get; set; }
    }
    public class PasswordPolicy
    {
        public int minCharLength { get; set; }
        public int minDigits { get; set; }
        public string inValidPattern { get; set; }
        public int minLowerCaseChar { get; set; }
        public int minAlphabets { get; set; }
        public string allowedSpecialCharacters { get; set; }
        public bool canBeUserName { get; set; }
        public int maxCharLength { get; set; }
        public int minSpecialChar { get; set; }
        public bool isBlankSpaceAllowed { get; set; }
        public int minUpperCaseChar { get; set; }
    }
    public class VehicleCheckList
    {
        public string name { get; set; }
        public string checklist { get; set; }
    }
    public class SpeedViolationCategoryList
    {
        public string cat2 { get; set; }
        public string cat3 { get; set; }
        public int cat1count { get; set; }
        public string cat1 { get; set; }
        public int cat2count { get; set; }
        public int cat3count { get; set; }
        public int speed { get; set; }
    }

}
