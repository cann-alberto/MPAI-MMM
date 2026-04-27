namespace MMM_Server.Models
{
    public class MMMDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string AccountsCollectionName { get; set; } = null!;
        public string ItemsCollectionName { get; set; } = null!;
        
    }
}
