using Microsoft.Extensions.Options;
using MMM_Server.Models;
using MongoDB.Driver;

namespace MMM_Server.Services
{
    public class WalletService : MongoDbService<Wallet>
    {
        public WalletService(IOptions<MMMDatabaseSettings> walletDatabaseSettings)
        : base(walletDatabaseSettings, walletDatabaseSettings.Value.WalletsCollectionName)
        {

        }

        public async Task<Wallet?> GetAsync(string id)
        {
            // Add custom logic if needed
            return await _collection.Find(x => x.WalletID == id).FirstOrDefaultAsync();
        }

        public async Task<Wallet?> GetByIdAsync(string id)
        {
            return await _collection.Find(x => x.WalletID == id).FirstOrDefaultAsync();
        }      

        public async Task UpdateAsync(string id, Wallet updatedItem)
        {
            // Filter to find the account by its AccountID
            var filter = Builders<Wallet>.Filter.Eq(wallet => wallet.WalletID, id);

            // Find the account
            var wallet = await _collection.Find(filter).FirstOrDefaultAsync();
            if (wallet == null)
            {
                throw new Exception($"Wallet with ID {id} not found.");
            }

            // Update the wallet
            var result = await _collection.ReplaceOneAsync(filter, updatedItem);
            // Throw exception if the update fails
            if (result.MatchedCount == 0)
            {
                throw new Exception($"Failed to update the wallet with ID {id}.");
            }
        }
    }
}
