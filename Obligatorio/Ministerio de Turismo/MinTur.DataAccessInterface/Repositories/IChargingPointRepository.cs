using MinTur.Domain.BusinessEntities;
using System.Collections.Generic;

namespace MinTur.DataAccessInterface.Repositories
{
    public interface IChargingPointRepository
    {
        ChargingPoint StoreChargingPoint(ChargingPoint ChargingPoint);
        ChargingPoint GetChargingPointById(int ChargingPointId);
        List<ChargingPoint> GetAllChargingPoints();
        void DeleteChargingPointById(int id);
    }
}
