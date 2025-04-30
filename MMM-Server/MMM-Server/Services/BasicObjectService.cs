using Microsoft.Extensions.Options;
using MMM_Server.Models;
using MongoDB.Driver;

namespace MMM_Server.Services;

public class BasicObjectService : MongoDbService<BasicObject>
{
    public BasicObjectService(IOptions<MMMDatabaseSettings> basicObjectDatabaseSettings)
            : base(basicObjectDatabaseSettings, basicObjectDatabaseSettings.Value.BasicObjectsCollectionName)
    {

    }

    public async Task<BasicObject?> GetAsync(string id)
    {
        return await _collection.Find(x => x.BasicObjectID == id).FirstOrDefaultAsync();
    }

    public async Task DeleteAsync(string id)
    {
        await _collection.DeleteOneAsync(item => item.BasicObjectID== id);
    }
    
    public async Task AddRightToBasicObjectAsync(string basicObjectId, string rightId)
    {
        var filter = Builders<BasicObject>.Filter.Eq(basicObject => basicObject.BasicObjectID, basicObjectId);
        var basicObject = await _collection.Find(filter).FirstOrDefaultAsync();

        if (basicObject == null)
            throw new Exception($"Basic Object with ID {basicObjectId} not found.");

        if (basicObject.Rights == null)
            basicObject.Rights = new List<string>();

        if (!basicObject.Rights.Contains(rightId))
            basicObject.Rights.Add(rightId);

        var update = Builders<BasicObject>.Update.Set(bobj => bobj.Rights, basicObject.Rights);
        var result = await _collection.UpdateOneAsync(filter, update);

        if (result.MatchedCount == 0)
            throw new Exception($"Failed to add right to basic object with ID {basicObjectId}.");
    }

    public async Task DeleteRightForBasicObjectAsync(string basicObjectId, string rightId)
    {
        var filter = Builders<BasicObject>.Filter.Eq(basicObject => basicObject.BasicObjectID, basicObjectId);
        var basicObject = await _collection.Find(filter).FirstOrDefaultAsync();

        if (basicObject == null)
            throw new Exception($"Basic Object with ID {basicObjectId} not found.");

        if (basicObject.Rights == null || !basicObject.Rights.Contains(rightId))
            throw new Exception($"Right with ID {rightId} not found in Basic Object {basicObjectId}.");

        basicObject.Rights.Remove(rightId);

        var update = Builders<BasicObject>.Update.Set(bobj => bobj.Rights, basicObject.Rights);
        var result = await _collection.UpdateOneAsync(filter, update);

        if (result.MatchedCount == 0)
        {
            throw new Exception($"Failed to update the Basic Object with ID {basicObjectId}.");
        }

    }

    public async Task<List<string>> GetRightsForBasicObjectAsync(string basicObjectId)
    {
        var filter = Builders<BasicObject>.Filter.Eq(basicObject => basicObject.BasicObjectID, basicObjectId);
        var basicObject = await _collection.Find(filter).FirstOrDefaultAsync();

        if (basicObject == null)
        {
            throw new Exception($"Basic Object with ID {basicObjectId} not found.");
        }

        if (basicObject.Rights != null)
        {
            return basicObject.Rights;
        }

        return new List<string>();
    } 

    public async Task UpdateAsync(string basicObjectId, BasicObject updatedBasicObject)
    {        
        var filter = Builders<BasicObject>.Filter.Eq(bobj => bobj.BasicObjectID, basicObjectId);

        var bobj = await _collection.Find(filter).FirstOrDefaultAsync();
        if (bobj == null)
        {
            throw new Exception($"Basic object with ID {basicObjectId} not found.");
        }
        
        var result = await _collection.ReplaceOneAsync(filter, updatedBasicObject);
        
        if (result.MatchedCount == 0)
        {
            throw new Exception($"Failed to update the basic object with ID {basicObjectId}.");
        }
    }
}