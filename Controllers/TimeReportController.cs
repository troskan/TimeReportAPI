using Microsoft.AspNetCore.Mvc;
using TimeReportAPI.Repositories.Interfaces;

namespace TimeReportAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TimeReportController : ControllerBase
    {
        private readonly ITimeReportRepository _timeReportRepository;

        public TimeReportController(ITimeReportRepository timeReportRepository)
        {
            _timeReportRepository = timeReportRepository;
        }

        [HttpGet("GetHoursByWeekYearEmployee")]
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
