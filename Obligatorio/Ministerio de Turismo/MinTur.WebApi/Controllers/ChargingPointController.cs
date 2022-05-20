using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using MinTur.BusinessLogicInterface.ResourceManagers;
using MinTur.Domain.BusinessEntities;
using MinTur.Models.In;
using MinTur.Models.Out;

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

        [HttpPost]
        public IActionResult CreateChargingPoint([FromBody] ChargingPointIntentModel chargingPointIntentModel) 
        {
            ChargingPoint createdchargingPoint = _chargingPointManager.RegisterChargingPoint(chargingPointIntentModel.ToEntity());
            ChargingPointDetailsModel chargingPointDetailsModel = new ChargingPointDetailsModel(createdchargingPoint);
            return Created("api/chargingPoints/" + chargingPointDetailsModel.Name, chargingPointDetailsModel);
        }

    }
}
