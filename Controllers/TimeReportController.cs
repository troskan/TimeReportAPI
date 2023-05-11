using Microsoft.AspNetCore.Mvc;
using TimeReportAPI.Repositories.Interfaces;
using TimeReportClassLibrary.Models;

namespace TimeReportAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TimeReportController : ControllerBase
    {
        private readonly ITimeReportRepository _timeReportRepository;
        private readonly IRepository<TimeReport> _repository;

        public TimeReportController(ITimeReportRepository timeReportRepository, IRepository<TimeReport> repository)
        {
            _timeReportRepository = timeReportRepository;
            _repository = repository;
        }

        [HttpGet("GetWeeklyTimeReport/{year:int}/{week:int}/{employeeId:int}")]
        public async Task<ActionResult<double>> GetWeeklyTimeReport(int year, int week, int employeeId)
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

        [HttpPost("CreateTimeReport/")]
        public async Task<ActionResult<TimeReport>> CreateTimeReport([FromBody] TimeReport timeReport)
        {
            try
            {
                return await _repository.Add(timeReport);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [HttpGet("ReadTimeReport/{id:int}")]
        public async Task<ActionResult<TimeReport>> ReadTimeReport(int id)
        {
            try
            {
                return await _repository.Get(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [HttpPut("UpdateTimeReport/")]
        public async Task<ActionResult<TimeReport>> UpdateTimeReport([FromBody] TimeReport timeReport)
        {
            try
            {
                return await _repository.Update(timeReport);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [HttpDelete("DeleteTimeReport/{id:int}")]
        public async Task<ActionResult<TimeReport>> DeleteTimeReport(int id)
        {
            try
            {
                return await _repository.Delete(id);
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
