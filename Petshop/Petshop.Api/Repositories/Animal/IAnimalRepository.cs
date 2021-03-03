using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petshop.Api.Repositories.Animal
{
    public interface IAnimalRepository
    {
        Task<Entities.Animal> GetAnimal(Guid id);
        Task<List<Entities.Animal>> GetAnimals(string name = null);
        Task<Entities.Animal> CreateAnimal(Entities.Animal animal);
        Task<Entities.Animal> UpdateAnimal(Entities.Animal animal);
        Task DeleteAnimal(Entities.Animal animal);
    }
}
