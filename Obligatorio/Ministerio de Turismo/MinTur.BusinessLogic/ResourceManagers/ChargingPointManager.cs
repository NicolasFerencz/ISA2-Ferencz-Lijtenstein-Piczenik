using MinTur.BusinessLogicInterface.ResourceManagers;
using MinTur.DataAccessInterface.Facades;
using MinTur.Domain.BusinessEntities;
using System;
using System.Collections.Generic;

namespace MinTur.BusinessLogic.ResourceManagers
{
    public class ChargingPointManager : IChargingPointManager
    {
        private readonly IRepositoryFacade _repositoryFacade;

        public ChargingPointManager(IRepositoryFacade repositoryFacade)
        {
            _repositoryFacade = repositoryFacade;
        }

        public ChargingPoint RegisterChargingPoint(ChargingPoint chargingPoint)
        {         
            chargingPoint.ValidOrFail();
            return _repositoryFacade.StoreChargingPoint(chargingPoint);

        }
    
        public List<ChargingPoint> GetAllChargingPoints()
        {
            return _repositoryFacade.GetAllChargingPoints();
        }

        public void DeleteChargingPointById(int identificator)
        {
            _repositoryFacade.DeleteChargingPointById(identificator);
        }

    }
}
