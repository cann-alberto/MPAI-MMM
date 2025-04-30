using Microsoft.Extensions.Options;
using MMM_Server.Models;
using MongoDB.Driver;

namespace MMM_Server.Services
{
    public class ProcessActionService : MongoDbService<ProcessAction>
    {
        public ProcessActionService(IOptions<MMMDatabaseSettings> actionDatabaseSettings)
        : base(actionDatabaseSettings, actionDatabaseSettings.Value.ActionRequestsCollectionName)
        {

        }

        public async Task UpdateAsync(string id, ProcessAction updatedItem)
        {            
            var filter = Builders<ProcessAction>.Filter.Eq(action=> action.ProcessActionID, id);
            
            var action = await _collection.Find(filter).FirstOrDefaultAsync();
            if (action == null)
            {
                throw new Exception($"Process Action with ID {id} not found.");
            }            
            
            var result = await _collection.ReplaceOneAsync(filter, updatedItem);                        
            if (result.MatchedCount == 0)
            {
                throw new Exception($"Failed to update the right with ID {id}.");
            }
        }

        public async Task DeleteAsync(string id)
        {
            var filter = Builders<ProcessAction>.Filter.Eq(action=> action.ProcessActionID, id);

            var result = await _collection.DeleteOneAsync(filter);

            if (result.DeletedCount == 0)
            {
                throw new Exception($"Process Action with ID {id} not found or could not be deleted.");
            }
        }
    }
}






