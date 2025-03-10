﻿using MMM_Server.Models;
using Microsoft.Extensions.Options;

namespace MMM_Server.Services;

public class UserService : MongoDbService<User>
{
    public UserService(IOptions<MMMDatabaseSettings> userDatabaseSettings)
        : base(userDatabaseSettings, userDatabaseSettings.Value.UsersCollectionName)
    {

    }
}
