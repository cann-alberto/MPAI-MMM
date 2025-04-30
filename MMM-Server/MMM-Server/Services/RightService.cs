using Microsoft.Extensions.Options;
using MMM_Server.Models;
using MongoDB.Driver;

namespace MMM_Server.Services;

public class RightService : MongoDbService<Right>
{    
    public RightService(IOptions<MMMDatabaseSettings> rightDatabaseSettings)
    : base(rightDatabaseSettings, rightDatabaseSettings.Value.RightsCollectionName)
    {

    }

    public async Task<Right?> GetAsync(string id)
    {
        // Add custom logic if needed
        return await _collection.Find(x => x.RightID == id).FirstOrDefaultAsync();
    }
    
    public async Task UpdateAsync(string id, Right updatedItem)
    {
        // Filter to find the account by its AccountID
        var filter = Builders<Right>.Filter.Eq(right => right.RightID, id);

        // Find the account
        var right = await _collection.Find(filter).FirstOrDefaultAsync();
        if (right == null)
        {
            throw new Exception($"Right with ID {id} not found.");
        }

        // Update the right
        var result = await _collection.ReplaceOneAsync(filter, updatedItem);
        // Throw exception if the update fails
        if (result.MatchedCount == 0)
        {
            throw new Exception($"Failed to update the right with ID {id}.");
        }
    }

    public async Task DeleteAsync(string id)
    {
        var filter = Builders<Right>.Filter.Eq(right => right.RightID, id);

        var result = await _collection.DeleteOneAsync(filter);

        if (result.DeletedCount == 0)
        {
            throw new Exception($"Right with ID {id} not found or could not be deleted.");
        }
    }
}




