using GoogleMapsServices.Client;
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

        [HttpGet("findplacefromtext/json", Name = "Find Place")]
        public ActionResult FindPlace()
        {
            var response = new PlacesFindPlaceFromTextResponse
            {
                Candidates = new List<Place>
                {
                    new Place
                    {
                        FormattedAddress = "140 George St, The Rocks NSW 2000, Australia",
                        Geometry = new Geometry
                        {
                            Location = new LatLngLiteral
                            {
                                Lat = -33.8599358m,
                                Lng = 151.2090295m
                            },
                            Viewport = new Bounds
                            {
                                Northeast = new LatLngLiteral
                                {
                                    Lat = -33.85824377010728m,
                                    Lng = 151.2104386798927m,
                                },
                                Southwest = new LatLngLiteral
                                {
                                    Lat = -33.86094342989272m,
                                    Lng = 151.2077390201073m
                                }
                            }
                        },
                        Name = "Museum of Contemporary Art Australia",
                        Rating = 4.4m
                    }
                },
                Status = PlacesSearchStatus.OK
            };

            return Ok(response);
        }
    }
}