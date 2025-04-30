using Microsoft.Extensions.Options;
using MMM_Server.Models;
using MongoDB.Driver;

namespace MMM_Server.Services;

public class ItemService : MongoDbService<Item>
{
    public ItemService(IOptions<MMMDatabaseSettings> itemDatabaseSettings)
        : base(itemDatabaseSettings, itemDatabaseSettings.Value.ItemsCollectionName)
    {

    }

    public async Task<Item?> GetAsync(string id)
    {
        // Add custom logic if needed
        return await _collection.Find(x => x.ItemID == id).FirstOrDefaultAsync();
    }
    public async Task DeleteAsync(string id)
    {
        await _collection.DeleteOneAsync(item => item.ItemID == id);
    }
    
    public async Task UpdateAsync(string itemId, Item updatedItem)
    {
        var filter = Builders<Item>.Filter.Eq(item => item.ItemID, itemId);

        var item = await _collection.Find(filter).FirstOrDefaultAsync();
        if (item== null)
        {
            throw new Exception($"Item with ID {itemId} not found.");
        }

        var result = await _collection.ReplaceOneAsync(filter, updatedItem);

        if (result.MatchedCount == 0)
        {
            throw new Exception($"Failed to update the item with ID {itemId}.");
        }
    }
}





