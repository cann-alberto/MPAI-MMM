namespace MMM_Server.Models
{
    public class MMMDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string ProfilesCollectionName { get; set; } = null!;
        public string UsersCollectionName { get; set; } = null!;
        public string PersonaeCollectionName { get; set; } = null!;
        public string DevicesCollectionName { get; set; } = null!;
        public string AccountsCollectionName { get; set; } = null!;
        public string ActionRequestsCollectionName { get; set; } = null!;
        public string TransactionsCollectionName { get; set; } = null!;           
        public string MessagesCollectionName { get; set; } = null!;

    }
}
