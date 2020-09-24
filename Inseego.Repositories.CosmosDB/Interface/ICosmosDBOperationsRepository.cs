using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inseego.Repositories.CosmosDB.Interface
{
    public interface ICosmosDBOperationsRepository<T>
    {
        Task<IEnumerable<T>> GetItemsFromCollectionAsync(string partition, string collectionId, bool enableCrossPartitionQuery = false);
        Task<T> GetItemFromCollectionAsync(string id, string partition, string collectionId);
        Task<T> AddDocumentIntoCollectionAsync(T item, string strId, string partition, string collectionId);
        Task<T> UpdateDocumentFromCollection(string id, T item, string partition, string collectionId);
        Task<bool> DeleteDocumentFromCollectionAsync(string id, string partition, string collectionId);
        Task<T> GetItemByQueryFromCollectionAsync(string whereQuery, string partition, string collectionId);
        Task<List<T>> GetItemsByQueryFromCollectionAsync(string whereQuery, string partition, string collectionId, bool enableCrossPartitionQuery = false);
        Task<List<T1>> GetItemsByQueryFromCollectionAsync<T1>(string selectQuery, string whereQuery, string partition, string collectionId, bool enableCrossPartitionQuery = false);
        //   Task<short> AutoCloseTasks<T1>(string selectQuery, string whereQuery, string partition, bool crossPartition = false);
         Task CreateCollectionIfNotExistsAsync(string collectionId);
        
    }
}
