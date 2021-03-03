using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petshop.Api.Validators.Animal
{
    public static class AnimalErrorMessages
    {
        public const string NameIsRequired = "Nome é obrigatório.";
        public const string GuardianNameIsRequired = "Nome do dono é obrigatório.";
        public const string GuardianAddressIsRequired = "Endereço do dono é obrigatório.";
        public const string GuardianPhoneIsRequired = "Telefone é obrigatório.";
        public const string ReasonHospitalizationIsRequired = "Razão da hospitalização é obrigatório.";
        public const string HealthConditionIsInvalid = "Estado de saúde é inválido.";
        public const string AccommodationNotFound = "Alojamento não foi encontrado.";
        public const string AccommodationIsNotFree = "Alojamento está ocupado.";
        public const string AnimalNotFound = "Animal não foi encontrado.";
    }
}
