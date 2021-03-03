using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Petshop.Api.Entities;
using Petshop.Api.Persistence;
using Petshop.Api.Repositories.Accommodation;
using Petshop.Api.Repositories.Animal;
using Petshop.Api.Requests;
using Petshop.Api.Requests.Animal;
using Petshop.Api.Validators.Animal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petshop.Api.Controllers
{
    [ApiController]
    [Route("api/animal")]
    public class AnimalController : ControllerBase
    {
        private readonly PetshopDbContext _petshopDbContext;
        private readonly IAccommodationRepository _accommodationRepository;
        private readonly IAnimalRepository _animalRepository;

        public AnimalController(PetshopDbContext petshopDbContext, IAccommodationRepository accommodationRepository, IAnimalRepository animalRepository)
        {
            _petshopDbContext = petshopDbContext;
            _accommodationRepository = accommodationRepository;
            _animalRepository = animalRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAnimals([FromQuery] string name)
        {
            var animals = await _animalRepository.GetAnimals(name);

            return Ok(animals);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnimalById([FromQuery] Guid id)
        {
            var animal = await _animalRepository.GetAnimal(id);

            if (animal == null)
            {
                return NotFound(AnimalErrorMessages.AnimalNotFound);
            }

            return Ok(animal);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAnimal([FromBody] CreateAnimalRequest animalRequest)
        {
            try
            {
                var validator = new CreateAnimalValidator(animalRequest, _accommodationRepository);
                await validator.Validate();

                if (validator.Validations.Any())
                {
                    return BadRequest(validator.Validations);
                }

                await _animalRepository.CreateAnimal(validator.Data);

                return CreatedAtAction(nameof(GetAnimalById), validator.Data, new { id = validator.Data.Id });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAnimal([FromBody] UpdateAnimalRequest animalRequest, [FromQuery] Guid id)
        {
            try
            {
                if (!animalRequest.Id.Equals(id))
                {
                    return BadRequest();
                }

                var validator = new UpdateAnimalValidator(animalRequest, _accommodationRepository, _animalRepository);
                await validator.Validate();

                if (validator.Validations.Any())
                {
                    return BadRequest(validator.Validations);
                }

                await _animalRepository.UpdateAnimal(validator.Data);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimalById([FromQuery] Guid id)
        {
            try
            {
                var animal = await _animalRepository.GetAnimal(id);

                if (animal == null)
                {
                    return NotFound(AnimalErrorMessages.AnimalNotFound);
                }

                await _animalRepository.DeleteAnimal(animal);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
