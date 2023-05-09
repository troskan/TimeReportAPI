namespace TimeReportAPI.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        //Get All
        Task<IEnumerable<T>> GetAll();

        //Get ID
        Task<T> Get(int id);

        //Edit/Update
        Task<T> Update(T entity);

        //Delete
        Task<T> Delete(int id);

        //Add
        Task<T> Add(T entity);


    }
}
