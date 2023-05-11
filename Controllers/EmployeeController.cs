using Microsoft.AspNetCore.Mvc;
using TimeReportAPI.DTO;
using TimeReportAPI.Repositories.Interfaces;
using TimeReportClassLibrary.Models;

namespace TimeReportAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IRepository<Employee> _db;
        public EmployeeController(IRepository<Employee> db)
        {
            _db = db;
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
    }
}
