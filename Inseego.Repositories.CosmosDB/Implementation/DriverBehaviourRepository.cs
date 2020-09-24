using Inseego.Repositories.CosmosDB.Interface;
using Inseego.Repositories.CosmosDB.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inseego.Repositories.CosmosDB.Implementation
{

    public class DriverBehaviourRepository : IDriverBehaviourRepository
    {
        private readonly ICosmosDBOperationsRepository<DriverBehaviourRecord> _cosmosDBOperationsRepository;
        private readonly string collectionId = "DriverBehaviour";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cosmosDBOperationsRepository"></param>
        public DriverBehaviourRepository(ICosmosDBOperationsRepository<DriverBehaviourRecord> cosmosDBOperationsRepository)
        {
            _cosmosDBOperationsRepository = cosmosDBOperationsRepository;
        }

        public async Task<DriverBehaviourRecord> RequestOverspeedingData(string id, string partition)
        {
            try
            {
                //var response = await _cosmosDBOperationsRepository.GetItemFromCollectionAsync(id, partition, collectionId);
                //return response;

                // Test response
                DriverBehaviourRecord objDriverBehaviourRecord = new DriverBehaviourRecord();

                //objDriverBehaviourRecord.Name = "Overspeeding";
                //objDriverBehaviourRecord.ToolTip = "Over speeding info";
                //objDriverBehaviourRecord.Icon = "<i class='fa fa-tachometer' aria-hidden='true'></i>";
                objDriverBehaviourRecord.Polarities = "Positive";
                objDriverBehaviourRecord.HWData.Data = "15";
                objDriverBehaviourRecord.HWData.Unit = "%";

                return objDriverBehaviourRecord;
            }
            catch (Exception e)
            {
                Inseego.Utils.Shared.ExceptionHandler.LogException("DriverBehaviourRepository.GetHeaderWidgetData had an issue. ", e);
                throw;
            }
        }
    }
}
