using Microsoft.EntityFrameworkCore;
using Petshop.Api.Persistence;
using Petshop.Api.Repositories.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petshop.Api.Repositories.Accommodation
{
    public class AccommodationRepository : BaseRepository<Entities.Accommodation>, IAccommodationRepository
    {
        public AccommodationRepository(PetshopDbContext context) : base(context)
        {
        }

        public async Task<Entities.Accommodation> GetAccommodation(Guid id)
        {
            return await dbSet
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
