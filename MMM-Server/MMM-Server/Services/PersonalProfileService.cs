using MMM_Server.Models;
using Microsoft.Extensions.Options;

namespace MMM_Server.Services;

public class PersonalProfileService : MongoDbService<PersonalProfile>
{
    public PersonalProfileService(IOptions<MMMDatabaseSettings> profileDatabaseSettings)
        : base(profileDatabaseSettings, profileDatabaseSettings.Value.ProfilesCollectionName)
    {

    }
}
