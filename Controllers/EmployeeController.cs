using Microsoft.AspNetCore.Mvc;
using TimeReportAPI.DTO;
using TimeReportAPI.Repositories;
using TimeReportAPI.Repositories.Interfaces;
using TimeReportClassLibrary.Models;

namespace TimeReportAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IRepository<Employee> _db;
        private readonly IEmployeeRepository<Employee> _EmpRepo;

        public EmployeeController(IRepository<Employee> db, IEmployeeRepository<Employee> empRepo)
        {
            _db = db;
            _EmpRepo = empRepo;
        }
        [HttpGet("GetEmployeesByProjectId/{id:int}")]
        public async Task<IActionResult> GetEmployeesByProject(int id)
        {
            var employees = await _EmpRepo.GetEmployeesByProject(id);
            return employees == null ? NotFound() : Ok(employees);
        }

        [HttpGet("GetTimeReportByEmployeeId/{id:int}")]
        public async Task<IActionResult> GetTimeReportsByEmployee(int id)
        {
            var employees = await _EmpRepo.GetTimeReportsByEmployee(id);
            return employees == null ? NotFound() : Ok(employees);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _db.GetAll();

            if (employees == null || !employees.Any())
            {
                return NotFound();
            }

            return Ok(employees);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            var employee = await _db.Get(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeDTO employeeDTO)
        {
            try
            {
                var employee = new Employee();
                employee.FirstName = employeeDTO.FirstName;
                employee.LastName = employeeDTO.LastName;

                return Ok(await _db.Add(employee));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding employee: {ex.Message}");
                return BadRequest();
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(Employee employee)
        {
            try
            {
                return Ok(await _db.Update(employee));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                return Ok(await _db.Delete(id));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost("AddEmployeeToProject")]
        public async Task<IActionResult> AddEmployeeToProject(int employeeID, int projectID)
        {
            try
            {
                return Ok(await _EmpRepo.AddRelationEmployeeProject(employeeID, projectID));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding employee to project: {ex.Message}");
                return BadRequest();
            }
        }
        [HttpDelete("DeleteEmployeeFromProject")]
        public async Task<IActionResult> DeleteEmployee(int employeeID, int projectID)
        {
            try
            {
                return Ok(await _EmpRepo.DeleteRelationEmployeeProject(employeeID, projectID));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
