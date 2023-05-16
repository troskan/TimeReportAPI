namespace TimeReportAPI.Repositories
{
    public interface IProjectRepository<T>
    {
        Task<List<T>> GetAllEmployeesByProject(int id);
    }
}
