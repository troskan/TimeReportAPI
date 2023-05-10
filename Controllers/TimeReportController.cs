using Microsoft.AspNetCore.Mvc;
using TimeReportAPI.Repositories.Interfaces;

namespace TimeReportAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TimeReportController : ControllerBase
    {
        private readonly ITimeReportRepository _timeReportRepository;

        public TimeReportController(ITimeReportRepository timeReportRepository)
        {
            _timeReportRepository = timeReportRepository;
        }

        [HttpGet(Name = "GetHoursByWeekYearEmployee")]
        public async Task<ActionResult<double>> GetHoursByWeekYearEmployee([FromQuery] int year, int week, int employeeId)
        {
            try
            {
                return await _timeReportRepository.GetHoursByWeek(year, week, employeeId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }
    }
}
