using System;
using System.Collections.Generic;

namespace WebShop.DataAccess.Interfaces
{
    /// <summary>
    /// The interface definition for a generic repository.
    /// </summary>
    public interface IGenericRepository<T> : IDisposable where T: class
    {
        /// <summary>
        /// Gets all objects of type T from the repository.
        /// </summary>
        /// <returns>An IEnumerable collection of type T.</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Inserts a new object of type T to the repository if it does not exist or updates it otherwise.
        /// </summary>
        /// <param name="entity">Entity to be inserted/updated.</param>
        void InsertOrUpdate(T entity);
    }
}
