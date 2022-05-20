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

        public ChargingPoint GetChargingPointByIdentificator(int chargingPointIdentificator)
        {
            if (!ChargingPointIdentificatorExists(chargingPointIdentificator))
                throw new ResourceNotFoundException("Could not find specified charging point");

            return Context.Set<ChargingPoint>().AsNoTracking().Where(r => r.Identificator == chargingPointIdentificator).FirstOrDefault();
        }


        public ChargingPoint StoreChargingPoint(ChargingPoint chargingPoint)
        {

            AssertRegionExists(chargingPoint.RegionId);
            return StoreChargingPointInDb(chargingPoint);
        }

        private ChargingPoint StoreChargingPointInDb(ChargingPoint chargingPoint)
        {
           
            Context.Set<ChargingPoint>().Add(chargingPoint);
            Context.SaveChanges();
            Context.Entry(chargingPoint).State = EntityState.Detached;
            return chargingPoint;
        }

        public List<ChargingPoint> GetAllChargingPoints()
        {
            return Context.Set<ChargingPoint>().AsNoTracking().ToList();
        }

        private bool ChargingPointExists(int chargingPointId)
        {
            ChargingPoint chargingPoint = Context.Set<ChargingPoint>().AsNoTracking().Where(r => r.Id == chargingPointId).FirstOrDefault();
            return chargingPoint != null;
        }

        private bool ChargingPointIdentificatorExists(int chargingPointIdentificator)
        {
            ChargingPoint chargingPoint = Context.Set<ChargingPoint>().AsNoTracking().Where(r => r.Identificator == chargingPointIdentificator).FirstOrDefault();
            
            return chargingPoint != null;
        }

        private void AssertRegionExists(int regionId)
        {
            Region retrievedRegion = Context.Set<Region>().Where(r => r.Id == regionId).FirstOrDefault();

            if (retrievedRegion == null)
                throw new ResourceNotFoundException("Could not find specified region");
        }

        public void DeleteChargingPointById(int identificator)
        {
            if (!ChargingPointIdentificatorExists(identificator))
                throw new ResourceNotFoundException("Could not find specified charging point");

            ChargingPoint retrievedChargingPoint = Context.Set<ChargingPoint>().Where(cp => cp.Identificator == identificator).FirstOrDefault();
            Context.Remove(retrievedChargingPoint);
            Context.SaveChanges();
        }

        public void DeleteChargingPointById(int id)
        {
            if (!ChargingPointExists(id))
                throw new ResourceNotFoundException("Could not find specified charging point");

            ChargingPoint retrievedChargingPoint = Context.Set<ChargingPoint>().Where(cp => cp.Id == id).FirstOrDefault();
            Context.Remove(retrievedChargingPoint);
            Context.SaveChanges();
        }
    }
}
