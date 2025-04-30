using Microsoft.Extensions.Options;
using MMM_Server.Models;
using MongoDB.Driver;

namespace MMM_Server.Services;

public class MessageService: MongoDbService<Message>
{
    public MessageService(IOptions<MMMDatabaseSettings> messageDatabaseSettings)
            : base(messageDatabaseSettings, messageDatabaseSettings.Value.MessagesCollectionName)
    {

    }

    public async Task<Message?> GetAsync(string id)
    {
        // Add custom logic if needed
        return await _collection.Find(x => x.MessageID == id).FirstOrDefaultAsync();
    }
}