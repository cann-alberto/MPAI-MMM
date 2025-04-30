using Microsoft.Extensions.Options;
using MMM_Server.Models;
using MongoDB.Driver;

namespace MMM_Server.Services;

public class BasicMLocationService : MongoDbService<BasicMLocation>
{
    public BasicMLocationService(IOptions<MMMDatabaseSettings> basicMLocationDatabaseSettings)
           : base(basicMLocationDatabaseSettings, basicMLocationDatabaseSettings.Value.BasicMLocationsCollectionName)
    {

    }

    public async Task<BasicMLocation?> GetAsync(string id)
    {
        return await _collection.Find(x => x.BasicMLocationID == id).FirstOrDefaultAsync();
    }

    public  async Task DeleteAsync(string id)
    {
        await _collection.DeleteOneAsync(x => x.BasicMLocationID == id);
    }

    public async Task AddRightToBasicMLocationAsync(string basicMLocationId, string rightId)
    {
        var filter = Builders<BasicMLocation>.Filter.Eq(b => b.BasicMLocationID, basicMLocationId);
        var basicMLocation = await _collection.Find(filter).FirstOrDefaultAsync();

        if (basicMLocation == null)
            throw new Exception($"BasicMLocation with ID {basicMLocationId} not found.");

        if (basicMLocation.BasicMLocationRights == null)
            basicMLocation.BasicMLocationRights = new List<string>();

        if (!basicMLocation.BasicMLocationRights.Contains(rightId))
            basicMLocation.BasicMLocationRights.Add(rightId);

        var update = Builders<BasicMLocation>.Update.Set(b => b.BasicMLocationRights, basicMLocation.BasicMLocationRights);
        var result = await _collection.UpdateOneAsync(filter, update);

        if (result.MatchedCount == 0)
            throw new Exception($"Failed to add right to BasicMLocation with ID {basicMLocationId}.");
    }

    public async Task DeleteRightForBasicMLocationAsync(string basicMLocationId, string rightId)
    {
        var filter = Builders<BasicMLocation>.Filter.Eq(b => b.BasicMLocationID, basicMLocationId);
        var basicMLocation = await _collection.Find(filter).FirstOrDefaultAsync();

        if (basicMLocation == null)
            throw new Exception($"Basic MLocation with ID {basicMLocationId} not found.");

        if (basicMLocation.BasicMLocationRights == null || !basicMLocation.BasicMLocationRights.Contains(rightId))
            throw new Exception($"Right with ID {rightId} not found in BasicMLocation {basicMLocationId}.");

        basicMLocation.BasicMLocationRights.Remove(rightId);

        var update = Builders<BasicMLocation>.Update.Set(b => b.BasicMLocationRights, basicMLocation.BasicMLocationRights);
        var result = await _collection.UpdateOneAsync(filter, update);

        if (result.MatchedCount == 0)
            throw new Exception($"Failed to update the Basic MLocation with ID {basicMLocationId}.");
    }

    public async Task<List<string>> GetRightsForBasicMLocationAsync(string basicMLocationId)
    {
        var filter = Builders<BasicMLocation>.Filter.Eq(b => b.BasicMLocationID, basicMLocationId);
        var basicMLocation = await _collection.Find(filter).FirstOrDefaultAsync();

        if (basicMLocation == null)
            throw new Exception($"Basic MLocation with ID {basicMLocationId} not found.");

        return basicMLocation.BasicMLocationRights ?? new List<string>();
    }

}
