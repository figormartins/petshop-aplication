using Microsoft.EntityFrameworkCore;
using Petshop.Api.Persistence;
using Petshop.Api.Repositories.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petshop.Api.Repositories.Animal
{
    public class AnimalRepository : BaseRepository<Entities.Animal>, IAnimalRepository
    {
        public AnimalRepository(PetshopDbContext context) : base(context)
        {
        }

        public async Task<Entities.Animal> CreateAnimal(Entities.Animal animal)
        {
            await dbSet.AddAsync(animal);
            await context.SaveChangesAsync();
            
            return animal;
        }

        public async Task<Entities.Animal> GetAnimal(Guid id)
        {
            return await dbSet
                .Where(a => a.Id == id)
                .Include(a => a.Accommodation)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Entities.Animal>> GetAnimals(string name = null)
        {
            var animals = dbSet.Include(a => a.Accommodation).AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
            {
                animals = animals.Where(n => n.Name.Contains(name));
            }

            return await animals.ToListAsync();
        }

        public async Task<Entities.Animal> UpdateAnimal(Entities.Animal animal)
        {
            dbSet.Update(animal);
            await context.SaveChangesAsync();

            return animal;
        }

        public async Task DeleteAnimal(Entities.Animal animal)
        {
            dbSet.Remove(animal);
            await context.SaveChangesAsync();
        }
    }
}
