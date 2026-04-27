using Microsoft.Extensions.Options;
using MMM_Server.Models;

namespace MMM_Server.Services;

public class AccountService : MongoDbService<Account>
{
    public AccountService(IOptions<MMMDatabaseSettings> DatabaseSettings)
        : base(DatabaseSettings, DatabaseSettings.Value.AccountsCollectionName, x=>x.AccountID)
    {

    }
    
}