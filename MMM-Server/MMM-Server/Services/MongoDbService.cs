﻿using MMM_Server.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace MMM_Server.Services;

public class MongoDbService<T>
{
    protected readonly IMongoCollection<T> _collection;
    private readonly Expression<Func<T, string>> _idSelector;


    public MongoDbService(
        IOptions<MMMDatabaseSettings> databaseSettings,
        string collectionName,
        Expression<Func<T, string>> idSelector)
    {
        var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
        _collection = mongoDatabase.GetCollection<T>(collectionName);
        _idSelector = idSelector;
    }
    

    public async Task<List<T>> GetAsync() =>
        await _collection.Find(_ => true).ToListAsync();

    public async Task<T?> GetAsync(string id)
    {
        var filter = Builders<T>.Filter.Eq(_idSelector, id);
        return await _collection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task CreateAsync(T newItem) =>
        await _collection.InsertOneAsync(newItem);

    public async Task UpdateAsync(string id, T updatedItem)
    {
        var filter = Builders<T>.Filter.Eq(_idSelector, id);
        var result = await _collection.ReplaceOneAsync(filter, updatedItem);

        if (result.MatchedCount == 0)
            throw new KeyNotFoundException($"{typeof(T).Name} with ID {id} not found.");
    }

    public async Task RemoveAsync(string id)
    {
        var filter = Builders<T>.Filter.Eq(_idSelector, id);
        var result = await _collection.DeleteOneAsync(filter);

        if (result.DeletedCount == 0)
            throw new KeyNotFoundException($"Could not delete: {typeof(T).Name} with ID {id} not found.");
    }

}
