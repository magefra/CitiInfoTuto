using CityInfo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.Controllers
{
    [Route("api/cities")]
    public class PointsOfInterestController : Controller
    {

        [HttpGet("{cityId}/pointofinterest")]
        public IActionResult GetPointOfInteres(int cityId)
        {
            var city = CitiesDataStore.Curent.Cities.FirstOrDefault(c => c.Id == cityId);

            if(city == null)
            {
                return NotFound();
            }

            return Ok(city.PointOfInterest);

        }


        [HttpGet("{cityId}/pointofinterest/{id}")]
        public IActionResult GetPointOfInterest(int cityId, int id)
        {
            var city = CitiesDataStore.Curent.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }



            var pointOfInteres = city.PointOfInterest.FirstOrDefault(c => c.Id == id);

            if (pointOfInteres == null)
            {
                return NotFound();
            }

            return Ok(pointOfInteres);

        }
    }
}
