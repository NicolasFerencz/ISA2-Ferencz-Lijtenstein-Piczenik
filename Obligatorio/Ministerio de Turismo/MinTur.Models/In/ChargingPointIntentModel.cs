using MinTur.Domain.BusinessEntities;
using System;

namespace MinTur.Models.In
{
    public class ChargingPointIntentModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public int RegionId { get; set; }
        public int Identificator { get; set; }

        public ChargingPoint ToEntity() 
        {
            return new ChargingPoint()
            {
                Name = Name,
                Description = Description,
                Address = Address,
                RegionId = RegionId,
                Identificator = Identificator,
            };
        }
    }
}
