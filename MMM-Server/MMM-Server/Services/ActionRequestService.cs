using Microsoft.Extensions.Options;
using MMM_Server.Models;

namespace MMM_Server.Services
{
    public class ActionRequestService : MongoDbService<ActionRequest>
    {
        public ActionRequestService(IOptions<MMMDatabaseSettings> actionDatabaseSettings)
        : base(actionDatabaseSettings, actionDatabaseSettings.Value.ActionRequestsCollectionName)
        {

        }
    }
}






