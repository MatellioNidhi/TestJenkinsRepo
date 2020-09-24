using Inseego.Repositories.CosmosDB.Interface;
using Inseego.Repositories.CosmosDB.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inseego.Repositories.CosmosDB.Implementation
{

    public class UsersRepository : IUsersRepository
    {
        private readonly ICosmosDBOperationsRepository<Users> _cosmosDBOperationsRepository;
        private readonly string collectionId = "User";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cosmosDBOperationsRepository"></param>
        public UsersRepository(ICosmosDBOperationsRepository<Users> cosmosDBOperationsRepository)
        {
            _cosmosDBOperationsRepository = cosmosDBOperationsRepository;
        }

        public async Task<List<Users>> GetData(string whereQuery, string partition)
        {
            try
            {
                var response = await _cosmosDBOperationsRepository.GetItemsByQueryFromCollectionAsync(whereQuery, partition, collectionId);
                return response;
            }
            catch (Exception e)
            {
                Inseego.Utils.Shared.ExceptionHandler.LogException("UserRepository had an issue", e);
                throw;
            }
        }
    }
}
