using Petshop.Api.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Petshop.Api.Entities
{
    public class Animal
    {
        protected Animal()
        {
        }

        public Animal(string name, string guardianName, string guardianAddress, string guardianPhone, string reasonHospitalization, HealthCondition healthCondition, Accommodation accommodation, string image = null)
        {
            Id = Guid.NewGuid();
            Name = name;
            GuardianName = guardianName;
            GuardianAddress = guardianAddress;
            GuardianPhone = guardianPhone;
            ReasonHospitalization = reasonHospitalization;
            HealthCondition = healthCondition;
            Accommodation = accommodation;
            Image = image;
        }

        public Guid Id { get; private set; }
        [Required]
        public string Name { get; private set; }
        [Required]
        public string GuardianName { get; private set; }
        [Required]
        public string GuardianAddress { get; private set; }
        [Required]
        public string GuardianPhone { get; private set; }
        [Required]
        public string ReasonHospitalization { get; private set; }
        public HealthCondition HealthCondition { get; private set; }
        public string Image { get; private set; }
        public Accommodation Accommodation { get; private set; }
        public Guid? AccommodationId { get; private set; }

        public void Update(string name, string guardianName, string guardianAddress, string guardianPhone, string reasonHospitalization,
            HealthCondition healthCondition, string image = null, Accommodation accommodation = null)
        {
            this.Name = name;
            this.GuardianName = guardianName;
            this.GuardianAddress = guardianAddress;
            this.GuardianPhone = guardianPhone;
            this.ReasonHospitalization = reasonHospitalization;
            this.HealthCondition = healthCondition;
            this.Image = image;
            this.Accommodation = accommodation;
        }
    }
}
