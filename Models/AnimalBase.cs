using AnimalApi.Interfaces;

namespace AnimalApi.Models
{
    public abstract class AnimalBase : IAnimalSound
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;

        public abstract string MakeSound();
    }
}
