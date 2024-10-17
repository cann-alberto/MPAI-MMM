using MMM_Server.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MMM_Server.Services;

public class MongoDbService<T>
{
    private readonly IMongoCollection<T> _collection;

    public MongoDbService(
        IOptions<MMMDatabaseSettings> databaseSettings,
        string collectionName)
    {
        var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
        _collection = mongoDatabase.GetCollection<T>(collectionName);
    }

    public async Task<List<T>> GetAsync() =>
        await _collection.Find(_ => true).ToListAsync();

    public async Task CreateAsync(T newItem) =>
        await _collection.InsertOneAsync(newItem);

    //public async Task<T?> GetAsync(string id) =>
    //    await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

    //public async Task UpdateAsync(string id, T updatedItem) =>
    //    await _collection.ReplaceOneAsync(x => x.Id == id, updatedItem);

    //public async Task RemoveAsync(string id) =>
    //    await _collection.DeleteOneAsync(x => x.Id == id);
}
