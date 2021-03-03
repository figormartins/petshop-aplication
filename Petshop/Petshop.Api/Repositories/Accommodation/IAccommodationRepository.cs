using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petshop.Api.Repositories.Accommodation
{
    public interface IAccommodationRepository
    {
        Task<Entities.Accommodation> GetAccommodation(Guid id);

    }
}
