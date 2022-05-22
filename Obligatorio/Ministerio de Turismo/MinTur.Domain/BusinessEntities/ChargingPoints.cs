using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MinTur.Exceptions;
using System.Linq;

namespace MinTur.Domain.BusinessEntities
{
    public class ChargingPoint
    {
        public int Id { get; set; }
        [Required]
        public int Identificator { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int RegionId { get; set; }
        [Required]
        public Region Region { get; set; }

        public ChargingPoint()  
        {

        }

        public virtual void ValidOrFail()
        {
            ValidateIsNotNull();
            ValidateIdentificator();
            ValidateName();
            ValidateDescription();
            ValidateAddress();
            
        }

        private void ValidateIdentificator()
        {
            if (Identificator < 999 || Identificator > 9999 )
                throw new InvalidRequestDataException("Charging point identificator must be 4 digits");
        }

        private void ValidateName()
        {
            if (Name is null || Name == "" || Name.Length > 20 || Name.Any(c => !(char.IsLetterOrDigit(c) || c == ' ')))
                throw new InvalidRequestDataException("Charging point name must be less than 20 letters and contain only alphabetical characters");
        }

        private void ValidateDescription()
        {
            if (Description is null || Description == "" || Description.Length > 60 || Description.Any(c => !(char.IsLetterOrDigit(c) || c == ' ')))
                throw new InvalidRequestDataException("Charging point description must be less than 60 letters");
        }

        private void ValidateAddress()
        {
            if (Address is null || Address == "" || Address.Length > 30)
                throw new InvalidRequestDataException("Charging point address must be less than 30 letters and contain only alphabetical characters");
        }

        private void ValidateIsNotNull()
        {
            if (Identificator == 0 || Name is null || Description is null || Address is null || RegionId == 0)
                throw new InvalidRequestDataException("All charging point fields are mandatory");
        }

    }
}
