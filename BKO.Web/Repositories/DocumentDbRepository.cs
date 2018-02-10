using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using Microsoft.Extensions.Configuration;

namespace BKO.Web.Repositories
{
    public class DocumentDbRepository<T> : IDocumentDbRepository<T> where T : class
    {
        private readonly string _collectionId;
        private readonly IConfiguration _configuration;
        private readonly string _databaseId;
        private readonly string _endpoint;
        private readonly string _key;

        private DocumentClient _client;

        public DocumentDbRepository(IConfiguration conf)
        {
            _configuration = conf;
            _collectionId = _configuration.GetConnectionString("collectionId");
            _databaseId = _configuration.GetConnectionString("databaseId");
            _endpoint = _configuration.GetConnectionString("cosmosEndpoint");
            _key = _configuration.GetConnectionString("cosmosKey");
            _client = new DocumentClient(new Uri(_endpoint), _key);
            CreateDatabaseIfNotExistsAsync().Wait();
            CreateCollectionIfNotExistsAsync().Wait();
        }

        public async Task<T> GetItemAsync(string id)
        {
            try
            {
                Document document =
                    await _client.ReadDocumentAsync(UriFactory.CreateDocumentUri(_databaseId, _collectionId, id));
                return (T) (dynamic) document;
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == HttpStatusCode.NotFound)
                {
                    return null;
                }

                throw;
            }
        }

        public async Task<IEnumerable<T>> GetItemsAsync(Expression<Func<T, bool>> predicate)
        {
            IDocumentQuery<T> query = _client.CreateDocumentQuery<T>(
                    UriFactory.CreateDocumentCollectionUri(_databaseId, _collectionId),
                    new FeedOptions {MaxItemCount = -1})
                .Where(predicate)
                .AsDocumentQuery();

            var results = new List<T>();
            while (query.HasMoreResults)
            {
                results.AddRange(await query.ExecuteNextAsync<T>());
            }

            return results;
        }

        public async Task<Document> CreateItemAsync(T item)
        {
            return await _client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(_databaseId, _collectionId),
                item);
        }

        public async Task<Document> UpdateItemAsync(string id, T item)
        {
            return await _client.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(_databaseId, _collectionId, id),
                item);
        }

        public async Task DeleteItemAsync(string id)
        {
            await _client.DeleteDocumentAsync(UriFactory.CreateDocumentUri(_databaseId, _collectionId, id));
        }

        public void Initialize()
        {
            _client = new DocumentClient(new Uri(_endpoint), _key);
            CreateDatabaseIfNotExistsAsync().Wait();
            CreateCollectionIfNotExistsAsync().Wait();
        }

        private async Task CreateDatabaseIfNotExistsAsync()
        {
            try
            {
                await _client.ReadDatabaseAsync(UriFactory.CreateDatabaseUri(_databaseId));
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == HttpStatusCode.NotFound)
                {
                    await _client.CreateDatabaseAsync(new Database {Id = _databaseId});
                }
                else
                {
                    throw;
                }
            }
        }

        private async Task CreateCollectionIfNotExistsAsync()
        {
            try
            {
                await _client.ReadDocumentCollectionAsync(
                    UriFactory.CreateDocumentCollectionUri(_databaseId, _collectionId));
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == HttpStatusCode.NotFound)
                {
                    await _client.CreateDocumentCollectionAsync(
                        UriFactory.CreateDatabaseUri(_databaseId),
                        new DocumentCollection {Id = _collectionId},
                        new RequestOptions {OfferThroughput = 1000});
                }
                else
                {
                    throw;
                }
            }
        }
    }
}