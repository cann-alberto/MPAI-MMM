using MMM_Server.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MMM_Server.Services;

public class PersonalProfileService : MongoDbService<PersonalProfile>
{
    public PersonalProfileService(IOptions<MMMDatabaseSettings> profileDatabaseSettings)
        : base(profileDatabaseSettings, profileDatabaseSettings.Value.ProfilesCollectionName)
    {

    }
}
