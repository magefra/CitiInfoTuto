using CityInfo.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.Controllers
{
    public class DummyController : Controller
    {
        private readonly CityInfoContext ctx;

        public DummyController(CityInfoContext ctx)
        {
            this.ctx = ctx;
        }

        [HttpGet]
        [Route("api/testdatabase")]
        public IActionResult TestDatabase()
        {
            return Ok();
        }

    }
}
