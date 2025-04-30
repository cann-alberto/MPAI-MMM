using Microsoft.Extensions.Options;
using MMM_Server.Models;
using MongoDB.Driver;

namespace MMM_Server.Services;

public class AssetService : MongoDbService<Asset>
{
    public AssetService(IOptions<MMMDatabaseSettings> assetDatabaseSettings)
           : base(assetDatabaseSettings, assetDatabaseSettings.Value.AssetsCollectionName)
    {

    }

    public async Task<Asset?> GetAsync(string id)
    {
        return await _collection.Find(x => x.AssetID == id).FirstOrDefaultAsync();
    }

    public async Task DeleteAsync(string id)
    {
        await _collection.DeleteOneAsync(x => x.AssetID == id);
    }

    public async Task UpdateAsync(string id, Asset updatedItem)
    {
        var filter = Builders<Asset>.Filter.Eq(asset=> asset.AssetID, id);
        
        var asset = await _collection.Find(filter).FirstOrDefaultAsync();
        if (asset == null)
        {
            throw new Exception($"Asset with ID {id} not found.");
        }
        
        var result = await _collection.ReplaceOneAsync(filter, updatedItem);
        
        if (result.MatchedCount == 0)
        {
            throw new Exception($"Failed to update the asset with ID {id}.");
        }
    }  
}

