using MMM_Server.Models;
using Microsoft.Extensions.Options;


namespace MMM_Server.Services;

public class DeviceService : MongoDbService<Device>
{
    public DeviceService(IOptions<MMMDatabaseSettings> deviceDatabaseSettings)
        : base(deviceDatabaseSettings, deviceDatabaseSettings.Value.DevicesCollectionName)
    {

    }
}