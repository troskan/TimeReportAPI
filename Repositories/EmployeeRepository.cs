using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Eventing.Reader;
using TimeReportAPI.Data;
using TimeReportAPI.DTO;
using TimeReportAPI.Repositories.Interfaces;
using TimeReportClassLibrary.Models;

namespace TimeReportAPI.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository<Employee>
    {
        private readonly Context _db;

        public EmployeeRepository(Context db) : base(db)  // calling base constructor here
        {
            _db = db;
        }
        public async Task<List<EmployeeTimeReportDTO>> GetTimeReportsByEmployee(int id)
        {
            var detailedTimeReports = from tr in _db.TimeReports
                                      join emp in _db.Employees on tr.EmployeeID equals emp.EmployeeID
                                      where tr.EmployeeID == id
                                      join p in _db.Projects on tr.ProjectID equals p.ProjectID
                                      select new EmployeeTimeReportDTO
                                      {
                                          TimeReportID = tr.TimeReportID,
                                          ProjectID = tr.ProjectID,
                                          ProjectName = p.ProjectName,
                                          StartTime = tr.StartTime,
                                          EndTime = tr.EndTime,
                                          TotalHoursWorked = Math.Round((tr.EndTime - tr.StartTime).TotalMinutes / 60,2)
                                      };

            return await detailedTimeReports.ToListAsync();
        }
        public async Task<IEnumerable<Employee>> GetEmployeesByProject(int id)
        {
            var projects = from emp in _db.Employees
                           join pe in _db.ProjectEmployees on emp.EmployeeID equals pe.EmployeeID
                           where pe.EmployeeID == emp.EmployeeID
                           join p in _db.Projects on pe.ProjectID equals p.ProjectID
                           where id == p.ProjectID
                           select emp;

            return await projects.ToListAsync();
        }
    }
}
