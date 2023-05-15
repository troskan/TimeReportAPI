using Microsoft.AspNetCore.Mvc;
using TimeReportAPI.DTO;
using TimeReportAPI.Repositories.Interfaces;
using TimeReportClassLibrary.Models;

namespace TimeReportAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TimeReportController : ControllerBase
    {
        private readonly ITimeReportRepository _timeReportRepository;
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IRepository<Project> _projectRepository;

        public TimeReportController(ITimeReportRepository timeReportRepository, IEmployeeRepository<Employee> employeeRepository, IRepository<Project> projectRepository)
        {
            _timeReportRepository = timeReportRepository;
            _employeeRepository = employeeRepository;
            _projectRepository = projectRepository;
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
        public async Task<ActionResult<TimeReport>> CreateTimeReport([FromBody] CreateTimeReportDTO newTimeReportDTO)
        {
            try
            {
                var employee = await _employeeRepository.Get(newTimeReportDTO.EmployeeID);
                if (employee == null)
                {
                    return NotFound($"Employee with ID {newTimeReportDTO.EmployeeID} was not found.");
                }

                var project = await _projectRepository.Get(newTimeReportDTO.ProjectID);
                if (project == null)
                {
                    return NotFound($"Project with ID {newTimeReportDTO.ProjectID} was not found.");
                }

                var newTimeReport = new TimeReport
                {
                    StartTime = newTimeReportDTO.StartTime,
                    EndTime = newTimeReportDTO.EndTime,
                    EmployeeID = newTimeReportDTO.EmployeeID,
                    ProjectID = newTimeReportDTO.ProjectID
                };

                return await _timeReportRepository.Add(newTimeReport);
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
                var timeReport = await _timeReportRepository.Get(id);
                if (timeReport == null)
                {
                    return NotFound($"TimeReport with ID {id} was not found.");
                }

                return timeReport;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [HttpGet("ReadAllReports/")]
        public async Task<ActionResult<IEnumerable<TimeReport>>> ReadAllTimeReports()
        {
            try
            {
                var timeReports = await _timeReportRepository.GetAll();
                if (timeReports == null) 
                {
                    return NotFound($"No timereports was found.");
                }

                return Ok(timeReports);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [HttpPut("UpdateTimeReport/")]
        public async Task<ActionResult<TimeReport>> UpdateTimeReport([FromBody] TimeReport newTimeReport)
        {
            try
            {
                var timeReport = await _timeReportRepository.Get(newTimeReport.TimeReportID);
                if (timeReport == null)
                {
                    return NotFound($"TimeReport with ID {newTimeReport.TimeReportID} was not found.");
                }

                var employee = await _employeeRepository.Get(newTimeReport.EmployeeID);
                if (employee == null)
                {
                    return NotFound($"Employee with ID {newTimeReport.EmployeeID} was not found.");
                }

                var project = await _projectRepository.Get(newTimeReport.ProjectID);
                if (project == null)
                {
                    return NotFound($"Project with ID {newTimeReport.ProjectID} was not found.");
                }

                return await _timeReportRepository.Update(timeReport);
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
                var timeReport = await _timeReportRepository.Get(id);

                if (timeReport == null)
                {
                    return NotFound($"Project with ID {id} was not found.");
                }

                return await _timeReportRepository.Delete(id);
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
