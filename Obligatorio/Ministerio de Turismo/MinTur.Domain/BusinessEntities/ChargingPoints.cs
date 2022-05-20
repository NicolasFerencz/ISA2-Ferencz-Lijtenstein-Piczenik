using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MinTur.Domain.BusinessEntities
{
    public class ChargingPoint
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int RegionId { get; set; }

        public ChargingPoint()  
        {

        }
    }
}
