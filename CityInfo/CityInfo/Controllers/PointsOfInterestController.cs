using CityInfo.Models;
using Microsoft.AspNetCore.JsonPatch;
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



            if (pointOfInteres.Description == pointOfInteres.Name)
            {
                ModelState.TryAddModelError("Description", "El provedor es diferente a la descripciòn");
            }


            if (!ModelState.IsValid)
            {
                return BadRequest();
            }



            var city = CitiesDataStore.Curent.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }




            var maxPointOfInterestId = CitiesDataStore.Curent.Cities.SelectMany(
                                        c => c.PointOfInterest).Max(p => p.Id);


            var finalPointOfInteres = new PointsOfInterestDto()
            {
                Id = ++maxPointOfInterestId,
                Name = pointOfInteres.Name,
                Description = pointOfInteres.Description

            };

            city.PointOfInterest.Add(finalPointOfInteres);


            return CreatedAtRoute("GetPointOfInterest", new
            {
                cityId = cityId,
                id = finalPointOfInteres.Id
            }, finalPointOfInteres);
        }


        [HttpPut("{cityId}/pointofinterest/{id}")]
        public IActionResult UpdatePointOfInterest(int cityId, int id,
            [FromBody] PointsOfInterestForCreationDto pointOfInteres)
        {
            if (pointOfInteres == null)
            {
                return BadRequest();
            }

            if (pointOfInteres.Description == pointOfInteres.Name)
            {
                ModelState.TryAddModelError("Description", "El provedor es diferente a la descripciòn");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var city = CitiesDataStore.Curent.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            var pointsOfInterestFromStore = city.PointOfInterest.FirstOrDefault(p => p.Id == id);


            if(pointsOfInterestFromStore == null)
            {
                return NotFound();
            }


            pointsOfInterestFromStore.Name = pointOfInteres.Name;
            pointsOfInterestFromStore.Description = pointOfInteres.Description;


            return NoContent();
        }


        [HttpPatch("{cityId}/pointofinterest/{id}")]
        public IActionResult PartialUpdatePointOfInterest(int cityId, int id,
            [FromBody] JsonPatchDocument<PointOfInterestForUpdateDto> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

            var city = CitiesDataStore.Curent.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            var pointsOfInterestFromStore = city.PointOfInterest.FirstOrDefault(p => p.Id == id);
            if (pointsOfInterestFromStore == null)
            {
                return NotFound();
            }


            var pointOfInterestPatch =
                new PointOfInterestForUpdateDto()
                {
                    Name = pointsOfInterestFromStore.Name,
                    Description = pointsOfInterestFromStore.Description

                };

            patchDoc.ApplyTo(pointOfInterestPatch, ModelState);


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }



            if (pointOfInterestPatch.Description == pointOfInterestPatch.Name)
            {
                ModelState.AddModelError("Description", "The provided description should be differente from the name.");
            }

            TryValidateModel(pointOfInterestPatch);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            pointsOfInterestFromStore.Name = pointOfInterestPatch.Name;
            pointsOfInterestFromStore.Description = pointOfInterestPatch.Description;

            return NoContent();


        }


        [HttpDelete("{cityId}/pointofinterest/{id}")]
        public IActionResult DeletePointOfInterest(int cityId, int id)
        {
            var city = CitiesDataStore.Curent.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            var pointsOfInterestFromStore = city.PointOfInterest.FirstOrDefault(p => p.Id == id);
            if (pointsOfInterestFromStore == null)
            {
                return NotFound();
            }


            city.PointOfInterest.Remove(pointsOfInterestFromStore);

            return NoContent();

        }

    }
}
