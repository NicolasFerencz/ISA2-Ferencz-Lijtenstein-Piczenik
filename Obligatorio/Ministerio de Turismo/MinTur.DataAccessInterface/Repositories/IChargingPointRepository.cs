using MinTur.Domain.BusinessEntities;

namespace MinTur.DataAccessInterface.Repositories
{
    public interface IChargingPointRepository
    {
        int StoreChargingPoint(ChargingPoint ChargingPoint);
        ChargingPoint GetChargingPointById(int ChargingPointId);
    }
}
