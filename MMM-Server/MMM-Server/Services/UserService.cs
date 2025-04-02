using MMM_Server.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MMM_Server.Services;

public class UserService : MongoDbService<User>
{
    public UserService(IOptions<MMMDatabaseSettings> userDatabaseSettings)
        : base(userDatabaseSettings, userDatabaseSettings.Value.UsersCollectionName)
    {

    }

    public async Task UpdateAsync(string id, User updatedItem)
    {
        // Filter to find the account by its AccountID
        var filter = Builders<User>.Filter.Eq(user => user.UserID, id);

        // Find the account
        var user = await _collection.Find(filter).FirstOrDefaultAsync();
        if (user == null)
        {
            throw new Exception($"User with ID {id} not found.");
        }

        // Update the Account
        var result = await _collection.ReplaceOneAsync(filter, updatedItem);
        // Throw exception if the update fails
        if (result.MatchedCount == 0)
        {
            throw new Exception($"Failed to update the user with ID {id}.");
        }
    }
    public async Task<User> GetUserByHumanIdAsync(string humanId)
    {
        // Build the filter to query the database for the HumanID
        var filter = Builders<User>.Filter.Eq(user => user.HumanID, humanId);

        // Fetch the first matching account or return null if not found
        return await _collection.Find(filter).FirstOrDefaultAsync();
    }

}
