using CityInfo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CityInfo.Controllers
{
    [Route("api/cities")]
    public class CitiesController : Controller
    {

        [HttpGet()]
        public IActionResult GetCities()
        {
            return Ok(CitiesDataStore.Curent.Cities);
        }

        [HttpGet("{id}")]
        public IActionResult GetCities(int id)
        {
            var cityToReturn = CitiesDataStore.Curent.Cities.FirstOrDefault(c=> c.Id == id);

            if(cityToReturn == null)
            {
                return NotFound();
            }

            return Ok(cityToReturn);
        }
    }
}
