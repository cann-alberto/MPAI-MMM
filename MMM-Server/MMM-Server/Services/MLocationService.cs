using Microsoft.Extensions.Options;
using MMM_Server.Models;
using MongoDB.Driver;

namespace MMM_Server.Services;

public class MLocationService : MongoDbService<MLocation>
{
    public MLocationService(IOptions<MMMDatabaseSettings> mLocationDatabaseSettings)
           : base(mLocationDatabaseSettings, mLocationDatabaseSettings.Value.MLocationsCollectionName)
    {

    }

    public async Task<MLocation?> GetAsync(string id)
    {
        return await _collection.Find(x => x.MLocationID == id).FirstOrDefaultAsync();
    }

    public async Task DeleteAsync(string id)
    {
        await _collection.DeleteOneAsync(x => x.MLocationID == id);
    }

    public async Task AddRightToMLocationAsync(string mLocationId, string rightId)
    {
        var filter = Builders<MLocation>.Filter.Eq(m => m.MLocationID, mLocationId);
        var mLocation = await _collection.Find(filter).FirstOrDefaultAsync();

        if (mLocation == null)
            throw new Exception($"MLocation with ID {mLocationId} not found.");

        if (mLocation.MLocationRights == null)
            mLocation.MLocationRights = new List<string>();

        if (!mLocation.MLocationRights.Contains(rightId))
            mLocation.MLocationRights.Add(rightId);

        var update = Builders<MLocation>.Update.Set(m => m.MLocationRights, mLocation.MLocationRights);
        var result = await _collection.UpdateOneAsync(filter, update);

        if (result.MatchedCount == 0)
            throw new Exception($"Failed to add right to MLocation with ID {mLocationId}.");
    }

    public async Task DeleteRightForMLocationAsync(string mLocationId, string rightId)
    {
        var filter = Builders<MLocation>.Filter.Eq(m => m.MLocationID, mLocationId);
        var mLocation = await _collection.Find(filter).FirstOrDefaultAsync();

        if (mLocation == null)
            throw new Exception($"MLocation with ID {mLocationId} not found.");

        if (mLocation.MLocationRights == null || !mLocation.MLocationRights.Contains(rightId))
            throw new Exception($"Right with ID {rightId} not found in MLocation {mLocationId}.");

        mLocation.MLocationRights.Remove(rightId);

        var update = Builders<MLocation>.Update.Set(m => m.MLocationRights, mLocation.MLocationRights);
        var result = await _collection.UpdateOneAsync(filter, update);

        if (result.MatchedCount == 0)
            throw new Exception($"Failed to update the MLocation with ID {mLocationId}.");
    }

    public async Task<List<string>> GetRightsForMLocationAsync(string mLocationId)
    {
        var filter = Builders<MLocation>.Filter.Eq(m => m.MLocationID, mLocationId);
        var mLocation = await _collection.Find(filter).FirstOrDefaultAsync();

        if (mLocation == null)
            throw new Exception($"MLocation with ID {mLocationId} not found.");

        return mLocation.MLocationRights ?? new List<string>();
    }

}
