using Microsoft.EntityFrameworkCore;
using TimeReportAPI.Data;
using TimeReportAPI.Repositories.Interfaces;
using TimeReportClassLibrary.Models;

namespace TimeReportAPI.Repositories
{
    public class ProjectRepository : IRepository<Project>
    {
        private readonly Context _db;
        public ProjectRepository(Context db)
        {
            _db = db;
        }

        public async Task<Project> Add(Project entity)
        {
            var addedProject= await _db.Projects.AddAsync(entity);
            await _db.SaveChangesAsync();
            return addedProject.Entity;
        }

        public async Task<Project> Delete(int id)
        {
            var ProjecttoDelete = await _db.Projects.FirstOrDefaultAsync(p => p.ProjectID == id);
            if(ProjecttoDelete == null)
            {
                return null;
            }
            _db.Projects.Remove(ProjecttoDelete);
            await _db.SaveChangesAsync();
            return ProjecttoDelete;
        }

        public async Task<Project> Get(int id)
        {
            var FindProjectbyId = await _db.Projects.FirstOrDefaultAsync(p =>p.ProjectID == id);    
            if (FindProjectbyId == null)
            {
                return null;
            }
            return FindProjectbyId;
        }

        public async Task<IEnumerable<Project>> GetAll()
        {
            var AllProjects = await _db.Projects.ToListAsync();
            return AllProjects;
        }

        public async Task<Project> Update(Project entity)
        {
            var UpdatedProject = await _db.Projects.FirstOrDefaultAsync(p=> p.ProjectID==entity.ProjectID);
            if (UpdatedProject != null)
            {
                UpdatedProject.ProjectName = entity.ProjectName;
                await _db.SaveChangesAsync();
                return UpdatedProject;
            }
            return null;
        }
    }
}
