using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Inseego.Repositories.Postgres.Interface
{
    public interface ICommonDrillRepository
    {
        Task<string> GetCommonDrill(DateTime fromDate, DateTime toDate, string tenantId, string SelectedWeekDay, string TripType, string driverId, string vehicleId, string distanceMin, string distanceMax, string filterType = "M");
    }
}
