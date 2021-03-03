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
    public class CreateAnimalValidator
    {
        private readonly IAccommodationRepository _accommodationRepository;
        private Entities.Accommodation _accommodation;
        protected CreateAnimalRequest _input;

        public Entities.Animal Data { get; protected set; }
        public List<string> Validations { get; } = new List<string>();

        public CreateAnimalValidator(CreateAnimalRequest createAnimalRequest, IAccommodationRepository accommodationRepository)
        {
            _input = createAnimalRequest;
            _accommodationRepository = accommodationRepository;
        }

        public virtual async Task Validate()
        {
            ValidateInformations();
            await ValidateAccommodation();
            BuildData();
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
            _accommodation = await _accommodationRepository.GetAccommodation(_input.AccommodationId);

            if (_accommodation == null)
            {
                Validations.Add(AnimalErrorMessages.AccommodationNotFound);
            }
            else if (!_accommodation.AccommodationStatusIsFree())
            {
                Validations.Add(AnimalErrorMessages.AccommodationIsNotFree);
            }
        }
        private void BuildData()
        {
            _accommodation.SetAccommodationStatusToBusy();
            Data = new Entities.Animal(_input.Name, _input.GuardianName, _input.GuardianAddress, _input.GuardianPhone,
                   _input.ReasonHospitalization, _input.HealthCondition, _accommodation, _input.Image);
        }
    }
}