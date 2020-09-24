using Inseego.Dal.Shared;
using Inseego.Repositories.Postgres.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Inseego.Repositories.Postgres.Implementation
{
    public class CommonDrillRepository: ICommonDrillRepository
    {
        public async Task<string> GetCommonDrill(DateTime fromDate, DateTime toDate, string tenantId, string SelectedWeekDay, string TripType, string driverId, string vehicleId, string distanceMin, string distanceMax, string filterType = "M")
        {
            //List<Model.CommonDrill> lstDriverCommonDrill = new List<Model.CommonDrill>();
            //try
            //{
            //    return await Task.Run(() =>
            //    {
            //        var param = new object[] { fromDate.ToString("yyyy-MM-dd"), toDate.ToString("yyyy-MM-dd"), vehicleId, driverId, tenantId, SelectedWeekDay, TripType, filterType, distanceMin, distanceMax };
            //        lstDriverCommonDrill = PostgresDb.ExecuteStoredProcL<Model.CommonDrill>("public.dashboard_commondrill", param);
            //        return lstDriverCommonDrill;
            //    });
            //}
            //catch (Exception ex)
            //{ throw ex; }
            return "";

        }
    }
}
