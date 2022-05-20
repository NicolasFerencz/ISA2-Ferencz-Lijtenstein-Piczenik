using MinTur.Domain.BusinessEntities;
using System.Collections.Generic;

namespace MinTur.DataAccessInterface.Repositories
{
    public interface IChargingPointRepository
    {
        int StoreChargingPoint(ChargingPoint ChargingPoint);
        ChargingPoint GetChargingPointById(int ChargingPointId);
        List<ChargingPoint> GetAllChargingPoints();
    }
}
