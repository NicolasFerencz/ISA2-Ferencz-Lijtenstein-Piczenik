using MinTur.Domain.BusinessEntities;
using System;
using System.Collections.Generic;

namespace MinTur.BusinessLogicInterface.ResourceManagers
{
    public interface IChargingPointManager
    {
        ChargingPoint RegisterChargingPoint(ChargingPoint chargingPoint);
        List<ChargingPoint> GetAllChargingPoints();
    }
}
