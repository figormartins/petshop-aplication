using Petshop.Api.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Petshop.Api.Entities
{
    public class Accommodation
    {
        public Accommodation(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            AccommodationStatus = AccommodationStatus.Free;
        }

        protected Accommodation()
        {
        }

        public Guid Id { get; private set; }
        [Required]
        public string Name { get; private set; }
        public AccommodationStatus AccommodationStatus { get; private set; }
        public Animal Animal { get; private set; }

        public bool AccommodationStatusIsFree()
        {
            return this.AccommodationStatus == AccommodationStatus.Free;
        }

        public void SetAccommodationStatusToBusy()
        {
            this.AccommodationStatus = AccommodationStatus.Busy;
        }

        public void SetAccommodationStatusToWaitingGuardian()
        {
            this.AccommodationStatus = AccommodationStatus.WaitingGuardian;
        }

        public void SetAccommodationStatusToFree()
        {
            this.AccommodationStatus = AccommodationStatus.Free;
        }
    }
}
