using Inseego.Repositories.CosmosDB.Interface;
using Inseego.Repositories.CosmosDB.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inseego.Repositories.CosmosDB.Implementation
{

    public class CTRIndexFinalRepository : ICTRIndexFinalRepository
    {
        private readonly ICosmosDBOperationsRepository<ConsolidatedTripRecord> _cosmosDBOperationsRepository;
        private readonly string collectionId = "CTRIndexFinal";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cosmosDBOperationsRepository"></param>
        public CTRIndexFinalRepository(ICosmosDBOperationsRepository<ConsolidatedTripRecord> cosmosDBOperationsRepository)
        {
            _cosmosDBOperationsRepository = cosmosDBOperationsRepository;
        }

        public async Task<List<ConsolidatedTripRecord>> GetData(string whereQuery, string partition)
        {
            try
            {
                var response = await _cosmosDBOperationsRepository.GetItemsByQueryFromCollectionAsync(whereQuery, partition, collectionId,true);
                return response;
            }
            catch (Exception e)
            {
                Inseego.Utils.Shared.ExceptionHandler.LogException("CTRIndexFinalRepository had an issue", e);
                throw;
            }
        }
    }
}
