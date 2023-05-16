using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using TimeReportAPI.Repositories;
using TimeReportAPI.Repositories.Interfaces;
using TimeReportClassLibrary.Models;

namespace TimeReportAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private IRepository<Project> _repository;
        private IProjectRepository<Employee> _db;
        public ProjectController(IRepository<Project> repository, IProjectRepository<Employee> db)
        {
            _repository = repository;
            _db = db;
        }
        [HttpGet("GetAllEmployeesByProjectID")]
        public async Task<IActionResult> GetAllEmployeesByProjectID(int id)
        {
            try
            {
                return Ok(await _db.GetAllEmployeesByProject(id));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retrieving data from database");
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProjects()
        {
            try
            {
                return Ok(await _repository.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retrieving data from database");
            }
        }
        [HttpGet("projectid/{id:int}")]
        public async Task<ActionResult<Project>> GetProjectById(int id)
        {
            try
            {
                var result = await _repository.Get(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retrieving data from database");
            }
        }
        [HttpPost]
        public async Task<ActionResult<Project>> AddNewProject(Project newProject)
        {
            try
            {
                if (newProject == null)
                {
                    return BadRequest();
                }
                var result = await _repository.Add(newProject);
                return CreatedAtAction(nameof(GetProjectById), new { id = result.ProjectID }, result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while trying to add new project");
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Project>> DeleteProject(int id)
        {
            try
            {
                var ProjecttoDelete = await _repository.Get(id);
                if (ProjecttoDelete == null)
                {
                    return NotFound($"Project with ID {id} was not found");
                }
                return await _repository.Delete(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Unable to delete data from database");
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Project>> UpdateProject(int id, Project project)
        {
            try
            {
                if (id != project.ProjectID)
                {
                    return BadRequest("Unable to find a matching id");
                }
                var UpdatedProject = await _repository.Get(id);
                if(UpdatedProject == null)
                {
                    return NotFound($"Order with ID {id} not found");
                }
                return await _repository.Update(project);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while trying to update");
            }
        }
    }
}
        
        
