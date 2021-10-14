namespace TllApi.Models
{
    public class TllApiDatabaseSettings : ITllApiDatabaseSettings
    {
        public string SongsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface ITllApiDatabaseSettings
    {
        string SongsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}