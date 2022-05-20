using MinTur.Domain.BusinessEntities;
using System;

namespace MinTur.BusinessLogicInterface.ResourceManagers
{
    public interface IChargingPointManager
    {
        ChargingPoint RegisterChargingPoint(ChargingPoint chargingPoint);
    }
}
