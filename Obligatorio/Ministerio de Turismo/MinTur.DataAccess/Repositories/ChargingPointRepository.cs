using Microsoft.EntityFrameworkCore;
using MinTur.DataAccessInterface.Repositories;
using MinTur.Domain.BusinessEntities;
using MinTur.Exceptions;
using System;
using System.Linq;
using System.Collections.Generic;

namespace MinTur.DataAccess.Repositories
{
    public class ChargingPointRepository : IChargingPointRepository
    {
        protected DbContext Context { get; set; }

        public ChargingPointRepository(DbContext dbContext)
        {
            Context = dbContext;
        }

        public ChargingPoint GetChargingPointById(int chargingPointId)
        {
            if (!ChargingPointExists(chargingPointId))
                throw new ResourceNotFoundException("Could not find specified charging point");

            return Context.Set<ChargingPoint>().AsNoTracking().Where(r => r.Id == chargingPointId).FirstOrDefault();
        }

        public int StoreChargingPoint(ChargingPoint chargingPoint)
        {
            
            StoreChargingPointInDb(chargingPoint);
            return chargingPoint.Id;
        }

        private void StoreChargingPointInDb(ChargingPoint chargingPoint)
        {
            Context.Set<ChargingPoint>().Add(chargingPoint);
            Context.SaveChanges();
            Context.Entry(chargingPoint).State = EntityState.Detached;
        }

        private bool ChargingPointExists(int chargingPointId)
        {
            ChargingPoint chargingPoint = Context.Set<ChargingPoint>().AsNoTracking().Where(r => r.Id == chargingPointId).FirstOrDefault();
            return chargingPoint != null;
        }

        public List<ChargingPoint> GetAllChargingPoints()
        {
            return Context.Set<ChargingPoint>().AsNoTracking().ToList();
        }
    }
}
