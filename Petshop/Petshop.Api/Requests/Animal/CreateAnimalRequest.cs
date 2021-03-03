using Petshop.Api.Enums;
using System;

namespace Petshop.Api.Requests.Animal
{
    public class CreateAnimalRequest
    {
        public string Name { get; set; }
        public string GuardianName { get; set; }
        public string GuardianAddress { get; set; }
        public string GuardianPhone { get; set; }
        public string ReasonHospitalization { get; set; }
        public HealthCondition HealthCondition { get; set; }
        public string Image { get; set; }
        public Guid AccommodationId { get; set; }
    }
}
