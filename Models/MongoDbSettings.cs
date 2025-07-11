namespace AnimalApi.Models
{
    public class MongoDbSettings
    {
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
        public string AnimalsCollectionName { get; set; } = string.Empty;
    }
}
