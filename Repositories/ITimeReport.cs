﻿namespace TimeReportAPI.Repositories
{
    public interface ITimeReport<T>
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