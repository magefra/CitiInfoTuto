using CityInfo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CityInfo.Controllers
{
    [Route("api/cities")]
    public class PointsOfInterestController : Controller
    {

        [HttpGet("{cityId}/pointofinterest")]
        public IActionResult GetPointOfInteres(int cityId)
        {
            var city = CitiesDataStore.Curent.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            return Ok(city.PointOfInterest);

        }


        [HttpGet("{cityId}/pointofinterest/{id}", Name = "GetPointOfInterest")]
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

        [HttpPost("{cityID}/pointofinterest")]
        public IActionResult CreatePointInteres(int cityId,
            [FromBody] PointsOfInterestForCreationDto pointOfInteres)
        {
            if (pointOfInteres == null)
            {
                return BadRequest();
            }

            var city = CitiesDataStore.Curent.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            var maxPointOfInterestId = CitiesDataStore.Curent.Cities.SelectMany(
                                        c => c.PointOfInterest).Max(p=> p.Id);


            var finalPointOfInteres = new PointsOfInterestDto()
            {
                Id = ++maxPointOfInterestId,
                Name = pointOfInteres.Name,
                Description = pointOfInteres.Description
           
            };

            city.PointOfInterest.Add(finalPointOfInteres);


            return CreatedAtRoute("GetPointOfInterest", new
            {
                cityId = cityId, id = finalPointOfInteres.Id
            }, finalPointOfInteres);
        }
    }
}
