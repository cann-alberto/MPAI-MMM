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
    
    public async Task<Profile?> GetAsync(string id) =>
        await _profilesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Profile newBook) =>
        await _profilesCollection.InsertOneAsync(newBook);

    public async Task UpdateAsync(string id, Profile updatedBook) =>
        await _profilesCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

    public async Task RemoveAsync(string id) =>
        await _profilesCollection.DeleteOneAsync(x => x.Id == id);

}
