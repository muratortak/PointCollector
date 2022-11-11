using Microsoft.AspNetCore.Mvc;

namespace PointCollector.API.Controllers
{
    [Route("[controller]")]
    
    public class RestaurantsController : ApiController
    {
        [HttpGet]
        public IActionResult GetRestaurants()
        {
            return Ok(Array.Empty<string>());
        }
    }
}
