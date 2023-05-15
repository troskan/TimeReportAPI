using TimeReportClassLibrary.Models;

namespace TimeReportAPI.Repositories.Interfaces
{
    public interface IEmployeeRepository<T> : IRepository<Employee>
    {
        Task<IEnumerable<T>> GetEmployeesByProject(int id);
    }
}
