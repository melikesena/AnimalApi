using Microsoft.AspNetCore.Mvc;
using AnimalApi.Interfaces;
using AnimalApi.Models;

namespace AnimalApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalsController : ControllerBase
    {
        private readonly IAnimalService _animalService;

        public AnimalsController(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var animals = await _animalService.GetAllAnimalsAsync();
            return Ok(animals);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var animal = await _animalService.GetAnimalByIdAsync(id);
            if (animal == null) return NotFound();
            return Ok(animal);
        }

        [HttpGet("sound/{type}")]
        public IActionResult GetAnimalSound(string type)
        {
            AnimalBase animal;

            switch (type.ToLower())
            {
                case "kedi":
                    animal = new Cat();
                    break;
                case "köpek":
                    animal = new Dog();
                    break;
                default:
                    return BadRequest("Bilinmeyen hayvan türü.");
            }

            var sound = animal.MakeSound();
            return Ok($"{type} sesi: {sound}");
        }


        [HttpPost]
        public async Task<IActionResult> Create(Animal animal)
        {
            animal.Id = Guid.NewGuid().ToString(); // ID otomatik üret
            await _animalService.CreateAnimalAsync(animal);
            return CreatedAtAction(nameof(GetById), new { id = animal.Id }, animal);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Animal animal)
        {
            await _animalService.UpdateAnimalAsync(id, animal);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _animalService.DeleteAnimalAsync(id);
            return NoContent();
        }
    }
}
