using Microsoft.EntityFrameworkCore;
using TimeReportAPI.Data;
using TimeReportAPI.Repositories.Interfaces;
using TimeReportClassLibrary.Models;

namespace TimeReportAPI.Repositories
{
    public class ProjectEmployeeRepository : Repository<ProjectEmployee>
    {
        private readonly Context _db;
        public ProjectEmployeeRepository(Context db) : base(db)
        {
            _db = db;
        }
    }
}
