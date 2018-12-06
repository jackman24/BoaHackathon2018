using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;

namespace CognitiveServicesCore
{
    public class CosmosRepository
    {
        private DocumentClient _documentClient;
        private DocumentCollection _collectionDefinition;
        private Uri _cosmosUri => new Uri(Configuration.CosmosUrl);
        
        public async Task Initialise()
        {
            _documentClient = new DocumentClient(_cosmosUri, Configuration.CosmosKey);

            _collectionDefinition = new DocumentCollection
            {
                Id = Configuration.CollectionName
            };

            await _documentClient.CreateDatabaseIfNotExistsAsync(new Database { Id = Configuration.DatabaseName });

            _collectionDefinition = await this._documentClient.CreateDocumentCollectionIfNotExistsAsync(
                UriFactory.CreateDatabaseUri(Configuration.DatabaseName),
                _collectionDefinition,
                new RequestOptions { OfferThroughput = 400 });
        }

        public async Task Create(FaceAnalysisDocument document)
        {
            if (_documentClient == null)
            {
                await Initialise();
            }

            await _documentClient.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(Configuration.DatabaseName, 
                Configuration.CollectionName), document).ConfigureAwait(false);
        }

        public async Task<List<FaceAnalysisDocument>> GetFaceAnalysisResults(Guid sessionId)
        {
            if (_documentClient == null)
            {
                await Initialise();
            }

            IQueryable<FaceAnalysisDocument> queryResult = this._documentClient.CreateDocumentQuery<FaceAnalysisDocument>(
                    UriFactory.CreateDocumentCollectionUri(Configuration.DatabaseName, Configuration.CollectionName), new FeedOptions())
                .Where(x => x.SessionId == sessionId)
                .OrderBy(x => x.EventDateTime);

            var items = new List<FaceAnalysisDocument>();
            foreach (FaceAnalysisDocument faceAnalysisDocument in queryResult)
            {
                items.Add((FaceAnalysisDocument)faceAnalysisDocument);
            }

            return items;
        }
    }
}
