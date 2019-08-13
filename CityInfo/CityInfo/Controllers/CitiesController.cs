using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace CityInfo.Controllers
{
    public class CitiesController : Controller
    {

        [HttpGet("api/cities")]
        public JsonResult GetCities()
        {
            return new JsonResult(new List<object>
            {
                new { Id = 1, Name = ""},
                new {Id = 2, Name = ""}
            });
        }
    }
}
