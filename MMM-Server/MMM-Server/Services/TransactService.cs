using Microsoft.Extensions.Options;
using MMM_Server.Models;
using MongoDB.Driver;

namespace MMM_Server.Services
{
    public class TransactService : MongoDbService<Transaction>
    {
        public TransactService(IOptions<MMMDatabaseSettings> transactionDatabaseSettings)
        : base(transactionDatabaseSettings, transactionDatabaseSettings.Value.TransactionsCollectionName)
        {

        }

        public async Task<Transaction?> GetAsync(string id)
        {
            // Add custom logic if needed
            return await _collection.Find(x => x.TransactionID == id).FirstOrDefaultAsync();
        }

    }
 
}
