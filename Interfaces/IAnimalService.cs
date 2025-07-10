using AnimalApi.Models;

namespace AnimalApi.Interfaces
{
    public interface IAnimalService
    {
        Task<List<Animal>> GetAllAnimalsAsync();          // Tüm hayvanları getir
        Task<Animal> GetAnimalByIdAsync(string id);       // Belirli hayvanı getir
        Task CreateAnimalAsync(Animal animal);            // Yeni hayvan oluştur
        Task UpdateAnimalAsync(string id, Animal animal); // Hayvan güncelle
        Task DeleteAnimalAsync(string id);                // Hayvan sil
    }
}
