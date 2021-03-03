using Microsoft.EntityFrameworkCore;
using Petshop.Api.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petshop.Api.Repositories.BaseRepository
{
    public class BaseRepository<T> where T : class
    {
        protected readonly PetshopDbContext context;
        protected readonly DbSet<T> dbSet;

        public BaseRepository(PetshopDbContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }
    }
}
