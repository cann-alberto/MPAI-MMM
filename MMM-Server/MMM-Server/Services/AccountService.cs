using Microsoft.Extensions.Options;
using MMM_Server.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MMM_Server.Services;

public class AccountService : MongoDbService<Account>
{
    public AccountService(IOptions<MMMDatabaseSettings> accountDatabaseSettings)
        : base(accountDatabaseSettings, accountDatabaseSettings.Value.AccountsCollectionName)
    {

    }

    // You can either override the base class GetAsync method (if you need to customize behavior)
    public async Task<Account?> GetAsync(string id)
    {
        // Add custom logic if needed
        return await _collection.Find(x => x.AccountID == id).FirstOrDefaultAsync();
    }
  

    public async Task UpdateAsync(string id, Persona updatedItem)
    {
        // Filter to find the account by its AccountID
        var filter = Builders<Account>.Filter.Eq(account => account.AccountID, id);

        // Find the account
        var account = await _collection.Find(filter).FirstOrDefaultAsync();
        if (account == null)
        {
            throw new Exception($"Account with ID {id} not found.");
        }

        // Check if the persona already exists in the Personae array
        if (updatedItem.PersonaID == null) 
        {
            updatedItem.PersonaID = ObjectId.GenerateNewId().ToString();
        }
        var existingPersona = account.Personae.FirstOrDefault(p => p.PersonaID == updatedItem.PersonaID);
        if (existingPersona != null)
        {
            // Update the existing persona
            existingPersona.Model = updatedItem.Model;
        }
        else
        {
            // Add the new persona
            account.Personae.Add(updatedItem);
        }

        // Update the Personae array in the database
        var update = Builders<Account>.Update.Set(account => account.Personae, account.Personae);
        var result = await _collection.UpdateOneAsync(filter, update);

        // Throw exception if the update fails
        if (result.MatchedCount == 0)
        {
            throw new Exception($"Failed to update the account with ID {id}.");
        }
    }

    public async Task UpdateAsync(string id, Account updatedItem)
    {
        // Filter to find the account by its AccountID
        var filter = Builders<Account>.Filter.Eq(account => account.AccountID, id);

        // Find the account
        var account = await _collection.Find(filter).FirstOrDefaultAsync();
        if (account == null)
        {
            throw new Exception($"Account with ID {id} not found.");
        }

        // Update the Account
        var result = await _collection.ReplaceOneAsync(filter, updatedItem);                
        // Throw exception if the update fails
        if (result.MatchedCount == 0)
        {
            throw new Exception($"Failed to update the account with ID {id}.");
        }
    }


    public async Task<Account> GetByHumanIdAsync(string humanId)
    {
        // Build the filter to query the database for the HumanID
        var filter = Builders<Account>.Filter.Eq(account => account.HumanID, humanId);

        // Fetch the first matching account or return null if not found
        return await _collection.Find(filter).FirstOrDefaultAsync();
    }
}