using AnimalApi.Models;
using AnimalApi.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AnimalApi.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IMongoCollection<Animal> _animalsCollection;

        public AnimalService(IOptions<MongoDbSettings> mongoSettings)
        {
            var client = new MongoClient(mongoSettings.Value.ConnectionString);
            var database = client.GetDatabase(mongoSettings.Value.DatabaseName);
            _animalsCollection = database.GetCollection<Animal>(mongoSettings.Value.AnimalsCollectionName);
        }

        public async Task<List<Animal>> GetAllAnimalsAsync()
        {
            return await _animalsCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Animal> GetAnimalByIdAsync(string id)
        {
            return await _animalsCollection.Find(a => a.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateAnimalAsync(Animal animal)
        {
            await _animalsCollection.InsertOneAsync(animal);
        }

        public async Task UpdateAnimalAsync(string id, Animal updatedAnimal)
        {
            await _animalsCollection.ReplaceOneAsync(a => a.Id == id, updatedAnimal);
        }

        public async Task DeleteAnimalAsync(string id)
        {
            await _animalsCollection.DeleteOneAsync(a => a.Id == id);
        }
    }
}
