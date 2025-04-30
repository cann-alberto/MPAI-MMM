using Microsoft.Extensions.Options;
using MMM_Server.Models;
using MongoDB.Driver;

namespace MMM_Server.Services;

public class DiscoveryService : MongoDbService<BasicDiscovery>
{
    public DiscoveryService(IOptions<MMMDatabaseSettings> discoveryDatabaseSettings)
           : base(discoveryDatabaseSettings, discoveryDatabaseSettings.Value.DiscoveriesCollectionName)
    {

    }

    public async Task<BasicDiscovery?> GetAsync(string id)
    {
        return await _collection.Find(x => x.BasicDiscoveryID == id).FirstOrDefaultAsync();
    }

    public async Task DeleteAsync(string id)
    {
        await _collection.DeleteOneAsync(x => x.BasicDiscoveryID == id);
    }
    
}
