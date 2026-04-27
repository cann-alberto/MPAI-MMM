using Microsoft.Extensions.Options;
using MMM_Server.Models;
using MongoDB.Driver;

namespace MMM_Server.Services;

public class ItemService: MongoDbService<Item>
{
    public ItemService(IOptions<MMMDatabaseSettings> databaseSettings)
        : base(databaseSettings, databaseSettings.Value.ItemsCollectionName, x => x.ItemID)
    {

    }
}



