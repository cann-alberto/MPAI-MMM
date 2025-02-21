using Microsoft.Extensions.Options;
using MMM_Server.Models;

namespace MMM_Server.Services
{
    public class ActionService : MongoDbService<ActionRequest>
    {
        public ActionService(IOptions<MMMDatabaseSettings> actionDatabaseSettings)
        : base(actionDatabaseSettings, actionDatabaseSettings.Value.ActionsCollectionName)
        {

        }
    }
}






