using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Eventing.Reader;
using TimeReportAPI.Data;
using TimeReportAPI.Repositories.Interfaces;
using TimeReportClassLibrary.Models;

namespace TimeReportAPI.Repositories
{
    public class EmployeeRepository : IRepository<Employee>
    {
        private readonly Context _db;
        public EmployeeRepository(Context db) 
        {
            _db = db;
        }

        public async Task<Employee> Add(Employee entity)
        {
            if (entity.FirstName == null || entity.LastName == null) { return null; }
            if (entity.FirstName.Length < 2 || entity.LastName.Length < 2) { return null; }

            try
            {
                await _db.AddAsync(entity);
                await _db.SaveChangesAsync();
                return entity;

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<Employee> Delete(int id)
        {

            try
            {
                var employeeToDelete = await _db.Employees.FirstOrDefaultAsync(e => e.EmployeeID == id);

                if (employeeToDelete == null)
                {
                    return null;
                }

                _db.Remove(employeeToDelete);
                await _db.SaveChangesAsync();

                return employeeToDelete;

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<Employee> Get(int id)
        {

            try
            {
                var employeeToGet = await _db.Employees.FirstOrDefaultAsync(e => e.EmployeeID == id);

                if (employeeToGet == null)
                {
                    return null;
                }

                return employeeToGet;

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            try
            {
                return await _db.Employees.ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<Employee> Update(Employee entity)
        {
            //if (entity.FirstName == null || entity.LastName == null) { return null; }
            //if (entity.FirstName.Length < 2 || entity.LastName.Length < 2) { return null; }
            if (entity.EmployeeID == null || entity.EmployeeID == 0) { return null; }

            try
            {
                var employeeToUpdate = await _db.Employees.FirstOrDefaultAsync(e=>e.EmployeeID == entity.EmployeeID);
                employeeToUpdate.FirstName = entity.FirstName;
                employeeToUpdate.LastName = entity.LastName;

                await _db.SaveChangesAsync();

                return entity;

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
