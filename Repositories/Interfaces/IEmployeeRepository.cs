using TimeReportAPI.DTO;
using TimeReportClassLibrary.Models;

namespace TimeReportAPI.Repositories.Interfaces
{
    public interface IEmployeeRepository<T>
    {
        Task<IEnumerable<T>> GetEmployeesByProject(int id);
        Task<List<EmployeeTimeReportDTO>> GetTimeReportsByEmployee(int id);
        Task<ProjectEmployee> AddRelationEmployeeProject(int empID, int projectID);
        Task<ProjectEmployee> DeleteRelationEmployeeProject(int empID, int projectID);
    }
}
