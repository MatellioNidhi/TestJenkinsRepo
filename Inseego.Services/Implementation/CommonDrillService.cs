using Inseego.Repositories.Postgres.Interface;
using Inseego.Repositories.ServiceClient.Interface;
using Inseego.Repositories.ServiceClient.Model;
using Inseego.Utilities;
using Inseego.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Configuration = Inseego.Utilities.Configurations;

namespace Inseego.Services.Implementation
{
    public class CommonDrillService : ICommonDrillService
    {
        private readonly ICommonDrillRepository _commonDrillRepository;
        private readonly IPersonaRepository _personaRepository;
        private readonly ISolutionRepository _solutionRepository;
        private readonly IConfigTenantRepository _configTenantRepository;

        public CommonDrillService(ICommonDrillRepository commonDrillRepository, IPersonaRepository personaRepository, ISolutionRepository solutionRepository,IConfigTenantRepository configTenantRepository)
        {
            _commonDrillRepository = commonDrillRepository;
            _personaRepository = personaRepository;
            _solutionRepository = solutionRepository;            
            _configTenantRepository = configTenantRepository;
        }
        //public async Task<LeagueTableResponse> CommonDrillData(Models.Request.BaseRequest request, string user, string leagueTableName, string title)
        //{
        //    LeagueTableResponse gridResponse = new LeagueTableResponse();
        //    decimal distance = Inseego.Utilities.CommonFunctions.DistanceByUnit(request.config.DistanceMesurementUnit);
        //    string calendarType = (request.SelectedWeekDay.Length < 7 && request.Calendar.Type.ToLower() != "day") ? "range" : request.Calendar.Type.ToString();

        //    try
        //    {
        //        List<Inseego.Repositories.Postgres.Model.CommonDrill> objIncidentVsMilesModelList = await _commonDrillRepository.GetCommonDrill(request.Calendar.From, request.Calendar.To, request.Tenant, String.Join(",", request.SelectedWeekDay.Select(x => x.ToLower())), request.TripType, String.Join(",", request.Drivers), String.Join(",", request.Vehicles), (request.Distance[0] * distance).ToString(), (request.Distance[1] * distance).ToString(), calendarType);
        //        if (objIncidentVsMilesModelList != null && objIncidentVsMilesModelList.Count > 0)
        //        {
        //            //Driver Name
        //            string[] driverIds = objIncidentVsMilesModelList.Select(x => x.DriverID).ToArray();
        //            //ConfigurationSetting configurationSetting = await _configTenantRepository.GetConfigurationSetting();
        //            DriverInfo driverData = await _iCommonService.GetDriverNameWithConfiguration(request.config.DriverInfoFormat, request.config.DriverDisplayName, driverIds);
        //            if (driverData != null && driverData.data != null && driverData.data.Count > 0)
        //                driverData.data.ForEach(x => objIncidentVsMilesModelList.Where(y => y.DriverID == x.id).Select(u => { u.DriverNameFirst = x.givenName; u.DriverNameLast = x.surname; return u; }).ToList());

        //            objIncidentVsMilesModelList.ForEach(x =>
        //            {
        //                x.DriverNameFirst = string.IsNullOrEmpty(x.DriverNameFirst) ? Configuration.NotAvailable : x.DriverNameFirst;
        //                x.DriverNameLast = string.IsNullOrEmpty(x.DriverNameLast) ? Configuration.NotAvailable : x.DriverNameLast;
        //            });

        //            //Vehicle Name
        //            VehicleInfo vehicleData = await _iCommonService.GetVehicleNameByConfiguration(request.config.DefaultVehicleId);
        //            if (vehicleData != null && vehicleData.Data != null && vehicleData.Data.Count > 0)
        //                vehicleData.Data.ForEach(x => objIncidentVsMilesModelList.Where(y => y.VehicleID == x.Id).Select(u => u.Vehicle = x.RegistrationNumber).ToList());
        //            objIncidentVsMilesModelList.Where(y => string.IsNullOrEmpty(y.Vehicle)).Select(u => u.Vehicle = Configuration.NotAvailable).ToList();

        //            gridResponse.schema = _leagueTable.GetWidgetLeagueTable(leagueTableName, request.config.DistanceMesurementUnit, request.config.DateFormat, request.config.TimeFormat);
        //            gridResponse.schema = gridResponse.schema.OrderBy(x => x.Field).ToList();
        //            gridResponse.count = objIncidentVsMilesModelList.Count;
        //            gridResponse.titleOfDrillDown = title;

        //            string TimeFormate = request.config.TimeFormat;
        //            decimal averageScore = objIncidentVsMilesModelList.Average(x => x.DriverScore);
        //            objIncidentVsMilesModelList.ForEach(x =>
        //            {
        //                decimal totalEvent = x.OSCount + x.HACount + x.HBCount + x.HCCount + x.XICount;
        //                decimal tripDistance = x.TripDistanceMetres / distance;
        //                LeagueTableData item = new LeagueTableData();
        //                item.DriverFirst = x.DriverNameFirst;
        //                item.DriverLast = x.DriverNameLast;
        //                item.Vehicle = x.Vehicle;
        //                item.Overspeeding = x.OSCount;
        //                item.Category1 = x.OSCategory1;
        //                item.Category2 = x.OSCategory2;
        //                item.Category3 = x.OSCategory3;
        //                item.HarshAcceleration = x.HACount;
        //                item.HarshBraking = x.HBCount;
        //                item.HarshCornering = x.HCCount;
        //                item.ExcessiveIdling = x.XICount;
        //                item.BusinessTime = x.BusinessTime.TimeFormateHHMMSS(TimeFormate);
        //                item.BusinessMiles = Math.Round(x.BusinessMiles / distance, 2);
        //                item.PrivateTime = x.PrivateTime.TimeFormateHHMMSS(TimeFormate);
        //                item.PrivateMiles = Math.Round(x.PrivateMiles / distance, 2);
        //                item.AllMiles = Math.Round(tripDistance, 2);
        //                item.DriverScore = Math.Round(x.DriverScore, 2);
        //                item.AverageScore = Math.Round(averageScore, 2);
        //                item.Trips = x.TripCount;
        //                item.AvgMilePerTrip = (tripDistance) > 0 ? Math.Round(((tripDistance) / x.TripCount), 2) : 0;
        //                item.TotalDriveTime = x.DriveTime.TimeFormateHHMMSS(TimeFormate);
        //                item.TotalIdleTime = x.IdleTime.TimeFormateHHMMSS(TimeFormate);
        //                item.DriveTimePercentage = Math.Round(x.TripDurationSeconds > 0 ? (x.DriveTime * 100 / x.TripDurationSeconds) : 0, 2);
        //                item.IdleTimePercentage = Math.Round(x.TripDurationSeconds > 0 ? (x.IdleTime * 100 / x.TripDurationSeconds) : 0, 2);
        //                item.MilesPerEvent = Math.Round(totalEvent > 0 ? (tripDistance / totalEvent) : 0, 2);
        //                gridResponse.data.Add(item);
        //            });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return gridResponse;

        //}
    }
}
