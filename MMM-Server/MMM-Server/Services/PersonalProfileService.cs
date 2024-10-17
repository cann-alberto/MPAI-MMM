using MMM_Server.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MMM_Server.Services;

public class PersonalProfileService
{
    private readonly IMongoCollection<PersonalProfile> _profilesCollection;
    public PersonalProfileService(
        IOptions<MMMDatabaseSettings> profileDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            profileDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            profileDatabaseSettings.Value.DatabaseName);

        _profilesCollection = mongoDatabase.GetCollection<PersonalProfile>(
            profileDatabaseSettings.Value.ProfilesCollectionName);
    }

    public async Task<List<PersonalProfile>> GetAsync() =>
        await _profilesCollection.Find(_ => true).ToListAsync();

    public async Task CreateAsync(PersonalProfile newProfile) =>
        await _profilesCollection.InsertOneAsync(newProfile);

    /*
    public async Task<PersonalProfileData?> GetAsync(string id) =>
        await _profilesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    

    public async Task UpdateAsync(string id, PersonalProfileData updatedProfile) =>
        await _profilesCollection.ReplaceOneAsync(x => x.Id == id, updatedProfile);

    public async Task RemoveAsync(string id) =>
        await _profilesCollection.DeleteOneAsync(x => x.Id == id);
    */

}
