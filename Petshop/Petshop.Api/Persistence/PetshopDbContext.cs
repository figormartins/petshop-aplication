using Microsoft.EntityFrameworkCore;
using Petshop.Api.Entities;
using Petshop.Api.Persistence.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petshop.Api.Persistence
{
    public class PetshopDbContext : DbContext
    {
        public PetshopDbContext(DbContextOptions<PetshopDbContext> options)
            : base(options)
        {

        }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<Accommodation> Accommodations { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AnimalConfiguration());
            modelBuilder.ApplyConfiguration(new AccommodationConfiguration());
        }
    }
}
