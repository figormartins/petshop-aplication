using Petshop.Api.Enums;
using Petshop.Api.Repositories.Accommodation;
using Petshop.Api.Repositories.Animal;
using Petshop.Api.Requests.Animal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petshop.Api.Validators.Animal
{
    public class UpdateAnimalValidator
    {
        private readonly IAccommodationRepository _accommodationRepository;
        private readonly IAnimalRepository _animalRepository;
        private Entities.Accommodation _accommodation;
        public Entities.Animal Data { get; protected set; }
        protected UpdateAnimalRequest _input;
        public List<string> Validations { get; } = new List<string>();

        public UpdateAnimalValidator(UpdateAnimalRequest updateAnimalRequest, IAccommodationRepository accommodationRepository, IAnimalRepository animalRepository)
        {
            _input = updateAnimalRequest;
            _accommodationRepository = accommodationRepository;
            _animalRepository = animalRepository;
        }

        public virtual async Task Validate()
        {
            await ValidateAnimal();
            ValidateInformations();
            await ValidateAccommodation();
            BuildData();
        }

        private async Task ValidateAnimal()
        {
            Data = await _animalRepository.GetAnimal(_input.Id);

            if (Data == null)
            {
                Validations.Add(AnimalErrorMessages.AnimalNotFound);
            }
        }

        private void ValidateInformations()
        {
            if (string.IsNullOrWhiteSpace(_input.Name))
            {
                Validations.Add(AnimalErrorMessages.NameIsRequired);
            }

            if (string.IsNullOrWhiteSpace(_input.GuardianName))
            {
                Validations.Add(AnimalErrorMessages.GuardianNameIsRequired);
            }

            if (string.IsNullOrWhiteSpace(_input.GuardianAddress))
            {
                Validations.Add(AnimalErrorMessages.GuardianAddressIsRequired);
            }

            if (string.IsNullOrWhiteSpace(_input.GuardianPhone))
            {
                Validations.Add(AnimalErrorMessages.GuardianPhoneIsRequired);
            }

            if (string.IsNullOrWhiteSpace(_input.ReasonHospitalization))
            {
                Validations.Add(AnimalErrorMessages.ReasonHospitalizationIsRequired);
            }

            if (!Enum.IsDefined(typeof(HealthCondition), (int)_input.HealthCondition))
            {
                Validations.Add(AnimalErrorMessages.HealthConditionIsInvalid);
            }
        }

        private async Task ValidateAccommodation()
        {
            if (_input.AccommodationId.HasValue)
            {
                _accommodation = await _accommodationRepository.GetAccommodation(_input.AccommodationId.Value);

                if (_accommodation == null)
                {
                    Validations.Add(AnimalErrorMessages.AccommodationNotFound);
                }
                else if (!_accommodation.AccommodationStatusIsFree())
                {
                    Validations.Add(AnimalErrorMessages.AccommodationIsNotFree);
                }
            }
        }

        private void BuildData()
        {
            if (Validations.Any())
            {
                return;
            }

            if (_accommodation != null)
            {
                _accommodation.SetAccommodationStatusToBusy();

                if (Data.Accommodation != null && Data.Accommodation.Id.Equals(_accommodation.Id))
                {
                    Data.Accommodation.SetAccommodationStatusToFree();
                }
            }

            Data.Update(_input.Name, _input.GuardianName, _input.GuardianAddress, _input.GuardianPhone, _input.ReasonHospitalization,
                _input.HealthCondition, _input.Image, _accommodation);
        }
    }
}
