using Microsoft.EntityFrameworkCore;
using TimeReportAPI.Data;
using TimeReportAPI.Repositories.Interfaces;
using TimeReportClassLibrary.Models;

namespace TimeReportAPI.Repositories
{
    public class ProjectEmployeeRepository : IRepository<ProjectEmployee>
    {
        private readonly Context _db;
        
        public ProjectEmployeeRepository(Context db)
        {
            _db = db;
            
        }
        public async Task<ProjectEmployee> Add(ProjectEmployee entity)
        {
            var addedProjectEmployee = await _db.ProjectEmployees.AddAsync(entity);
            await _db.SaveChangesAsync();
            return addedProjectEmployee.Entity;
        }

        public async Task<ProjectEmployee> Delete(int id)
        {
            try
            {
                var ProjectemployeeToDelete = await _db.ProjectEmployees.FirstOrDefaultAsync(e => e.ProjectEmployeeID == id);

                if (ProjectemployeeToDelete == null)
                {
                    return null;
                }

                _db.Remove(ProjectemployeeToDelete);
                await _db.SaveChangesAsync();

                return ProjectemployeeToDelete;

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return null;
            }
            
        }

        public async Task<ProjectEmployee> Get(int id)
        {
            var FindProjectEmployeebyId = await _db.ProjectEmployees.FirstOrDefaultAsync(p => p.ProjectEmployeeID == id);
            if (FindProjectEmployeebyId == null)
            {
                return null;
            }
            return FindProjectEmployeebyId;
        }

        public async Task<IEnumerable<ProjectEmployee>> GetAll()
        {
            var AllProjectEmployee = await _db.ProjectEmployees.ToListAsync();
            return AllProjectEmployee;
        }

        public Task<ProjectEmployee> Update(ProjectEmployee entity)
        {
            _db.SaveChanges();
            return null;
        }
    }
}
