using Microsoft.AspNetCore.Mvc;

namespace GoogleMapsServices.SimulatorApi.Controllers
{
    [ApiController]
    [Route("maps/api/place/")]
    public class PlacesController : ControllerBase
    {
        private readonly ILogger<PlacesController> _logger;

        public PlacesController(ILogger<PlacesController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "findplacefromtext/json")]
        public ActionResult FindPlace()
        {
            return Ok();
        }
    }
}