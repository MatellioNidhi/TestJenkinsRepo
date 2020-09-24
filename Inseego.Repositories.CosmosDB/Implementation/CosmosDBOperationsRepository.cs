using Inseego.Utilities;
using Inseego.Utilities.Models;
using Inseego.Repositories.CosmosDB.Interface;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Inseego.Repositories.CosmosDB.Implementation
{
    /// <summary>
    /// 
    /// </summary>
    public class CosmosDBOperationsRepository<T> : ICosmosDBOperationsRepository<T>
    {

        #region The DocumentDB Endpoint, Key, DatabaseId and CollectionId declaration
        private static readonly string Endpoint;//= "https://inseego-cosmos-db.documents.azure.com:443/";
        private static readonly string Key;//= "AXmDMPeOHA7oOR3ncXeJnsJhUt7caEPXFArc7AiPJNh1xT4DKu5ZVTFBC1mD6Vzc4SDErRsAxUf7x0yyeMgprA==";
        private static readonly string DatabaseId;//= "inseego";
        private static DocumentClient docClient;
        #endregion


        static CosmosDBOperationsRepository()
        {
            Endpoint = Configuration.EndpointUrl;
            Key = Configuration.Key;
            DatabaseId = Configuration.Database;
            docClient = new DocumentClient(new Uri(Endpoint), Key);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static async Task CreateDatabaseIfNotExistsAsync()
        {
            try
            {
                await docClient.ReadDatabaseAsync(UriFactory.CreateDatabaseUri(DatabaseId));
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    await docClient.CreateDatabaseAsync(new Database { Id = DatabaseId });
                }
                else
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        //private static async Task CreateCollectionIfNotExistsAsync(string collectionId)
        //{
        //    try
        //    {
        //        await docClient.ReadDocumentCollectionAsync(UriFactory.CreateDocumentCollectionUri(
        //            DatabaseId, collectionId));
        //    }
        //    catch (DocumentClientException e)
        //    {
        //        if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
        //        {
        //            await docClient.CreateDocumentCollectionAsync(
        //                UriFactory.CreateDatabaseUri(DatabaseId),
        //                new DocumentCollection { Id = collectionId });
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }
        //}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="strId"></param>
        /// <param name="strPartition"></param>
        /// <returns></returns>
        public async Task<T> AddDocumentIntoCollectionAsync(T item, string strId, string strPartition, string collectionId)
        {
            try
            {
                var document = await docClient.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(DatabaseId, collectionId), item);

                var res = document.Resource;
                var task = JsonConvert.DeserializeObject<T>(res.ToString());
                return task;
            }
            catch (DocumentClientException de)
            {
                if (de.StatusCode == HttpStatusCode.NotFound)
                {
                    var document = await docClient.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(DatabaseId, collectionId), item);
                    var res = document.Resource;
                    var task = JsonConvert.DeserializeObject<T>(res.ToString());
                    return task;
                }
                else
                {
                    throw de;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="partition"></param>
        /// <returns></returns>
        public async Task<bool> DeleteDocumentFromCollectionAsync(string id, string partition, string collectionId)
        {
            try
            {
                await docClient.DeleteDocumentAsync(UriFactory.CreateDocumentUri(
                    DatabaseId, collectionId, id), new RequestOptions { PartitionKey = new PartitionKey(partition) });
                return true;
            }
            catch (DocumentClientException de)
            {
                if (de.StatusCode == HttpStatusCode.NotFound)
                {
                    return false;
                }
                else
                {
                    throw de;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// get documents collection by status 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="partition"></param>
        /// <returns></returns>
        public async Task<T> GetItemFromCollectionAsync(string id, string partition, string collectionId)
        {
            try
            {
                Document doc = await docClient.ReadDocumentAsync(
                    UriFactory.CreateDocumentUri(DatabaseId, collectionId, id),
                    new RequestOptions { PartitionKey = new PartitionKey(partition) });
                return JsonConvert.DeserializeObject<T>(doc.ToString());
            }
            catch (DocumentClientException de)
            {
                if (de.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return default(T);
                }
                else
                {
                    throw de;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> GetItemByQueryFromCollectionAsync(string whereQuery, string partition, string collectionId)
        {
            try
            {
                FeedOptions queryOptions = new FeedOptions { MaxItemCount = -1, PartitionKey = new PartitionKey(partition) };

                var documents = docClient.CreateDocumentQuery<T>(
                    UriFactory.CreateDocumentCollectionUri(DatabaseId, collectionId),
                    "SELECT * FROM " + collectionId + "" + whereQuery + "", queryOptions)
                    .AsDocumentQuery();

                List<T> items = new List<T>();
                while (documents.HasMoreResults)
                {
                    items.AddRange(await documents.ExecuteNextAsync<T>());
                }
                return items.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<T>> GetItemsByQueryFromCollectionAsync(string whereQuery, string partition, string collectionId, bool enableCrossPartitionQuery = false)
        {
            try
            {
                FeedOptions queryOptions = new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = enableCrossPartitionQuery };

                if (!enableCrossPartitionQuery)
                    queryOptions.PartitionKey = new PartitionKey(partition);


                var documents = docClient.CreateDocumentQuery<T>(
                UriFactory.CreateDocumentCollectionUri(DatabaseId, collectionId),
                "SELECT * FROM " + collectionId + "" + whereQuery + "",
                queryOptions).AsDocumentQuery();

                List<T> items = new List<T>();
                while (documents.HasMoreResults)
                {
                    var t = await documents.ExecuteNextAsync<T>();
                    items.AddRange(t);
                }
                return items;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// /
        /// </summary>
        /// <param name="partition"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetItemsFromCollectionAsync(string partition, string collectionId, bool enableCrossPartitionQuery = false)
        {
            FeedOptions queryOptions = new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = enableCrossPartitionQuery };

            if (!enableCrossPartitionQuery)
                queryOptions.PartitionKey = new PartitionKey(partition);

            var documents = docClient.CreateDocumentQuery<T>(
                  UriFactory.CreateDocumentCollectionUri(DatabaseId, collectionId), queryOptions)
            .AsDocumentQuery();
            List<T> tasks = new List<T>();
            while (documents.HasMoreResults)
            {
                tasks.AddRange(await documents.ExecuteNextAsync<T>());
            }
            return tasks;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<T> UpdateDocumentFromCollection(string id, T item, string partition, string collectionId)
        {
            try
            {
                //var documents = await docClient.ReplaceDocumentAsync(
                //UriFactory.CreateDocumentUri(DatabaseId, collectionId, id), item,
                //new RequestOptions { PartitionKey = new PartitionKey(partition) });

                System.Uri uri = UriFactory.CreateDocumentUri(DatabaseId, collectionId, id);

                var obj = new RequestOptions { PartitionKey = new PartitionKey(partition) };

                var document = await docClient.ReplaceDocumentAsync(
                    UriFactory.CreateDocumentUri(DatabaseId, collectionId, id), item,
                    new RequestOptions { PartitionKey = new PartitionKey(partition) });
                var data = document.Resource.ToString();
                var task = JsonConvert.DeserializeObject<T>(data);
                return task;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<T1>> GetItemsByQueryFromCollectionAsync<T1>(string selectQuery, string whereQuery, string partition, string collectionId, bool enableCrossPartitionQuery = false)
        {
            try
            {

                FeedOptions queryOptions = new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = enableCrossPartitionQuery };

                if (!enableCrossPartitionQuery)
                    queryOptions.PartitionKey = new PartitionKey(partition);

                var documents = docClient.CreateDocumentQuery<T1>(
                UriFactory.CreateDocumentCollectionUri(DatabaseId, collectionId),
                selectQuery + whereQuery + "",
                queryOptions).AsDocumentQuery();

                List<T1> tasks = new List<T1>();
                while (documents.HasMoreResults)
                {
                    tasks.AddRange(await documents.ExecuteNextAsync<T1>());
                }
                return tasks;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public async Task<short> AutoCloseTasks<T1>(string selectQuery, string whereQuery,
        //    string partition, bool crossPartition = false)
        //{
        //    try
        //    {
        //        FeedOptions queryOptions = new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true };

        //        var documents = docClient.CreateDocumentQuery<Document>(
        //            UriFactory.CreateDocumentCollectionUri(DatabaseId, CollectionId),
        //            selectQuery + whereQuery + "",
        //            queryOptions).ToList();

        //        if (documents.Count > 0)
        //        {
        //            foreach (var doc in documents)
        //            {
        //                TaskModel task = JsonConvert.DeserializeObject<TaskModel>(doc.ToString());
        //                StatusModel currentStatus = task.CurrentStatus;
        //                currentStatus.Status = $"{ExtenstionClass.Description(Enumerations.TaskStatus.AutoCompleted)}";
        //                doc.SetPropertyValue("currentStatus", currentStatus);
        //                doc.SetPropertyValue("isCompleted", true);
        //                await docClient.ReplaceDocumentAsync(doc);
        //            }

        //            return 1;
        //        }

        //        return 2;
        //    }
        //    catch (DocumentClientException de)
        //    {
        //        if (de.StatusCode == HttpStatusCode.NotFound)
        //        {
        //            return 3;
        //        }
        //        else
        //        {
        //            throw de;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public async Task CreateCollectionIfNotExistsAsync(string collectionId)
        {
            try
            {
                DocumentCollection collection = await docClient.CreateDocumentCollectionIfNotExistsAsync(
                UriFactory.CreateDatabaseUri(DatabaseId), new DocumentCollection
                {
                    Id = collectionId,
                    PartitionKey = new PartitionKeyDefinition { Paths = new System.Collections.ObjectModel.Collection<string> { "/tenantId" } }
                }, new RequestOptions { OfferThroughput = 400 });
            }
            catch (DocumentClientException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }


}

