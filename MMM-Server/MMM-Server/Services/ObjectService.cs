using Microsoft.Extensions.Options;
using MMM_Server.Models;
using MongoDB.Driver;

namespace MMM_Server.Services;


public class ObjectService : MongoDbService<MObject>
{
    public ObjectService(IOptions<MMMDatabaseSettings> objectDatabaseSettings)
            : base(objectDatabaseSettings, objectDatabaseSettings.Value.ObjectsCollectionName)
    {

    }

    public async Task<MObject?> GetAsync(string id)
    {
        return await _collection.Find(x => x.ObjectID == id).FirstOrDefaultAsync();
    }

    public async Task DeleteAsync(string id)
    {
        await _collection.DeleteOneAsync(item => item.ObjectID == id);
    }
    public async Task UpdateAsync(string objectId, MObject updatedObject)
    {
        var filter = Builders<MObject>.Filter.Eq(mobj => mobj.ObjectID, objectId);

        var mobj = await _collection.Find(filter).FirstOrDefaultAsync();
        if (mobj == null)
        {
            throw new Exception($"Object with ID {objectId} not found.");
        }

        var result = await _collection.ReplaceOneAsync(filter, updatedObject);

        if (result.MatchedCount == 0)
        {
            throw new Exception($"Failed to update the object with ID {objectId}.");
        }
    }

    public async Task AddRightToObjectAsync(string objectId, string rightId)
    {
        var filter = Builders<MObject>.Filter.Eq(mObject => mObject.ObjectID, objectId);
        var mObject = await _collection.Find(filter).FirstOrDefaultAsync();

        if (mObject == null)
            throw new Exception($" Object with ID {objectId} not found.");

        if (mObject.Rights == null)
            mObject.Rights = new List<string>();

        if (!mObject.Rights.Contains(rightId))
            mObject.Rights.Add(rightId);

        var update = Builders<MObject>.Update.Set(mobj => mobj.Rights, mObject.Rights);
        var result = await _collection.UpdateOneAsync(filter, update);

        if (result.MatchedCount == 0)
            throw new Exception($"Failed to add right to basic object with ID {objectId}.");
    }

    public async Task DeleteRightToObjectAsync(string objectId, string rightId)
    {
        var filter = Builders<MObject>.Filter.Eq(mObject => mObject.ObjectID, objectId);
        var mObject = await _collection.Find(filter).FirstOrDefaultAsync();

        if (mObject == null)
            throw new Exception($"Object with ID {objectId} not found.");

        if (mObject.Rights == null || !mObject.Rights.Contains(rightId))
            throw new Exception($"Right with ID {rightId} not found in Object {objectId}.");

        mObject.Rights.Remove(rightId);

        var update = Builders<MObject>.Update.Set(bobj => bobj.Rights, mObject.Rights);
        var result = await _collection.UpdateOneAsync(filter, update);

        if (result.MatchedCount == 0)
        {
            throw new Exception($"Failed to update the Basic Object with ID {objectId}.");
        }

    }

    public async Task<List<string>> GetRightsForObjectAsync(string objectId)
    {
        var filter = Builders<MObject>.Filter.Eq(mObject => mObject.ObjectID, objectId);
        var mObject = await _collection.Find(filter).FirstOrDefaultAsync();

        if (mObject == null)
        {
            throw new Exception($"Object with ID {objectId} not found.");
        }

        if (mObject.Rights != null)
        {
            return mObject.Rights;
        }

        return new List<string>();
    }

    
}














