using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionCore.Interfaces
{
    public interface IRepository<T>
    {
        /// <summary>
        /// checks if the query reflects an existing item in the table or not.
        /// </summary>
        /// <param name="query">a lamda expression by which to filter in the table</param>
        /// <returns>a task with the result true if the query has at least one result, false if it does not</returns>
        Task<bool> Contains(Expression<Func<T, bool>> query);
        /// <summary>
        /// checks how many items fit the quiry
        /// </summary>
        /// <param name="query">a lamda expression by which to filter in the table</param>
        /// <returns>a task with the result of how many items fit the query</returns>
        Task<int> Count(Expression<Func<T, bool>> query);
        /// <summary>
        /// add an item to the table
        /// </summary>
        /// <param name="toCreate">the object to add to the table</param>
        /// <returns>a task with the result true if T toCreate was added, or false if it was not</returns>
        Task<bool> Create(T toCreate);
        /// <summary>
        /// delete an object with the given id from the table
        /// </summary>
        /// <param name="id">id of the item to remove</param>
        /// <returns>a task with the result true if an item with the given id was remove, or fasle if ti was not</returns>
        Task<bool> Delete(int id);
        /// <summary>
        /// get all objects in the table
        /// </summary>
        /// <returns>a task with the result of an IEnumerable of all objects in the table</returns>
        Task<IEnumerable<T>> GetAll();
        /// <summary>
        /// get all objects in the table that match the query
        /// </summary>
        /// <param name="query">a lamda expression by which to filter in the table</param>
        /// <returns>a task with the result of an IEnumerable of all matching objects in the table</returns>
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> query);
        /// <summary>
        /// gets an object
        /// </summary>
        /// <param name="id">id of the item to get</param>
        /// <returns>a task with the result of the object of the right id</returns>
        Task<T> Get(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="toUpdate"></param>
        /// <returns></returns>
        Task<bool> Update(T toUpdate);
    }
}
