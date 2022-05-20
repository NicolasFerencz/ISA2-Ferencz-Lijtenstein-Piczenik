using MinTur.Domain.BusinessEntities;
using System;

namespace MinTur.Models.Out
{
    public class ChargingPointDetailsModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public string Address { get; set; }
        public int RegionId { get; set; }

        public ChargingPointDetailsModel(ChargingPoint chargingPoint)
        {
            Name = chargingPoint.Name;
            Description = chargingPoint.Description;
            Address = Address;
            RegionId = chargingPoint.RegionId;
           
        }
    }
}
