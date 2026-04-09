using Microsoft.Extensions.Options;
using MMM_Server.Models;
using MongoDB.Driver;


namespace MMM_Server.Services;

public class AccountService : MongoDbService<Account>
{
    public AccountService(IOptions<MMMDatabaseSettings> accountDatabaseSettings)
        : base(accountDatabaseSettings, accountDatabaseSettings.Value.AccountsCollectionName)
    {

    }


    // CREATE
    public async Task CreateAsync(Account newAccount)
    {
        await _collection.InsertOneAsync(newAccount);
    }

    // READ (All)
    public async Task<List<Account>> GetAsync() =>
        await _collection.Find(_ => true).ToListAsync();

    // READ (Single)
    public async Task<Account?> GetAsync(string id)
    {
        // Add custom logic if needed
        return await _collection.Find(x => x.AccountID == id).FirstOrDefaultAsync();
    }

    // UPDATE
    public async Task UpdateAsync(string id, Account updatedAccount)
    {
        var result = await _collection.ReplaceOneAsync(x => x.AccountID == id, updatedAccount);

        if (result.MatchedCount == 0)
        {
            throw new KeyNotFoundException($"Account with ID {id} not found.");
        }
    }

    // DELETE
    public async Task RemoveAsync(string id)
    {
        var result = await _collection.DeleteOneAsync(x => x.AccountID == id);

        if (result.DeletedCount == 0)
        {
            throw new KeyNotFoundException($"Could not delete: Account with ID {id} not found.");
        }
    }

}