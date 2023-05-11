using TimeReportAPI.DTO;

namespace TimeReportAPI.Repositories.Interfaces
{
    public interface IEmployeeRepository<T>
    {
        Task<IEnumerable<T>> GetEmployeesByProject(int id);
        Task<List<EmployeeTimeReportDTO>> GetTimeReportsByEmployee(int id);
    }
}
