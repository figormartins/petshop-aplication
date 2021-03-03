using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Petshop.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petshop.Api.Persistence.Configurations
{
    public class AnimalConfiguration : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder.HasKey(a => a.Id);

            builder
                .HasOne(a => a.Accommodation)
                .WithOne(a => a.Animal)
                .HasForeignKey<Animal>(a => a.AccommodationId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
