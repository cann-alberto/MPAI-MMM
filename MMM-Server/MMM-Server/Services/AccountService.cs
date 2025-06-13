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

    
    public async Task<Account?> GetAsync(string id)
    {
        // Add custom logic if needed
        return await _collection.Find(x => x.AccountID == id).FirstOrDefaultAsync();
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

    public async Task AddRightToAccountAsync(string accountId, string processId, string rightId)
    {
        var filter = Builders<Account>.Filter.Eq(account => account.AccountID, accountId);
        var account = await _collection.Find(filter).FirstOrDefaultAsync();

        if (account == null)
            throw new Exception($"Account with ID {accountId} not found.");
        
        if (account.ProcessData == null)
            account.ProcessData = new List<ProcessData>();

        var process = account.ProcessData.FirstOrDefault(p => p.ProcessID == processId);
        if (process == null)
        {
            process = new ProcessData
            {
                ProcessID = processId,
                RightsID = new List<string>(),
                PersonaID = new List<string>()
            };
            account.ProcessData.Add(process);
        }

        if (process.RightsID == null)
            process.RightsID = new List<string>();

        if (!process.RightsID.Contains(rightId))
            process.RightsID.Add(rightId);

        var update = Builders<Account>.Update.Set(acc => acc.ProcessData, account.ProcessData);
        var result = await _collection.UpdateOneAsync(filter, update);

        if (result.MatchedCount == 0)
            throw new Exception($"Failed to update rights for process {processId} in account with ID {accountId}.");
    }


    public async Task DeleteRightFromAccountAsync(string accountId, string processId, string rightId)
    {
        var filter = Builders<Account>.Filter.Eq(account => account.AccountID, accountId);
        var account = await _collection.Find(filter).FirstOrDefaultAsync();

        if (account == null)
            throw new Exception($"Account with ID {accountId} not found.");
        
        if (account.ProcessData == null)
            throw new Exception($"No processes found in account {accountId}.");

        var process = account.ProcessData.FirstOrDefault(p => p.ProcessID == processId);

        if (process == null)
            throw new Exception($"Process with ID {processId} not found in account {accountId}.");
        
        if (process.RightsID == null || !process.RightsID.Contains(rightId))
            throw new Exception($"Right with ID {rightId} not found in process {processId} of account {accountId}.");

        process.RightsID.Remove(rightId);

        var update = Builders<Account>.Update.Set(acc => acc.ProcessData, account.ProcessData);
        var result = await _collection.UpdateOneAsync(filter, update);

        if (result.MatchedCount == 0)
            throw new Exception($"Failed to update the account with ID {accountId}.");       
        
    }


    public async Task<List<ProcessData>> GetUserIdsByHumanIdAsync(string humanId)
    {
        var filter = Builders<Account>.Filter.Eq(acc => acc.HumanID, humanId);
        var account = await _collection.Find(filter).FirstOrDefaultAsync();

        if (account == null)
        {
            throw new Exception($"No account found with HumanID {humanId}.");
        }
        if (account.ProcessData == null)
            return new List<ProcessData>();
        else
            return account.ProcessData;
    }

    public async Task<List<string>> GetRightsForAccountAsync(string accountId, string processId)
    {
        var filter = Builders<Account>.Filter.Eq(account => account.AccountID, accountId);
        var account = await _collection.Find(filter).FirstOrDefaultAsync();

        if (account == null)
            throw new Exception($"Account with ID {accountId} not found.");

        if (account.ProcessData == null)
            return new List<string>();

        var process = account.ProcessData.FirstOrDefault(p => p.ProcessID == processId);

        if (process == null || process.RightsID == null)
            return new List<string>();

        return process.RightsID;
    }

}