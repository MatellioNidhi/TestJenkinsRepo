using Inseego.Repositories.CosmosDB.Interface;
using Inseego.Repositories.CosmosDB.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inseego.Repositories.CosmosDB.Implementation
{

    public class DevicesRepository : IDevicesRepository
    {
        private readonly ICosmosDBOperationsRepository<Devices> _cosmosDBOperationsRepository;
        private readonly string collectionId = "Devices";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cosmosDBOperationsRepository"></param>
        public DevicesRepository(ICosmosDBOperationsRepository<Devices> cosmosDBOperationsRepository)
        {
            _cosmosDBOperationsRepository = cosmosDBOperationsRepository;
        }

        public async Task<List<Devices>> GetData(string whereQuery, string partition)
        {
            try
            {
                var response = await _cosmosDBOperationsRepository.GetItemsByQueryFromCollectionAsync(whereQuery, partition, collectionId);
                return response;
            }
            catch (Exception e)
            {
                Inseego.Utils.Shared.ExceptionHandler.LogException("DevicesRepository had an issue", e);
                throw;
            }
        }
    }
}
