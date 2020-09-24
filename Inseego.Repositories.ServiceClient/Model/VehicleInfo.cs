using System;
using System.Collections.Generic;
using System.Text;

namespace Inseego.Repositories.ServiceClient.Model
{
    public class VehicleInfo
    {
        public long Count { get; set; }
        public List<VehicleInfoDatum> Data { get; set; }
    }
    public partial class VehicleInfoDatum
    {
        public string Id { get; set; }

        public string VehicleStatus { get; set; }

        public string VehicleName { get; set; }

        public string DefaultVehicleId { get; set; }

        public List<VehicleInfoDescription> Description { get; set; }

        public string DriverId { get; set; }

        public VehicleInfoAssignedDriver AssignedDriver { get; set; }

        public long? Odometer { get; set; }

        public long? RunningHours { get; set; }

        public long? Speed { get; set; }

        public long? Heading { get; set; }

        public long? LastStatusDuration { get; set; }

        public DateTimeOffset? LastReportedTime { get; set; }

        public long? SpeedLimit { get; set; }

        public VehicleInfoAddress Address { get; set; }

        public double? Longitude { get; set; }

        public double? Latitude { get; set; }

        public string DisplayName { get; set; }

        public string ProfileImage { get; set; }

        public string FleetNumber { get; set; }

        public string RegistrationNumber { get; set; }

        public string VehicleIcon { get; set; }

        public string Vin { get; set; }

        public string VehicleType { get; set; }

        public VehicleInfoParentDeviceTemplate ParentDeviceTemplate { get; set; }

        public string Color { get; set; }

        public long? Year { get; set; }

        public string Model { get; set; }

        public string Make { get; set; }

        public string Location { get; set; }

        public long? TotalDriveTime { get; set; }

        public long? TotalStopTime { get; set; }

        public DateTimeOffset? FirstStartUpTime { get; set; }
        public string DefaultImage { get; set; }

        public string VehicleSkillSet { get; set; }

        public string SerialNumber { get; set; }

        public List<string> AssignedJobs { get; set; }

        public List<VehicleInfoGroupDetail> GroupDetails { get; set; }

        public string OperationalStatus { get; set; }
    }

    public partial class VehicleInfoAddress
    {
        public string Country { get; set; }

        public string City { get; set; }

        public long? HouseNumber { get; set; }

        public string Street { get; set; }

        public string State { get; set; }

        public string County { get; set; }
    }

    public partial class VehicleInfoAssignedDriver
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Uri DriverProfileImage { get; set; }
    }

    public partial class VehicleInfoDescription
    {
        public string Lang { get; set; }

        public string Text { get; set; }
    }

    public partial class VehicleInfoParentDeviceTemplate
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }

    public partial class VehicleInfoGroupDetail
    {
        public Guid GroupId { get; set; }
        public string Name { get; set; }
    }
}
