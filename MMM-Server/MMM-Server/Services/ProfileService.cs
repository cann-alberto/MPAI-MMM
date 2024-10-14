using MMM_Server.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MMM_Server.Services;

public class ProfileService
{
    private readonly IMongoCollection<Profile> _profilesCollection;
    public ProfileService(
        IOptions<MMMDatabaseSettings> profileDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            profileDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            profileDatabaseSettings.Value.DatabaseName);

        _profilesCollection = mongoDatabase.GetCollection<Profile>(
            profileDatabaseSettings.Value.ProfilesCollectionName);
    }

    public async Task<List<Profile>> GetAsync() =>
        await _profilesCollection.Find(_ => true).ToListAsync();

}
