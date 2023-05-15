using Microsoft.AspNetCore.Mvc;
using TimeReportClassLibrary.Models;

namespace TimeReportAPI.Repositories.Interfaces
{
    public interface ITimeReportRepository : IRepository<TimeReport>
    {
        Task<ActionResult<double>> GetHoursByWeek(int year, int week, int employeeId);
    }
}
