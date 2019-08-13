using CityInfo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace CityInfo.Controllers
{
    public class CitiesController : Controller
    {

        [HttpGet("api/cities")]
        public JsonResult GetCities()
        {
            return new JsonResult(CitiesDataStore.Curent.Cities);
        }
    }
}
