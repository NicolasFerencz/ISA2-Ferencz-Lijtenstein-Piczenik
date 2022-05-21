using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using MinTur.BusinessLogicInterface.ResourceManagers;
using MinTur.Domain.BusinessEntities;
using MinTur.Models.In;
using MinTur.Models.Out;
using System;
using System.Linq;
using System.Collections.Generic;

namespace MinTur.WebApi.Controllers
{
    [EnableCors("AllowEverything")]
    [Route("api/chargingPoints")]
    [ApiController]
    public class ChargingPointController : ControllerBase
    {
        private readonly IChargingPointManager _chargingPointManager;
        private readonly IRegionManager _regionManager;

        public ChargingPointController(IChargingPointManager chargingPointManager,IRegionManager regionManager)
        {
            _chargingPointManager = chargingPointManager;
            _regionManager = regionManager;
        }

        [HttpGet]
        public IActionResult GetAll(){
            List<ChargingPoint> retrievedChargingPoints = _chargingPointManager.GetAllChargingPoints();
            List<ChargingPointDetailsModel> ChargingPointDetails = retrievedChargingPoints.Select(chargingPoint => new ChargingPointDetailsModel(chargingPoint)).ToList();
            return Ok(ChargingPointDetails);
        }

        [HttpPost]
        public IActionResult CreateChargingPoint([FromBody] ChargingPointIntentModel chargingPointIntentModel) 
        {
            ChargingPoint createdchargingPoint = _chargingPointManager.RegisterChargingPoint(chargingPointIntentModel.ToEntity());
            ChargingPointDetailsModel chargingPointDetailsModel = new ChargingPointDetailsModel(createdchargingPoint);
            return Created("api/chargingPoints/" + chargingPointDetailsModel.Name, chargingPointDetailsModel);
        }

    }
}
