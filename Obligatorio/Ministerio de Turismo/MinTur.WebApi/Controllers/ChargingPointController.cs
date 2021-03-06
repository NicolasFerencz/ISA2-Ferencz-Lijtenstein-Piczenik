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

        public ChargingPointController(IChargingPointManager chargingPointManager)
        {
            _chargingPointManager = chargingPointManager;
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

        [HttpDelete("{identificator:int}")]
        public IActionResult DeleteChargingPoint(int identificator)
        {
            _chargingPointManager.DeleteChargingPointById(identificator);
            return Ok(new { ResultMessage = $"Charging Point {identificator} succesfuly deleted" });
        }

    }
}
