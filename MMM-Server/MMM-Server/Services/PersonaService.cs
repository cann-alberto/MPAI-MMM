using MMM_Server.Models;
using Microsoft.Extensions.Options;

namespace MMM_Server.Services;

public class PersonaService : MongoDbService<Persona>
{
    public PersonaService(IOptions<MMMDatabaseSettings> personaDatabaseSettings)
        : base(personaDatabaseSettings, personaDatabaseSettings.Value.PersonaeCollectionName)
    {

    }
}