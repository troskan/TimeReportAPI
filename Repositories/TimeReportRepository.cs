using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeReportAPI.Data;
using TimeReportAPI.Repositories.Interfaces;
using TimeReportClassLibrary.Models;

namespace TimeReportAPI.Repositories
{
    public class TimeReportRepository : ITimeReportRepository
    {
        private readonly Context _context;
        private readonly ILogger<TimeReportRepository> _logger;

        public TimeReportRepository(Context context, ILogger<TimeReportRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<ActionResult<double>> GetHoursByWeek(int year, int week, int employeeId)
        {
            try
            {
                var employee = await _context.Employees.FindAsync(employeeId);

                if (employee == null)
                {
                    return new NotFoundResult();
                }

                DateTime weekStart = new DateTime(year, 1, 1).AddDays(7 * (week - 1));
                DateTime weekEnd = weekStart.AddDays(7);

                var timeReports = await _context.TimeReports
                    .Where(tr => tr.EmployeeID == employeeId && tr.StartTime >= weekStart && tr.EndTime < weekEnd)
                    .ToListAsync();

                double hoursWorked = timeReports.Sum(tr => (tr.EndTime - tr.StartTime).TotalHours);

                return hoursWorked;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An error occurred while processing the request.");
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
