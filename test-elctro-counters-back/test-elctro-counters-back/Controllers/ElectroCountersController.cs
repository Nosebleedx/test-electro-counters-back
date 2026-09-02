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
            var names = await _countersService.GetAllNamesAsync();
            return Ok(names);
        }

        [HttpGet("getCounterByName")]
        public async Task<ActionResult<ElectroCounter>> GetCounterByName(string name, int year, int month)
        {
            if (month < 1 || month > 12)
                return BadRequest("ћес€ц должен быть от 1 до 12");

            var counter = await _countersService.GetCounterByNameAndDateAsync(name, year, month);
            if (counter == null)
                return NotFound($"—чЄтчик с именем '{name}' за {month}/{year} не найден");

            return Ok(counter);
        }

        [HttpGet("getCounterByNameAndDay")]
        public async Task<ActionResult<OneDayElectroCounter>> GetCounterByNameAndDay(
            string name, int year, int month, int day)
        {
            if (month < 1 || month > 12)
                return BadRequest("ћес€ц должен быть от 1 до 12");

            int daysInMonth = DateTime.DaysInMonth(year, month);
            if (day < 1 || day > daysInMonth)
                return BadRequest($"ƒень должен быть от 1 до {daysInMonth} дл€ {month}/{year}");

            var counter = await _countersService.GetCounterByNameAndDateAndDayAsync(name, year, month, day);
            if (counter == null)
                return NotFound($"—чЄтчик с именем '{name}' за {day}/{month}/{year} не найден или данные за этот день отсутствуют");

            return Ok(counter);
        }
    }
}