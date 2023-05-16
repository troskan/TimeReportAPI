using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks.Dataflow;
using TimeReportAPI.Data;
using TimeReportAPI.Repositories.Interfaces;
using TimeReportClassLibrary.Models;

namespace TimeReportAPI.Repositories
{
    public class ProjectRepository : Repository<Project>, IProjectRepository<Employee>
    {
        private readonly Context _db;
        public ProjectRepository(Context db) : base(db)
        {
            _db = db;
        }

        public async Task<List<Employee>> GetAllEmployeesByProject(int id)
        {
            var employees = from emp in _db.Employees
                            join pr in _db.ProjectEmployees on emp.EmployeeID equals pr.EmployeeID
                            where pr.ProjectID == id
                            select emp;

            return await employees.ToListAsync();
        }
    }
}
