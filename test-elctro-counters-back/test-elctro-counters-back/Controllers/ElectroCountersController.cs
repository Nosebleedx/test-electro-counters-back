using Microsoft.AspNetCore.Mvc;
using test_elctro_counters_back.Models;
using test_elctro_counters_back.Services;

namespace test_elctro_counters_back.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ElectroCountersController : ControllerBase
    {
        private CountersDataService _countersService;

        private readonly ILogger<ElectroCountersController> _logger;

        public ElectroCountersController(ILogger<ElectroCountersController> logger)
        {
            _logger = logger;
            _countersService = new CountersDataService();
        }

        [HttpGet("getAllNames")]
        public async Task<ActionResult<List<string>>> GetAllNames()
        {
            var names = _countersService.GetAllNamesAsync();
            return Ok(names);
        }

        [HttpGet("getCounterByName")]
        public async Task<ActionResult<ElectroCounter>> GetCounterByName(string name, int year, int month)
        {
            var counter = _countersService.GetCounterByNameAndDateAsync(name, year, month);
            if (counter == null)
            {
                return NotFound();
            }
            return Ok(counter);
        }

        [HttpGet("getCounterByNameAndDay")]
        public async Task<ActionResult<OneDayElectroCounter>> GetCounterByNameAndDay(string name, int year, int month, int day)
        {
            var counter = _countersService.GetCounterByNameAndDateAndDayAsync(name, year, month, day);
            if (counter == null)
            {
                return NotFound();
            }
            return Ok(counter);
        }
    }
}
