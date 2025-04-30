using Microsoft.Extensions.Options;
using MMM_Server.Models;
using MongoDB.Driver;

namespace MMM_Server.Services;

public class AuthenticationService : MongoDbService<Authentication>
{
    public AuthenticationService(IOptions<MMMDatabaseSettings> authenticationDatabaseSettings)
           : base(authenticationDatabaseSettings, authenticationDatabaseSettings.Value.AuthenticationsCollectionName)
    {

    }

    public async Task<Authentication?> GetAsync(string id)
    {
        return await _collection.Find(x => x.AuthenticationID == id).FirstOrDefaultAsync();
    }

    public async Task DeleteAsync(string id)
    {
        await _collection.DeleteOneAsync(x => x.AuthenticationID == id);
    }
    
}
