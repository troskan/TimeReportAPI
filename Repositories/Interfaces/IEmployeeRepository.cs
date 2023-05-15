using TimeReportClassLibrary.Models;
using TimeReportAPI.DTO;

namespace TimeReportAPI.Repositories.Interfaces
{
    public interface IEmployeeRepository<T> : IRepository<Employee>
    {
        Task<IEnumerable<T>> GetEmployeesByProject(int id);
        Task<List<EmployeeTimeReportDTO>> GetTimeReportsByEmployee(int id);
        Task<ProjectEmployee> AddRelationEmployeeProject(int empID, int projectID);
        Task<ProjectEmployee> DeleteRelationEmployeeProject(int empID, int projectID);
    }
}
