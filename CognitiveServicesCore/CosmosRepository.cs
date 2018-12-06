using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;

namespace CognitiveServicesCore
{
    public class CosmosRepository
    {
        private DocumentClient _documentClient;
        private DocumentCollection _collectionDefinition;

        public async Task Initialise()
        {
            _documentClient = new DocumentClient(new Uri(Configuration.CosmosUrl), Configuration.CosmosKey);

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
            await Initialise();

            await _documentClient.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(Configuration.DatabaseName, 
                Configuration.CollectionName), document).ConfigureAwait(false);
        }
    }
}
