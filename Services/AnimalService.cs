using AnimalApi.Models;
using AnimalApi.Interfaces;

namespace AnimalApi.Services
{
    public class AnimalService : IAnimalService
    {
        // Geçici veri için bellek içi liste
        private readonly List<Animal> _animals = new();

        public Task<List<Animal>> GetAllAnimalsAsync()
        {
            return Task.FromResult(_animals);
        }

        public Task<Animal> GetAnimalByIdAsync(string id)
        {
            var animal = _animals.FirstOrDefault(a => a.Id == id);
            return Task.FromResult(animal);
        }

        public Task CreateAnimalAsync(Animal animal)
        {
            _animals.Add(animal);
            return Task.CompletedTask;
        }

        public Task UpdateAnimalAsync(string id, Animal updatedAnimal)
        {
            var animal = _animals.FirstOrDefault(a => a.Id == id);
            if (animal != null)
            {
                animal.Name = updatedAnimal.Name;
                animal.Type = updatedAnimal.Type;
            }
            return Task.CompletedTask;
        }

        public Task DeleteAnimalAsync(string id)
        {
            var animal = _animals.FirstOrDefault(a => a.Id == id);
            if (animal != null)
            {
                _animals.Remove(animal);
            }
            return Task.CompletedTask;
        }
    }
}
